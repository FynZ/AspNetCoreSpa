#addin nuget:?package=Cake.Docker
#addin nuget:?package=Cake.Npm


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

        // copy Dockerfile
        CopyFile($"./src/{targetDirectory}/Dockerfile", $"./publish/{targetDirectory}/Dockerfile");
    }
});

Task("BuildFront")
    .Does(() =>
{
    // NpmInstall(s => s.FromPath("./src/AspNetCoreSpa.Front/"));
    // NpmRunScript(s => s.FromPath("./src/AspNetCoreSpa.Front/"));
    NpmInstall(s => s.FromPath("./src/AspNetCoreSpa.Front/"));
    NpmRunScript("generate", s => s.FromPath("./src/AspNetCoreSpa.Front/"));
});

Task("PublishFront")
    .IsDependentOn("BuildFront")
    .Does(() =>
{
    var projects = GetFiles("./src/*/package.json");

    foreach (var project in projects)
    {
        var targetDirectory = project.GetDirectory().GetDirectoryName();
        Information($"Directory is : {targetDirectory}");
        CreateDirectory($"./publish/{targetDirectory}");

        // copy root files
        var files = GetFiles($"./src/{targetDirectory}/dist/*");
        CopyFiles(files, $"./publish/{targetDirectory}");

        // copy directories
        var directories = GetDirectories($"./src/{targetDirectory}/dist/*");
        foreach (var directory in directories)
        {
            CopyDirectory(directory, $"./publish/{targetDirectory}/{directory.GetDirectoryName()}");
        }

        // copy Dockerfile
        CopyFile($"./src/{targetDirectory}/Dockerfile", $"./publish/{targetDirectory}/Dockerfile");
    }
});

Task("Mount")
    .IsDependentOn("Publish")
    .IsDependentOn("PublishFront")
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