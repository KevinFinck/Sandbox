[CmdletBinding()]
param(
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

Import-Module WebAdministration

dir 'IIS:\SslBindings' | Where-Object { $_.IPAddress -eq "0.0.0.0" -and $_.Port -eq 443 } | % { $sslBinding = $_ };

Write-Host "Configuring Website: $Name"

if ($sslBinding) {
	Write-Host "Deleting SslBinding " + $sslBinding;
	Get-WebBinding -Port 443 -Name $Name | Remove-WebBinding
	Remove-Item -Path "IIS:\SslBindings\0.0.0.0!443";
	$sslBinding = $null;
}

$site = $Name + "/EnterpriseApi"
Set-WebConfiguration -value "" -filter "system.webserver/security/access" -location $site