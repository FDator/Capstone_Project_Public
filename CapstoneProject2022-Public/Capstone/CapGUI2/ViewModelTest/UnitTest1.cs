using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ViewModel;

namespace ViewModelTest
{
    
    [TestClass]
    public class ViewModelTesting
    {
        ViewModelClass testVM = new ViewModelClass();
        
        [TestMethod]
        public void setFileTestASY()
        {
            testVM.setFile("ASYtest", ".ASY");
            
            Assert.AreEqual("ASYtest", testVM.importPath);
        }

        [TestMethod]
        public void setFileTestXML()
        {
            testVM.setFile("xmltest", ".xml");
            Assert.AreEqual("xmltest", testVM.recipePath);
        }

        [TestMethod]
        public void setFileTestUnsupported()
        {
            testVM.setFile("badFile", ".txt");
            Assert.IsNull(testVM.importPath);
            Assert.IsNull(testVM.recipePath);
        }

        [TestMethod]
        public void checkConversionReadyTest()
        {
            
            Assert.IsFalse(testVM.checkConversionReady());
        }

        [TestMethod]
        public void checkConversionReadyTestTrue()
        {
            testVM.setFile("ASYtest", ".ASY");
            testVM.setFile("xmltest", ".xml");
            Assert.IsTrue(testVM.checkConversionReady());
        }

        [TestMethod]
        public void changeStatusMessageTestReady()
        {
            testVM.setFile("ASYtest", ".ASY");
            testVM.setFile("xmltest", ".xml");
            testVM.changeStatusMessage();
            Assert.AreEqual("Ready to convert!", testVM.conversionProgress);
        }

        [TestMethod]
        public void changeStatusMessageTestNotReady()
        {
            testVM.changeStatusMessage();
            Assert.AreEqual("Please select all files necessary for conversion", testVM.conversionProgress);
        }

        [TestMethod]
        public void convertFileTest()
        {
            testVM.setFile("D:/School/Capstone/files/ScanCAD.ASY", ".ASY");
            testVM.setFile("D:/School/Capstone/files/country_data.xml", ".xml");
            testVM.convertFile("D:/School/Capstone/files");
            Assert.AreEqual("Conversion Done!", testVM.conversionProgress);
        }

        [TestMethod]
        public void convertFileTestFailure()
        {
            testVM.recipePath = "D:/School/Capstone/files/ScanCAD.ASY";
            testVM.setFile("D:/School/Capstone/files/country_data.xml", ".xml");
            testVM.convertFile("D:/School/Capstone/files");
            Assert.AreEqual("Error with converting the file", testVM.conversionProgress);
        }
    }
}