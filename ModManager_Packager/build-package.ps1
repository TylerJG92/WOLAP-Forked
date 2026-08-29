# Folder conatining this packaging script
$packagerRoot = $PSScriptRoot
# Root folder of the WOLAP Repository
$repoRoot = Split-Path -Parent $packagerRoot
# Root to Patcher
$patchRoot = Join-Path $repoRoot -ChildPath patcher\WOLAP.DependencyPatcher
# Root for the ref Folder
$refRoot = Join-Path $packagerRoot "ref"
# Root for output folder, different name sorting since this is the End location
$outputEnd = Join-Path $packagerRoot "output"
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
# Creates an array of variables for each Path under $neededFiles
$neededFiles = @(
    $mMWORelPath
    $paWORelPath
    $maniPath
    $readPath
    $iconPath
    $newtPath
)
# Creates an array of variables for each Proj under $needProj
$neededProj = @(
    $mMWOLAPProj
    $paWOLAPProj
)

foreach($file in $neededFiles) {if ( -not(Test-Path $file)) {
    throw "Required file not found at $file"
}}