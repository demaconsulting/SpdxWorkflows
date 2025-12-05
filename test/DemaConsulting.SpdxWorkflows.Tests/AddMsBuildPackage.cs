namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddMsBuildPackage : AddPackageTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void TestAddMsBuildPackage()
    {
        var doc = RunAddPackageWorkflow(
            "AddMsBuildPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-MSBuild-17.10.4",
            "version=17.10.4");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-MSBuild-17.10.4");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual("Microsoft Build Engine", package.Name);
        Assert.AreEqual("MIT", package.ConcludedLicense);
        Assert.AreEqual("Copyright (c) .NET Foundation and Contributors", package.CopyrightText);
        Assert.AreEqual("17.10.4", package.Version);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Supplier);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Originator);
        Assert.AreEqual("https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild", package.HomePage);
        Assert.AreEqual("The Microsoft Build Engine is a platform for building applications.", package.Summary);

        // Verify the PURL
        Assert.HasCount(1, package.ExternalReferences);
        Assert.AreEqual(SpdxModel.SpdxReferenceCategory.PackageManager, package.ExternalReferences[0].Category);
        Assert.AreEqual("purl", package.ExternalReferences[0].Type);
        Assert.AreEqual("pkg:github/dotnet/msbuild@v17.10.4", package.ExternalReferences[0].Locator);
    }
}