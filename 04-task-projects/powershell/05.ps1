try {
	if ($IsLinux) {
		"🐧(uname -sr)"
	} else {
		$OS = Get-WmiObject -class Win32_OperatingSystem
		$OSname = $OS.Caption
		$OSarchitecture = $OS.OSArchitecture
		$OSversion = $OS.Version
		"🌐$OSname for $OSarchitecture version $OSversion"
	}
	exit 0 # success
} catch {
	"⚠️ Error in line $($_.InvocationInfo.ScriptLineNumber): $($Error[0])"
	exit 1
}