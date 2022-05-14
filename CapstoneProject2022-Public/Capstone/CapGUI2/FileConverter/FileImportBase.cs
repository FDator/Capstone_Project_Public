using System.Xml.Linq;

namespace FileConverter
{
    internal abstract class FileImportBase : IFileImporter
    {
        public List<ExtractedCoord> Instructions { get; set; }
        public string ImportPath { get; }
        private string RecipePath;
        private string OutputPath;
        private string OutputName;

        private string xsdNameSpaceName;
        private string xsiNameSpaceName;
        XNamespace xsd;
        XNamespace xsi;
        public FileImportBase(string import_filePath, string recipe_filePath, string output_filePath, string output_name)
        {
            Instructions = new List<ExtractedCoord>();
            ImportPath = import_filePath;
            RecipePath = recipe_filePath;
            OutputPath = output_filePath;
            OutputName = output_name;
        }
        public bool WriteInstructions()
        {
            
            List<ExtractedCoord> Fids = new List<ExtractedCoord>();
            List<ExtractedCoord> Dots = new List<ExtractedCoord>(); 
            foreach (ExtractedCoord coord in Instructions)
            {
                if (coord.Type == "F")
                    Fids.Add(coord);
                else if(coord.Type == "ADM")
                    Dots.Add(coord);

            }
            XElement FidTree = InitDoc("Fiducial", "Fids");
            FidTree = WriteFiducials(FidTree, Fids);
            FidTree.Save(OutputPath + "/" + "FiducialList.xml");

            XElement DotTree = InitDoc("Dot", "Instructions");
            DotTree = WriteDots(DotTree, Dots);
            DotTree.Save(OutputPath + "/" + "DotList.xml");

            XElement eTree;
            var xDoc = XDocument.Load(RecipePath);
            IEnumerable<XElement> FidList = xDoc.Elements();
            FidList = SearchForElements(FidList, "ModelOrigin");

            int instructionCounter = 0;
            foreach (XElement Fid in FidList)
            {
                //System.Diagnostics.Debug.WriteLine("Fid Element Before: " + Fid);
                Fid.Element("X").Value = Instructions.ElementAt(instructionCounter).X.ToString();
                Fid.Element("Y").Value = Instructions.ElementAt(instructionCounter).Y.ToString();
                //System.Diagnostics.Debug.WriteLine("Fid Element After: " + Fid);
                instructionCounter++;
            }
            xDoc.Save(OutputPath + "/" + OutputName + ".xml");

            return true;
        }

        private IEnumerable<XElement> SearchForElements(IEnumerable<XElement> List, string elmtName)
        {
            while (List.Elements(elmtName).Count() == 0)
            {
                List = List.Elements();
            }
            List = List.Elements(elmtName);
            return List;
        }

        private XElement WriteFiducials(XElement DocRoot, List<ExtractedCoord> List)
        {
            XElement newRoot = (from e in DocRoot.Descendants("Fids")
                                select e).First();

            XElement FidRoot;
            FiducialInstruction fiducialInstruction = new FiducialInstruction();
            foreach (ExtractedCoord coord in List)
            {
                fiducialInstruction.ExpectedXLocMM = coord.X.ToString();
                fiducialInstruction.ExpectedYLocMM = coord.Y.ToString();
                FidRoot = new XElement("FidBaseData", new XAttribute(xsi + "type", "CircleAreaFidData"));
                FidRoot.Add(fiducialInstruction.GenerateElement().Elements());
                newRoot.Add(FidRoot);
            }

            return DocRoot;
        }

        private XElement WriteDots(XElement DocRoot, List<ExtractedCoord> List)
        {
            XElement newRoot = (from e in DocRoot.Descendants("Instructions") select e).First();

            //newRoot.Element("RecipeInstruction").Element("XYLocation");
            XElement Dotroot; 
            DotInstruction dotInstruction = new DotInstruction();
            
            foreach(ExtractedCoord coord in List)
            {
                
                dotInstruction.X = coord.X.ToString();
                dotInstruction.Y = coord.Y.ToString();
                dotInstruction.XLocation = coord.X.ToString();
                dotInstruction.YLocation = coord.Y.ToString();
                Dotroot = new XElement("RecipeInstruction", new XAttribute(xsi + "type", "DotInstruction"));
                Dotroot.Add(dotInstruction.GenerateElement().Elements());
                newRoot.Add(Dotroot);

            }

            return DocRoot;
        }

        private XElement InitDoc(string DocRootName, string NodeRootName)
        {
            xsdNameSpaceName = "http://www.w3.org/2001/XMLSchema";
            xsiNameSpaceName = "http://www.w3.org/2001/XMLSchema-instance";
            xsd = XNamespace.Get(xsdNameSpaceName);
            xsi = XNamespace.Get(xsiNameSpaceName);

            XElement elmt = new XElement(DocRootName + "List",
                new XAttribute(XNamespace.Xmlns + "xsd", xsdNameSpaceName),
                new XAttribute(XNamespace.Xmlns + "xsi", xsiNameSpaceName),
                new XElement(NodeRootName)
                );

            return elmt;
        }

        //update the Instructions list
        public abstract bool ImportFile();
    }
}

