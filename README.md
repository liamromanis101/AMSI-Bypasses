# AMSI-Bypasses
some AMSI bypass scripts

obfuscate2.cs uses base64 obfuscation to run powershell commands without detection. Bypasses GPO blocking of powershell. 
Compile using csc.exe, something like this:

csc.exe -reference:"path to System.Management.Automation.dll" obfuscate2.cs

Usage:
obfuscate2.exe <powershell command>
