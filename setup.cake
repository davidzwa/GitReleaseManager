#load nuget:https://ci.appveyor.com/nuget/cake-recipe?package=Cake.Recipe&version=0.3.0-unstable0403

Environment.SetVariableNames(githubUserNameVariable: "GITTOOLS_GITHUB_USERNAME",
                            githubPasswordVariable: "GITTOOLS_GITHUB_PASSWORD");

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./Source",
                            title: "GitReleaseManager",
                            repositoryOwner: "GitTools",
                            repositoryName: "GitReleaseManager",
                            appVeyorAccountName: "GitTools",
                            testFilePattern: "/**/*.Tests.dll",
                            shouldRunGitVersion: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                                BuildParameters.RootDirectoryPath + "/Source/GitReleaseManager.Tests/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[Octokit]* -[YamlDotNet]* -[AlphaFS]* -[ApprovalTests]* -[ApprovalUtilities]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");
Build.Run();
