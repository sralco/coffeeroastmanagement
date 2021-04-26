#tool nuget:?package=GitVersion.CommandLine&version=5.6.8
#addin nuget:?package=Cake.Docker&version=1.0.0

var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");

var SoftwareVersionComplete = GitVersion();

// version information
var SoftwareVersion = SoftwareVersionComplete.FullSemVer;

// docker secrets
var DockerUser = "mb221";
var DockerSecret = "c5030f45-d1ce-4709-acfb-d1ca66f93dff";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("ShowVersion")
    .Does(() =>
{
    Information("Build software version: " + SoftwareVersion);
});

Task("Clean")
    .Description("Clean binary directories")
    .Does(() =>
{
    CleanDirectory($"./CoffeeRoastManagement/Server/bin/{configuration}");
    CleanDirectory($"./CoffeeRoastManagement/Server/obj/{configuration}");
    CleanDirectory($"./CoffeeRoastManagement/Client/bin/{configuration}");
    CleanDirectory($"./CoffeeRoastManagement/Client/obj/{configuration}");
    CleanDirectory($"./CoffeeRoastManagement/Shared/bin/{configuration}");
    CleanDirectory($"./CoffeeRoastManagement/Shared/obj/{configuration}");

});

Task("Build")
    .Description("Build solution.")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./CoffeeRoastManagement.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"-p:Version={SoftwareVersion}")
    });
});

Task("Publish")
    .Description("Publish solution framework dependent.")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCorePublish("./CoffeeRoastManagement/Server/CoffeeRoastManagement.Server.csproj", new DotNetCorePublishSettings
    {
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"-p:Version={SoftwareVersion}")
    });
});

Task("DockerLogin")
    .Does(() =>
{
    DockerLogin(DockerUser, DockerSecret);
});

Task("Docker-Image-Arm32v7")
    .Description("Build arm32v7 image and set manifest accordingly")
    .IsDependentOn("Publish")
    .IsDependentOn("DockerLogin")
    .Does(() =>
{
    var settings = new DockerImageBuildSettings()
    {
        Tag = new string[] { $"mb221/coffeeroastmanagement:{SoftwareVersion}-arm32v7" },
        BuildArg = new string[] { "ARCH=arm32v7" },
        File = "./CoffeeRoastManagement/Server/Dockerfile.arm32v7",
    };
    DockerBuild(settings, "./CoffeeRoastManagement/Server");
    DockerPush($"mb221/coffeeroastmanagement:{SoftwareVersion}-arm32v7");
});

Task("Docker-Image-Amd64")
    .Description("Build Amd64 image and set manifest accordingly")
    .IsDependentOn("Publish")
    .IsDependentOn("DockerLogin")
    .Does(() =>
{
    var settings = new DockerImageBuildSettings()
    {
        Tag = new string[] { $"mb221/coffeeroastmanagement:{SoftwareVersion}-amd64" },
        BuildArg = new string[] { "ARCH=amd64" },
        File = "./CoffeeRoastManagement/Server/Dockerfile.amd64",
    };
    DockerBuild(settings, "./CoffeeRoastManagement/Server");
    DockerPush($"mb221/coffeeroastmanagement:{SoftwareVersion}-amd64");
});

Task("Docker-Manifest")
    .Description("Build docker manifest for all architectures.")
    .IsDependentOn("Docker-Image-Arm32v7")
    .IsDependentOn("Docker-Image-Amd64")
    .Does(() =>
{
    var settings = new DockerManifestCreateSettings {
        Amend = true,
    };
    var manifestlist = $"mb221/coffeeroastmanagement:{SoftwareVersion}";
    string manifest =  $"mb221/coffeeroastmanagement:{SoftwareVersion}-arm32v7";
    string[] manifests = new string[] { 
        $"mb221/coffeeroastmanagement:{SoftwareVersion}-amd64"
    };
    DockerManifestCreate(settings, manifestlist, manifest, manifests);
    DockerManifestPush(manifestlist);
});


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
