#load cake/paths.cake
#addin "Cake.Docker"

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");




Task("DockerCompose")
.Does(() => {

   DockerComposeUp(new DockerComposeUpSettings{ForceRecreate=true,DetachedMode=true,Build=true});
   Information("Hello Cake!");
});



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
    .IsDependentOn("DockerCompose")
    .IsDependentOn("Restore")    
    .Does(() =>
{
    DotNetCoreTest(Paths.TestProjectFile.FullPath);
});
RunTarget(target);
