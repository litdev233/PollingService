%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\WorkSpace\PollingService\Litdev.Service\bin\Debug\Litdev.Service.exe
Net Start PollingService
sc config PollingService start= auto
pause