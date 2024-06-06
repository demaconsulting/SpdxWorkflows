using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class GetMsBuildVersion : WorkflowTest
{
    [TestMethod, TestCategory("Windows")]
    public void TestGetMsBuildVersion()
    {
        // Use vswhere to find MSBuild
        Runner.Run(
            out var msbuild,
            "dotnet",
            "vswhere",
            "-latest",
            "-requires",
            "Microsoft.Component.MSBuild",
            "-find",
            @"MSBuild\**\Bin\MSBuild.exe");

        // Clean up the path
        msbuild = msbuild.Trim();

        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetMsBuildVersion.yaml",
            $"msbuild={msbuild}",
            "--verbose");

        // Verify we found a valid MSBuild version
        Assert.AreEqual(0, exitCode);
        Assert.IsTrue(Regex.IsMatch(output, @"version = \d+\.\d+\.\d+"));
    }
}