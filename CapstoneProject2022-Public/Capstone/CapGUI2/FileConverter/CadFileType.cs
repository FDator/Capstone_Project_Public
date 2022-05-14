namespace FileConverter
{
    internal class CadFileType : FileImportBase
    {
        public CadFileType(string import_filePath, string recipe_filePath, string output_filePath, string output_name) :
            base(import_filePath, recipe_filePath, output_filePath, output_name)
        { }
        public override bool ImportFile()
        {
            string[] lines = File.ReadAllLines(this.ImportPath).Skip(1).ToArray();
            if (lines.Length == 0)
                throw new FormatException("Imported File is Empty");

            int wordCounter = 0;
            bool foundInfo = false;
            var prevWord = "";
            ExtractedCoord element = new ExtractedCoord();

            foreach (string line in lines)
            {
                foreach (var word in line.Split(' '))
                {
                    if (!word.Equals(""))
                    {
                        if (word.Equals("F") || word.Equals("ADM"))
                        {
                            if (prevWord.Equals("ADM"))
                                prevWord = "";
                            else
                            {
                                element.Type = word;

                                foundInfo = true;
                                prevWord = word;
                                wordCounter++;


                            }
                        }
                        else wordCounter++;

                        if (foundInfo)
                        {
                            switch (wordCounter)
                            {
                                case 3:
                                    element.X = int.Parse(word, System.Globalization.NumberStyles.AllowLeadingSign);
                                    break;
                                case 4:
                                    element.Y = int.Parse(word, System.Globalization.NumberStyles.AllowLeadingSign);
                                    Instructions.Add(element);

                                    wordCounter = 0;
                                    foundInfo = false;
                                    break;
                            }
                        }
                        else wordCounter = 0;
                    }
                }
            }
            
            return WriteInstructions();
        }
    }
}
