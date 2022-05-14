using NUnit.Framework;
using FileConverter;
using System;

namespace FileConvertTest
{
    public class Tests
    { 
        FileImporterExporter ImportFileType = new FileImporterExporter();

        [SetUp]
        public void Setup()
        {
        }
        
        //[Test]
        public void TestExtractDataWithCorrectFiles()
        {
            string outputPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles";
            string cadPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/ScanCAD.ASY";
            string recipePath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/CANVAS_Recipe.xml";
            Assert.True(ImportFileType.extractData(cadPath, recipePath, outputPath));
        }
        
        //[Test]
        public void TestExtractDataWithEmptyImport()
        {
            string outputPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles";
            string cadPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/EmptyScanCAD.ASY";
            string recipePath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/country_data.xml";
            Assert.False(ImportFileType.extractData(cadPath, recipePath, outputPath));
        }

        //[Test]
        public void TestExtractDataWithWrongImport()
        {
            string outputPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles";
            string cadPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/country_data.xml";
            string recipePath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/country_data.xml";
            Console.WriteLine("Should throw unhandled file exception");
            Assert.False(ImportFileType.extractData(cadPath, recipePath, outputPath));
        }

        //[Test]
        public void TestExtractDataWithEmptyStrings()
        {
            string outputPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles";
            string cadPath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/ScanCAD.ASY";
            string recipePath = "C:/Users/Adrian/Desktop/CapstoneTestFiles/";

            Assert.False(ImportFileType.extractData(cadPath, recipePath, outputPath));
        }

        //[Test]
        public void TestExtractDataWithNoRecipe()
        {
            string outputPath = "";
            string cadPath = "";
            string recipePath = "";

            Assert.False(ImportFileType.extractData(cadPath, recipePath, outputPath));
        }
 
    }
}