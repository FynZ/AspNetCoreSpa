#addin nuget:?package=Cake.Docker

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    DotNetCoreClean("./AspNetCoreSpa.sln");

    CleanDirectory("./publish");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./AspNetCoreSpa.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./AspNetCoreSpa.sln", new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    });
});

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
{
    var projects = GetFiles("./src/**/*.csproj");

    foreach (var project in projects)
    {
        var targetDirectory = project.GetFilenameWithoutExtension();
        CreateDirectory($"./publish/{targetDirectory}");
        DotNetCorePublish(project.FullPath, new DotNetCorePublishSettings
        {
            Configuration = configuration,
            OutputDirectory = $"./publish/{targetDirectory}",
            ArgumentCustomization = args => args.Append("--no-restore")
        });
        CopyFile($"./src/{targetDirectory}/Dockerfile", $"./publish/{targetDirectory}/Dockerfile");
    }
});

Task("Mount")
    .IsDependentOn("Publish")
    .Does(() =>
{
    DockerComposeUp(new DockerComposeUpSettings
    {
        Build = true,
        DetachedMode = true,
        ForceRecreate = true
    });
});
//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);