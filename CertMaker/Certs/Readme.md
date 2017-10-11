#IIS X509 Certificates 

##Localhost
* Private key - DevSslCert.pfx  password: mytest
* Root certificate - DevCARoot.cer

###Install
The powershell cert install script completes these tasks:
* Install root cert into machine trusted root cert authorities store.
* Installs private key into machine personal cert store.
* Creates IIS port 443 bindings for localhost, 127.0.0.1, and the machine name.
* As of 1/13/2016 requires SSL for EAPI only.
####Instructions
* Run as administrator Powershell desktop app.  Do not use the x86 powershell version.
* Run from script directory ..\enterprise-apps\LowerEnvironments\X509\Localhost>
```
PS >.\InstallSslBinding.ps1 -machinename [YOURMACHINENAME]
```

####Runtime Errors
* If this is the first time you run Powershell you will likely get a permissions error.  You will need to set your execution policy.
```
PS >Set-ExecutionPolicy -ExecutionPolicy RemoteSigned
```
* On some development boxes to enumerate SslBindings you will need add a registry key.
```
HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\HTTP\Parameters\SslBindingInfo\0.0.0.0:443\SslCertStoreName=MY
```

###Remove
Removes IIS bindings and certs from stores.
* Repeat first two steps for install
```
PS > .\RemoveSslBinding.ps1
```


