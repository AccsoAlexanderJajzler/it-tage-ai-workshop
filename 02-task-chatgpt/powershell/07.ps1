Import-Module PSRemoteRegistry
Do {
    $srcserver = Read-Host "Please enter the DNS name of the source server"
}
While ($srcserver -eq "")
Do {
    $destserver = Read-Host "Please enter the DNS name of the destination server"
}
While ($destserver -eq "")
Do {
    $source = Read-Host "Please enter the full network path of the source folder (example: \\server\d$\folder)"
}
While ($source -eq "")
Do {
    $dest = Read-Host "Please enter the full network path of the destination folder (example: \\server\d$\folder)"
}
While ($dest -eq "")
$now = Get-Date -Format MM-dd-yyyy
robocopy $source $dest /E /ZB /DCOPY:T /COPYALL /R:1 /W:1 /V /TEE /LOG:$now.log
New-BurntToastNotification -Text "The files have been copied" -AppLogo $null -Silent
$Key = "SYSTEM\CurrentControlSet\services\LanmanServer\Shares"
$share = Get-RegMultiString -ComputerName $srcserver -Key $key -Value ShareNameHere
New-RegKey -ComputerName $destserver -Key $Key -Name ShareNameHere -PassThru | Set-RegMultiString -Value MultiString -Data $share.Data
