param([string]$version)
echo $version
$versionNumbers = $version.Split(".")
if($versionNumbers[1] -eq "0" -AND $versionNumbers[2] -eq "0")
{
    $oldVersion = $versionNumbers[0] - 1
}else{
    $oldVersion = $versionNumbers[0]
}
$oldVersion = $oldVersion.ToString() +".0.0"
echo $oldVersion
& ..\..\nuget install EndpointTestDataGenerator -Version $oldVersion -OutputDirectory ..\LastMajorVersionBinary
& copy ..\LastMajorVersionBinary\EndpointTestDataGenerator.$oldVersion\lib\net6.0\EndpointTestDataGenerator.dll ..\LastMajorVersionBinary
