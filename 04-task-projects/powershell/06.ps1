try {
	Get-WmiObject -Class Win32_NetworkAdapterConfiguration | Format-Table -property ServiceName,Description,IPAddress,DHCPEnabled -AutoSize
	exit 0 # success
} catch {
	"⚠️ Error in line $($_.InvocationInfo.ScriptLineNumber): $($Error[0])"
	exit 1
}