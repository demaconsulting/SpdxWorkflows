using System.Text.RegularExpressions;

namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class GetNugetPackagePath : WorkflowTest
{
    [TestMethod, TestCategory("Windows")]
    public void TestGetNugetPackagePath()
    {
        // Run the workflow
        var exitCode = RunWorkflow(
            out var output,
            "GetNugetPackagePath.yaml",
            "package=demaconsulting.spdxmodel",
            "version=0.1.0",
            "--verbose");

        // Verify we found the package path
        Assert.AreEqual(0, exitCode);
        Assert.IsTrue(Regex.IsMatch(output, @"path = .+demaconsulting.spdxmodel/0.1.0"));
    }
}