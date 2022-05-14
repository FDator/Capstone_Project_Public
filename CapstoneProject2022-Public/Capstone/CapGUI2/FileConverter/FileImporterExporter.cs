using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    public class FileImporterExporter
    {
        public bool extractData(string import_filePath, string recipe_filePath, string output_filePath, string output_name = "Output")
        {
            try
            {
                FileInfo importFile = new FileInfo(import_filePath);
                FileInfo recipeFile = new FileInfo(recipe_filePath);
                if (!importFile.Exists)
                    throw new FileNotFoundException("Import File Does Not Exist");
                else if (!recipeFile.Exists)
                    throw new FileNotFoundException("Recipe File Does Not Exist");

                ImporterFactory importerFactory = new ImporterFactory();
                IFileImporter newFile = importerFactory.createFileImporter(importFile, recipeFile, output_filePath, output_name);
                return newFile.ImportFile();
            }
            catch(FormatException e) { System.Diagnostics.Debug.WriteLine(e.Message); return false; }
            catch (ArgumentException e) { System.Diagnostics.Debug.WriteLine(e.Message); return false; }             
            catch (FileNotFoundException e) { System.Diagnostics.Debug.WriteLine(e.Message); return false; }           
        }
    }
}
