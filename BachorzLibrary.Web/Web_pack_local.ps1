# fast local release of a nuget
Get-ChildItem .\bin\Debug\*.nupkg | Remove-Item
dotnet pack /p:Version=0.0.2 -c Debug
Move-Item .\bin\Debug\*.nupkg c:\nuget\ -Force