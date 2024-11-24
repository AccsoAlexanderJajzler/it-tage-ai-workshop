param([string]$text = "", [string]$imageSize = "", [string]$fileFormat = "")

try {
	if ($text -eq "") { $text = Read-Host "Enter text or URL" }
	if ($imageSize -eq "") { $imageSize = Read-Host "Enter image size, e.g. 500x500" }
	if ($fileFormat -eq "") { $fileFormat = Read-Host "Enter the image file format, e.g. JPG" }

	$ECC = "M" # can be L, M, Q, H
	$QuietZone = 1
	$ForegroundColor = "000000"
	$BackgroundColor = "ffffff"
        if ($IsLinux) {
                $pathToPictures = Resolve-Path "$HOME/Pictures"
        } else {
                $pathToPictures = [Environment]::GetFolderPath('MyPictures')
        }
        if (-not(Test-Path "$pathToPictures" -pathType container)) { throw "Pictures folder at 📂$Path doesn't exist (yet)" }
	$newFile = "$pathToPictures/QR_code.$fileFormat"

	$WebClient = New-Object System.Net.WebClient
	$WebClient.DownloadFile(("http://api.qrserver.com/v1/create-qr-code/?data=" + $text + "&ecc=" + $ECC +`
		"&size=" + $imageSize + "&qzone=" + $QuietZone + `
		"&color=" + $ForegroundColor + "&bgcolor=" + $BackgroundColor.Text + `
		"&format=" + $fileFormat), $newFile)

	"✅ New QR code saved as: $newFile"
	exit 0 # success
} catch {
	"⚠️ Error in line $($_.InvocationInfo.ScriptLineNumber): $($Error[0])"
	exit 1
}