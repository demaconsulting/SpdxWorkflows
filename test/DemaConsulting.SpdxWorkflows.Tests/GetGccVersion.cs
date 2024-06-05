using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class GetGccVersion : WorkflowTest
{
    [TestMethod, TestCategory("Linux")]
    public void TestGetGccVersion()
    {
        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetGccVersion.yaml",
            "--verbose");

        // Verify we found a valid GCC version
        Assert.AreEqual(0, exitCode);
        Assert.IsTrue(Regex.IsMatch(output, @"version = \d+\.\d+"));
    }
}