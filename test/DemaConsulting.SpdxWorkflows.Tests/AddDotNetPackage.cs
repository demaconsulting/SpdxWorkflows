namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddDotNetPackage : AddPackageTest
{
    [TestMethod]
    public void TestAddDotNetPackage()
    {
        var doc = RunAddPackageWorkflow(
            "AddDotNetPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-DotNet-8.0.301",
            "version=8.0.301");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-DotNet-8.0.301");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual(".NET command-line interface.", package.Name);
        Assert.AreEqual("MIT", package.ConcludedLicense);
        Assert.AreEqual("Copyright (c) 2019 Microsoft", package.CopyrightText);
        Assert.AreEqual("8.0.301", package.Version);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Supplier);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Originator);
        Assert.AreEqual("https://dotnet.microsoft.com/en-us/", package.HomePage);
        Assert.AreEqual(
            ".NET is a free, open-source cross-platform framework for building applications and cloud services.",
            package.Summary);
    }
}