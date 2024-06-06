namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddVsTestPackage : AddPackageTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void TestAddVsTestPackage()
    {
        var doc = RunAddPackageWorkflow(
            "AddVsTestPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-VSTest-17.10.0",
            "version=17.10.0");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-VSTest-17.10.0");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual("Visual Studio Test Platform", package.Name);
        Assert.AreEqual("MIT", package.ConcludedLicense);
        Assert.AreEqual("Copyright (c) Microsoft Corporation", package.CopyrightText);
        Assert.AreEqual("17.10.0", package.Version);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Supplier);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Originator);
        Assert.AreEqual("https://learn.microsoft.com/en-us/visualstudio/test/vstest-console-options", package.HomePage);
        Assert.AreEqual("VSTest.Console.exe is the command-line tool to run tests.", package.Summary);

        // Verify the PURL
        Assert.AreEqual(1, package.ExternalReferences.Length);
        Assert.AreEqual(SpdxModel.SpdxReferenceCategory.PackageManager, package.ExternalReferences[0].Category);
        Assert.AreEqual("purl", package.ExternalReferences[0].Type);
        Assert.AreEqual("pkg:github/microsoft/vstest@v17.10.0", package.ExternalReferences[0].Locator);
    }
}