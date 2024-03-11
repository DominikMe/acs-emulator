$cert = New-SelfSignedCertificate -DnsName "localhost", "go.trouter.teams.microsoft.com" -FriendlyName "AcsEmulatorSelfSignedCert" -CertStoreLocation "Cert:\CurrentUser\My" -KeyExportPolicy Exportable -KeySpec Signature -KeyLength 2048 -KeyAlgorithm RSA -HashAlgorithm SHA256
$mypwd = ConvertTo-SecureString -String "mypassword" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath "acsEmulator_SelfSigned.pfx" -Password $mypwd
