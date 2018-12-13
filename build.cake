#load cake/paths.cake

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore(Paths.SolutionFile.FullPath);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuild(
        Paths.ProjectFile.FullPath,
        new DotNetCoreBuildSettings
        {
            Configuration = configuration
        });
});
Task("Test")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreTest(Paths.TestProjectFile.FullPath);
});
RunTarget(target);
