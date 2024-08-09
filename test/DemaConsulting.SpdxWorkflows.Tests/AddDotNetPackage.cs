namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddDotNetPackage : AddPackageTest
{
    [TestMethod, TestCategory("AnyOS")]
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
        Assert.AreEqual(".NET SDK", package.Name);
        Assert.AreEqual("MIT", package.ConcludedLicense);
        Assert.AreEqual("Copyright (c) .NET Foundation and Contributors", package.CopyrightText);
        Assert.AreEqual("8.0.301", package.Version);
        Assert.AreEqual("Organization: Microsoft Corporation", package.Supplier);
        Assert.AreEqual("Organization: .NET Foundation", package.Originator);
        Assert.AreEqual("https://dotnet.microsoft.com/", package.HomePage);
        Assert.AreEqual(
            "Core functionality needed to create .NET Core projects, that is shared between Visual Studio and CLI.",
            package.Summary);
    }
}