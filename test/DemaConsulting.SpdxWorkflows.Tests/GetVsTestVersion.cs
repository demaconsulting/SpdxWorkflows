using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public partial class GetVsTestVersion : WorkflowTest
{
    [TestMethod, TestCategory("Windows")]
    public void TestGetVsTestVersion()
    {
        // Use vswhere to find VSTest
        Runner.Run(
            out var vstest,
            "dotnet",
            "vswhere",
            "-latest",
            "-requires",
            "Microsoft.VisualStudio.Workload.ManagedDesktop",
            "-find",
            @"**\TestPlatform\vstest.console.exe");

        // Clean up the path
        vstest = vstest.Trim();

        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetVsTestVersion.yaml",
            $"vstest={vstest}",
            "--verbose");

        // Verify we found a valid VSTest version
        Assert.AreEqual(0, exitCode);
        Assert.MatchesRegex(VersionRegex(), output);
    }

    [GeneratedRegex(@"version = \d+\.\d+\.\d+")]
    private static partial Regex VersionRegex();
}