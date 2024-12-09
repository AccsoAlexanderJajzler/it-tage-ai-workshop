while ($true) {
    Get-ChildItem -Filter *.md | ForEach-Object {
        $mdFile = $_
        $pdfFile = "$($mdFile.BaseName).pdf"
        if (-Not (Test-Path $pdfFile) -or 
(Get-Item $mdFile).LastWriteTime -gt 
(Get-Item $pdfFile).LastWriteTime) {
            Write-Output $mdFile
            pandoc $mdFile -o $pdfFile
        }
    }
    Start-Sleep -Seconds 1
}
