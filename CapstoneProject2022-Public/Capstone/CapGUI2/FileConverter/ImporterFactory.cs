using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    internal class ImporterFactory
    {
        public IFileImporter createFileImporter(FileInfo import_filePath, FileInfo recipe_filePath, string output_filePath, string output_name)
        {
            if (import_filePath.Extension == ".ASY")
                return new CadFileType(import_filePath.FullName, recipe_filePath.FullName, output_filePath, output_name);
            else 
                throw new ArgumentException("Unhandled File Type");
        }
    }
}
