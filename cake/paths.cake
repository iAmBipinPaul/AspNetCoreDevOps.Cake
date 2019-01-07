public static class Paths
{
    public static FilePath SolutionFile => "AspNetCoreDevOps.sln";
    public static FilePath ProjectFile => "src/AspNetCoreDevOps.Api/AspNetCoreDevOps.Api.csproj";
    public static FilePath TestProjectFile => "test/AspNetCoreDevOps.Controllers.Tests/AspNetCoreDevOps.Controllers.Tests.csproj";
}

public static FilePath Combine(DirectoryPath directory, FilePath file)
{
    return directory.CombineWithFilePath(file);
}
