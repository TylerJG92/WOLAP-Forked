# Folder conatining this packaging script
$packagerRoot = $PSScriptRoot
# Root folder of the WOLAP Repository
$repoRoot = Split-Path -Parent $packagerRoot
# Root to Patcher
$patchRoot = Join-Path $repoRoot -ChildPath patcher\WOLAP.DependencyPatcher
# Root for the ref Folder
$refRoot = Join-Path $packagerRoot "ref"
# Root to the LICENSES folder
$licensesRoot = Join-Path $packagerRoot "LICENSES"
# path to main-mod WOLAP.csproj
$mMWOLAPProj = Join-Path $repoRoot "WOLAP.csproj"
# Path to main-mod WOLAP.dll
$mMWORelPath = Join-Path $repoRoot -ChildPath bin\Release\netstandard2.0\WOLAP.dll
# Path to patch WOLAP.DependencyPatcher.csproj
$paWOLAPProj = Join-Path $patchRoot "WOLAP.DependencyPatcher.csproj"
# Path to patch WOLAP.DependencyPatcher.dll
$paWORelPath = Join-Path $patchRoot -ChildPath bin\Release\net35\WOLAP.DependencyPatcher.dll
# Path to manifest
$maniPath = Join-Path $packagerRoot "manifest.json"
# Path to pack README.md
$readPath = Join-Path $packagerRoot "README.md"
# Path to icon.png
$iconPath = Join-Path $packagerRoot "icon.png"
# Path to ref\Newtonsoft
$newtPath = Join-Path $refRoot "Newtonsoft.Json.dll"
# Path to all Licenses in .\ModManager_Packager\LICENSES
$licensesPaths = Get-ChildItem $licensesRoot
# Path to WOLAP mod License
$mMLicensePath = Join-Path $repoRoot "LICENSE"
# Root for output folder, different name sorting since this is the End location
$outputEnd = Join-Path $packagerRoot "output"

# Creates an array of variables for each Path that needs to be checked before we run the .csproj files to get the last files for the packager
$neededFiles = @(
    $maniPath
    $readPath
    $iconPath
    $newtPath
    $licensesPaths
    $mMLicensePath
)
# Creates an array of variables for each Path that is required for the packaging under $neededFilesEnd
$neededFilesEnd = @(
    $mMWORelPath
    $paWORelPath
    $neededFiles
)
# Creates an array of variables for each Proj under $needProj
$neededProj = @(
    $mMWOLAPProj
    $paWOLAPProj
)

Write-Host "Checking required files before starting .dll creation"
# pre-check to see if all files EXCEPT for the files that need to be made in the .csproj are present
foreach($file in $neededFiles) {if ( -not(Test-Path $file)) {
    throw "Required file not found at $file"
}}
Write-Host "All required files in place, Creating WOLAP.dll and WOLAP.DependencyPatcher.dll"

# code to start the creation of the .dll files goes here

Write-Host: "Checking required files before Packaging"
# will run after the .csproj files create their release .dll files, checks if all required files for packaging are present and throws an error if not
foreach($file2 in $neededFilesEnd) {if ( -not(Test-Path $file2)) {
    throw "Required file not found at $file2"
}}
Write-Host "All required Files in place, starting Packaging"

# code to start the Packaging of everything into the proper places in a .Zip file goes here