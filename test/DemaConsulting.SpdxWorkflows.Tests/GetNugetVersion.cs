using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public partial class GetNugetVersion : WorkflowTest
{
    [TestMethod, TestCategory("Windows")]
    public void TestGetNugetVersion()
    {
        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetNugetVersion.yaml",
            "--verbose");

        // Verify we found a valid Nuget version
        Assert.AreEqual(0, exitCode);
        Assert.MatchesRegex(VersionRegex(), output);
    }

    [GeneratedRegex(@"version = \d+\.\d+\.\d+")]
    private static partial Regex VersionRegex();
}