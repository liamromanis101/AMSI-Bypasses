# AMSI-Bypasses
some AMSI bypass scripts

obfuscate2.cs uses base64 obfuscation to run powershell commands without detection. 
Compile using csc.exe, something like this:

csc.exe -reference:"path to System.Management.Automation.dll" obfuscate2.cs

Usage:
obfuscate2.exe <powershell command>
