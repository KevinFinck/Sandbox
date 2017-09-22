#r @"tools/FAKE.4.50.0/tools/FakeLib.dll"
open System
open Fake
open Fake.Testing
open Fake.FileSystemHelper
open Fake.OctoTools

type BuildTool = { name : string; packageId : string; version : string; }

//Add required build tooling here. Upgrade tool by changing version.
let buildTools = [
    { name = "sqlmigrater";  packageId = "Incomm.Libraries.SqlMigrater"; version = "1.0.12"; }; 
    { name = "nunit"; packageId = "NUnit.ConsoleRunner"; version = "3.6.0"; };
    { name = "octopus"; packageId = "OctopusTools"; version = "4.9.0"; };
]

let getBuildTool name = 
    let isTool t = t.name = name
    match List.tryFind isTool buildTools with
    | Some value -> value
    | None -> invalidArg name "Build tool could not be found"

let IsConsoleOnly = System.String.Equals((getBuildParamOrDefault "ConsoleOnly" "N"), "Y", System.StringComparison.CurrentCultureIgnoreCase)

let BuildConfiguration = getBuildParamOrDefault "Config" "Debug"
let NugetUsername = getBuildParamOrDefault "nugetuser" ""
let NugetPassword = getBuildParamOrDefault "nugetpassword" ""
let GitHash =  getBuildParamOrDefault "githash" ""
let SqlServer = getBuildParamOrDefault "db" "localhost"
let PublishFeed = getBuildParamOrDefault "publishto" "http://10.20.30.55:888"
let OctoApiKey = getBuildParamOrDefault "octoapikey" ""
let OctoServer = getBuildParamOrDefault "octoserver" "http://10.20.30.86"
let BuildCounter = getBuildParamOrDefault "buildcounter" ""
let OctoProjectName = "JetEngine"
let ArtifactoryUrl = "https://ids.jfrog.io/ids/api/nuget/central"
let UseLocalNuget = ((NugetUsername + NugetPassword) = "")
let nugetAddSourceCommand = sprintf "sources add -Name Artifactory -Source %s -Username %s -Password %s  -ConfigFile ./tools/nuget/NuGet.Config" ArtifactoryUrl NugetUsername NugetPassword
let nugetExe = "./tools/nuget/NuGet.exe"

let Publish = GitHash <> ""

let ShortGitHash = 
    if Publish then
        if GitHash.Length > 16 then 
            GitHash.[0..16]                 
        else 
            GitHash
    else 
        ""
 
let BuildNumber = 
    if Publish then
        let currentDate = System.DateTime.Now.ToString("yyyy.MM.dd")
        sprintf "%s-git%s" currentDate ShortGitHash 
    else
        ""

let nugetRestoreCommand packagesFile = 
    if UseLocalNuget
    then
        "restore " + packagesFile + " -PackagesDirectory ../packages -verbosity detailed"
    else
        "restore " + packagesFile + " -ConfigFile tools/nuget/NuGet.Config -PackagesDirectory ../packages  -ConfigFile ./tools/nuget/NuGet.Config"

let nugetInstallCommand packageId version =
    if UseLocalNuget
    then
        sprintf "install %s -version %s -outputdirectory .\\tools -noninteractive -verbosity detailed" packageId version
    else
        sprintf "install %s -version %s -outputdirectory .\\tools -noninteractive -verbosity detailed  -ConfigFile ./tools/nuget/NuGet.Config" packageId version

let AreNotEmpty = Seq.forall(fun p -> p <> "")
let MsBuildProperties =
    if Publish
    then
        [("Configuration", BuildConfiguration);
         ("RunOctoPack", "True");
         ("OctoPackPackageVersion", BuildNumber);
         ("OctoPackPublishPackagesToTeamCity", "False")
        ]
    else
        [("Configuration", BuildConfiguration)]


let RunNpmTestsIn = (fun testPath buildConfiguration ->
    let workingDirectory = 
        if buildConfiguration = "Debug"
        then
            "test"
        else
            sprintf "test-%s-tc" (toLower buildConfiguration)
            
    NpmHelper.Npm (fun p ->
            {
                p with
                    Command = (NpmHelper.Run (sprintf "%s --verbose" workingDirectory))
                    WorkingDirectory = testPath
            })
)

let GetGDBAlias = 
    getRegistryValue64 RegistryBaseKey.HKEYLocalMachine """SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo\""" "GDBServer"
        |> (fun s -> s.Split([|','|], 2 ))
        |> (fun array -> array.[1])

let SetGDBAlias (servername : string) =
    if servername.Contains("localhost")
    then
        use key64 = getRegistryKey64 RegistryBaseKey.HKEYLocalMachine """SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo\""" true
        key64.SetValue("GDBServer", "dbmslpcn,localhost")
        use key = getRegistryKey RegistryBaseKey.HKEYLocalMachine """SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo\""" true
        key.SetValue("GDBServer", "dbmslpcn,localhost")
    else
        let registryValue = "DBMSSOCN," + servername
        use key64 = getRegistryKey64 RegistryBaseKey.HKEYLocalMachine """SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo\""" true
        key64.SetValue("GDBServer", registryValue)
        use key = getRegistryKey RegistryBaseKey.HKEYLocalMachine """SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo\""" true
        key.SetValue("GDBServer", registryValue)

let publishNugetPackage = (fun sourceUrl -> 
    !! (sprintf "../CardApi/bin/CardApi.*%s.nupkg" ShortGitHash)
    |> Seq.iter(fun nugetPackage ->
        let pushCommand = sprintf "push %s -Source %s -ConfigFile ./tools/nuget/NuGet.Config" nugetPackage sourceUrl
        if IsConsoleOnly then
            Console.WriteLine("EXECUTE: {0}", pushCommand)
        else
            let exitCode = Shell.Exec(nugetExe, pushCommand)
            ()
    )    
)

let showSetting (name :string, value :string) = (
    let prev = Console.ForegroundColor;
    Console.ForegroundColor <- ConsoleColor.Cyan;
    Console.Write(" {0}: ", name);
    Console.ForegroundColor <- ConsoleColor.DarkYellow;
    Console.WriteLine(value);
    Console.ForegroundColor <- prev;
)

Target "ShowSettings" (fun _ -> 
    Console.WriteLine()
    Console.WriteLine("--------------------------------------------")
    Console.WriteLine("----------------- SETTINGS -----------------")
    Console.WriteLine("--------------------------------------------")
    Console.WriteLine()

    showSetting("IsConsoleOnly", sprintf "%b" IsConsoleOnly)
    showSetting("BuildConfiguration", BuildConfiguration)
    showSetting("NugetUsername", NugetUsername)
    showSetting("NugetPassword", NugetPassword)
    showSetting("GitHash", GitHash)
    showSetting("SqlServer", SqlServer)
    showSetting("PublishFeed", PublishFeed)
    showSetting("OctoApiKey", OctoApiKey)
    showSetting("OctoServer", OctoServer)
    showSetting("BuildCounter", BuildCounter)
    showSetting("OctoProjectName", OctoProjectName)
    showSetting("ArtifactoryUrl", ArtifactoryUrl)
    showSetting("UseLocalNuget", sprintf "%b" UseLocalNuget)
    showSetting("nugetAddSourceCommand", nugetAddSourceCommand)
    showSetting("nugetExe", nugetExe)
    showSetting("Publish", sprintf "%b" Publish)
    showSetting("ShortGitHash", ShortGitHash) 
    showSetting("BuildNumber", BuildNumber) 

    Console.WriteLine()
    Console.WriteLine("--------------------------------------------")
    Console.WriteLine()
    ()
)

Target "Help" (fun _ -> 
    Console.WriteLine()
    Console.WriteLine("Usage:");
    Console.WriteLine("FAKE Build.fsx [target] [ShowSettings] [ConsoleOnly=Y/N] [Help]");
    Console.WriteLine("    [target]             -->  One of the build targets, CleanBuildDirectories, Build, etc.");
    Console.WriteLine("    [ShowSettings]       -->  Displays all the settings that would be used.)");
    Console.WriteLine("    [ConsoleOnly=Y/N]    -->  Only output to screen what build steps would do.");
    Console.WriteLine("    [Help]               -->  Display this help page.)");
    Console.WriteLine();
)

Target "Default" (fun _ ->
    
    run "ValidateParameters"

    let tasks = 
        if UseLocalNuget //localDev
        then
            "RestoreNugetPackages"
            ==> "CleanBuildDirectories"
            ==> "RestoreBuildTooling"
            ==> "Build"
            ==> "SqlMigration"
            ==> "UnitAndIntegrationTests"
            ==> "Completed"
        elif (not Publish)
        then
            "CreateNugetConfig" //localDev, no nuget config saved
            ==> "RestoreNugetPackages"
            ==> "RestoreBuildTooling"
            ==> "CleanBuildDirectories"
            ==> "Build"
            ==> "SqlMigration"
            ==> "UnitAndIntegrationTests"
            ==> "DeleteNugetConfig"
            ==> "Completed"
        else
            "CreateNugetConfig" //Teamcity
            ==> "RestoreNugetPackages"
            ==> "RestoreBuildTooling"
            ==> "CleanBuildDirectories"
            ==> "AssemblyVersion"
            ==> "Build"
            ==> "SqlMigration"
            ==> "RunEnvironmentSpecificTests"
            ==> "PublishOctopacks"
            ==> "CreateOctoRelease"
            ==> "DeleteNugetConfig"
            ==> "Completed"
        |> ignore

    run "Completed"
)

Target "ValidateParameters" (fun _ ->
    if UseLocalNuget
    then
        trace "Running simple build"
    else
        if ([NugetUsername; NugetPassword] |> AreNotEmpty)
        then
            if Publish
            then
                trace ("Running CI and publishing build number " + BuildNumber)
            else
                trace "Running local build with nuget credentials provided"

        else
            if Publish
                then
                    raise (System.ArgumentException("You must provide both a nuget username and nuget password in order to publish this build"))
                else
                    raise (System.ArgumentException("You must provide both a nuget username and nuget password, or neither in order to rely on your local nuget configuration"))
)

Target "CreateNugetConfig" (fun _ ->
    FileUtils.cp "Tools/nuget/NuGet.Config.TT" "Tools/nuget/NuGet.Config"
    if IsConsoleOnly then
        let addNugetSourceResult = Shell.Exec(nugetExe, nugetAddSourceCommand)
        ()
    else
        Console.WriteLine("EXECUTE: {0}, {1}", nugetExe, nugetAddSourceCommand)
)

Target "RestoreNugetPackages" (fun _ -> 
    !! "../*/packages.config"
    |> Seq.iter (fun f -> 
        if IsConsoleOnly then
            Console.WriteLine("EXECUTE: {0}, {1} {2}", nugetExe, nugetRestoreCommand, f)
        else
            Shell.Exec(nugetExe, nugetRestoreCommand f)
            |> ignore
    )
    ()
)

Target "RestoreBuildTooling" (fun _ ->
    buildTools
    |> Seq.iter (fun tool ->
        if IsConsoleOnly then
            Console.WriteLine("EXEC: {0} {1}",nugetExe, nugetInstallCommand tool.packageId tool.version)
        else
            Shell.Exec(nugetExe, nugetInstallCommand tool.packageId tool.version)
            |> ignore
    )
    ()
)

Target "CleanBuildDirectories" (fun _ ->
    if IsConsoleOnly then
        Console.WriteLine("CleanDirs:")
        !! ("../*/bin/")
        |> Seq.iter (fun name -> Console.WriteLine("   {0}", name))
    else
        !! ("../*/bin/")
        |> CleanDirs
)
    
Target "AssemblyVersion" (fun _ ->
    if IsConsoleOnly then
        Console.WriteLine("Calls BulkReplaceAssemblyInfoVersions()...")
    else
        BulkReplaceAssemblyInfoVersions "../CardApi/" (fun f -> 
            {f with AssemblyInformationalVersion = sprintf "1.0.%s (%s)" BuildCounter GitHash })
)

Target "Build" (fun _ -> 
    if IsConsoleOnly then
        Console.WriteLine("MsBuild...")
    else
        MSBuild null "rebuild" MsBuildProperties ["../CardApi.sln"]
        |> Log "AppBuild-Output: "
)

Target "SqlMigration" (fun _ ->
    let buildTool = getBuildTool "sqlmigrater"
    let sqlMigrater = sprintf "./tools/%s.%s/tools/SqlMigrater.exe" buildTool.packageId buildTool.version
    let args = sprintf "upgrade -s %s -d Cards -c Cards -a ../" SqlServer
    if IsConsoleOnly then
        Console.WriteLine("EXEC: {0}, {1}", sqlMigrater, args)
    else
        let exitCode = Shell.Exec(sqlMigrater, args)
        ()
)

Target "RunEnvironmentSpecificTests" (fun _ ->
    let oldGDBAlias = GetGDBAlias

    trace ("GDBServer Alias is " + oldGDBAlias)
    
    SetGDBAlias SqlServer
    
    trace ("Changed GDBServer Alias to " + SqlServer)

    if IsConsoleOnly then
        Console.WriteLine("RunEnvironmentSpecificTests...")
    else
        try
            run "UnitAndIntegrationTests"
        finally
            SetGDBAlias oldGDBAlias
            trace ("Changed GDBServer Alias back to " + oldGDBAlias)
)


Target "UnitAndIntegrationTests" (fun _ ->
    let buildTool = getBuildTool "nunit"
    let nunit = sprintf "./tools/%s.%s/tools/nunit3-console.exe" buildTool.packageId buildTool.version
    if IsConsoleOnly then
        Console.WriteLine("UnitAndIntegrationTests...")
    else
        ["../CardApi.Tests/bin/CardApi.Tests.dll"]
         |> NUnit3 (fun p -> 
            {p with 
                ShadowCopy = false;
                ToolPath = nunit;
            })
)


Target "PublishOctopacks" (fun _ ->
    if IsConsoleOnly then
        Console.WriteLine("PublishOctopacks...")
    else
        publishNugetPackage PublishFeed
)

Target "CreateOctoRelease" (fun _ ->
    if IsConsoleOnly then
        Console.WriteLine("CreateOctoRelease...")
    else
        let releaseSpec = { 
            releaseOptions with 
                Project = OctoProjectName;
                Version=BuildNumber;
                PackageVersion=BuildNumber;
                IgnoreExisting=true;
        }
        let deploySpec = { 
            deployOptions with
                DeployTo=BuildConfiguration;
                Force=true;
                WaitForDeployment=true;
        }
        let server = {
            ApiKey = OctoApiKey;
            Server = OctoServer
        }
        let buildTool = getBuildTool "octopus"
        Octo (fun p ->
        {
            p with
                Command = CreateRelease (releaseSpec, Some deploySpec)
                Server = server
                ToolPath = (sprintf "./tools/%s.%s/tools/"buildTool.packageId buildTool.version)
        })
)

Target "PublishToArtifactory" (fun _ ->
    if IsConsoleOnly then
        Console.WriteLine("PublishToArtifactory...")
    else
        run "CreateNugetConfig"

        publishNugetPackage ArtifactoryUrl

        run "DeleteNugetConfig"
)

Target "DeleteNugetConfig" (fun _ ->
    if IsConsoleOnly then
        Console.WriteLine("DeleteNugetConfig...")
    else
        DeleteFile "./tools/nuget/NuGet.Config"
)

Target "Completed" (fun _ ->
    trace "Build completed"
)

RunTargetOrDefault "Default"