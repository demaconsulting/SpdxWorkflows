namespace DemaConsulting.SpdxWorkflows.Tests;

[TestClass]
public class AddClangPackage : AddPackageTest
{
    [TestMethod, TestCategory("AnyOS")]
    public void AddClangPackage_WithValidParameters_AddsPackageToDocument()
    {
        var doc = RunAddPackageWorkflow(
            "AddClangPackage.yaml",
            "spdx=spdx.json",
            "id=SPDXRef-Package-Clang-16.0.0",
            "version=16.0.0");

        // Verify the package was added
        var package = Array.Find(doc.Packages, p => p.Id == "SPDXRef-Package-Clang-16.0.0");
        Assert.IsNotNull(package);

        // Verify the information
        Assert.AreEqual("Clang", package.Name);
        Assert.AreEqual("Apache-2.0 WITH LLVM-exception", package.ConcludedLicense);
        Assert.AreEqual("Copyright (c) LLVM Project contributors", package.CopyrightText);
        Assert.AreEqual("16.0.0", package.Version);
        Assert.AreEqual("Organization: LLVM Project", package.Supplier);
        Assert.AreEqual("Organization: LLVM Project", package.Originator);
        Assert.AreEqual("https://clang.llvm.org/", package.HomePage);
        Assert.AreEqual(
            "Clang is a C, C++, Objective-C, and Objective-C++ compiler front end built on the LLVM compiler infrastructure, commonly used for cross-compiling embedded targets.",
            package.Summary);

        // Verify the PURL
        Assert.HasCount(1, package.ExternalReferences);
        Assert.AreEqual(SpdxModel.SpdxReferenceCategory.PackageManager, package.ExternalReferences[0].Category);
        Assert.AreEqual("purl", package.ExternalReferences[0].Type);
        Assert.AreEqual("pkg:github/llvm/llvm-project@llvmorg-16.0.0", package.ExternalReferences[0].Locator);
    }
}
