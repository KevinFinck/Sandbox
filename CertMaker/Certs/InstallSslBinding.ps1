 [CmdletBinding()]
param(
    [Parameter(Mandatory=$True,HelpMessage="The machine name")]
		[string]$machineName,
	[Parameter(HelpMessage="The environment for install")]
		[ValidateSet('DEV')]
		[string]$environment="DEV",
	[Parameter(HelpMessage="The thumbprint of attached certificate")]
		[string]$Thumbprint = $null,
	[Parameter(HelpMessage="The name of the WebSite like Default Web Site")]
		[string]$Name = "Default Web Site")
	

$ErrorActionPreference = "Stop";
$CertPath = $PSScriptRoot;

if($environment -eq "DEV"){
	#DevSslCert.pfx thumbprint
	$Thumbprint = "9c052216ec63afd7e92cb509fcbb1db2105b4a6f"

	$arguments = "-delstore -enterprise -v root DevCARoot";
	Start-Process -NoNewWindow 'certutil.exe' -ArgumentList $arguments -Wait -PassThru;
	
	$arguments = "-delstore -v my " + $Thumbprint;
	Start-Process -NoNewWindow 'certutil.exe' -ArgumentList $arguments -Wait -PassThru;
}

Write-Host "Installing DevCARoot certificate" | Out-String;
$arguments = '-addstore -enterprise -f -v root "' + $CertPath + '\DevCARoot.cer"';
Write-Host $arguments | Out-String;
Start-Process -NoNewWindow 'certutil.exe' -ArgumentList $arguments -Wait -PassThru;

Write-Host "Installing DevCARoot and private key for SSL";
$arguments = '-f -v -p mytest -importpfx "' + $CertPath + '\DevSslCert.pfx" NoRoot';
Write-Host $arguments | Out-String;
Start-Process -NoNewWindow 'certutil.exe' -ArgumentList $arguments -Wait -PassThru;

Import-Module WebAdministration

gci CERT:\LocalMachine\My | ft | Out-String;
gci CERT:\LocalMachine\Root | ft | Out-String;

$sslCertificate = gci 'CERT:\LocalMachine\My' | Where-Object { $_.Thumbprint -ilike $Thumbprint };
if (-not $sslCertificate) {
	Throw "Cannot find SSL certificate for $Name, cannot configure HTTPS.";
}

dir 'IIS:\SslBindings' | Where-Object { $_.IPAddress -eq "0.0.0.0" -and $_.Port -eq 443 } | % { $sslBinding = $_ };

Write-Host "Configuring Website: $Name"  | Out-String;

if ($sslBinding) {
	Write-Host "Deleting SslBinding " + $sslBinding | Out-String;
	Get-WebBinding -Port 443 -Name $Name | Remove-WebBinding
	Remove-Item -Path "IIS:\SslBindings\0.0.0.0!443";
	$sslBinding = $null;
}

New-WebBinding -Name "$Name" -IP "*" -Port 443 -Protocol https;
New-WebBinding -Name "$Name" -IP "*" -Port 443 -Protocol https -HostHeader "localhost";
New-WebBinding -Name "$Name" -IP "*" -Port 443 -Protocol https -HostHeader $machineName;
New-WebBinding -Name "$Name" -IP "*" -Port 443 -Protocol https -HostHeader "127.0.0.1";
New-Item -Path "IIS:\SslBindings\0.0.0.0!443" -Value $sslCertificate;

# for specific site use for example "Default Web Site/Admin"
$site = $Name + "/EnterpriseApi"
Set-WebConfiguration -value "Ssl,SslNegotiateCert" -filter "system.webserver/security/access" -location $site