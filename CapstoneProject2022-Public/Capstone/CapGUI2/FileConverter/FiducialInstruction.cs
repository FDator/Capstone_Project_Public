using System.Xml.Linq;

namespace FileConverter
{
    internal class FiducialInstruction
    {
        //FidBaseData Start
        //Light1Settings Start
        public string? LightType { get; set; }
        public string? Light1LevelPercent { get; set; }
        public string? Light2LevelPercent { get; set; }
        public string? Light3LevelPercent { get; set; }
        public string? Light4LevelPercent { get; set; }
        public string? Light5LevelPercent { get; set; }
        //Light1Settings End
        string? CameraGain { get; set; }
        string? Name { get; set; }
        string? FidID { get; set; }
        string? RunTimeFidID { get; set; }
        string? ModelID { get; set; }
        string? FidType { get; set; }
        //ModelOrigin Start
        string? ModelOriginX { get; set; }
        string? ModelOriginY { get; set; }    
        //ModelOrigin End
        public string? ExpectedXLocMM { get; set; }
        public string? ExpectedYLocMM { get; set; }
        string? ExpectedZLocMM { get; set; }
        string? SettlingTime { get; set; }
        string? MinConfidence { get; set; }
        string? SearchAreaWidth { get; set; }     
        string? SearchAreaHeight { get; set; }
        //ModelImageObj Start
        string? Width { get; set; }
        string? Height { get; set; }
        string? CreatedAtResolution { get; set; }
        //OriginPoint Start
        string? OriginPointX { get; set; }
        string? OriginPointY { get; set; }
        //OriginPoint End
        //ModelImageObj Start
        string? CompositeModelImageObj { get; set; }
        bool? IsSkipFidProcessing { get; set; }
        bool? IsSkipMark { get; set; }
        string? LocationTolerance { get; set; }
        string? MinScore { get; set; }
        bool? ModelUseRotation { get; set; }
        bool? SubPixel { get; set; }
        string? SubPixResolution { get; set; }
        string? LocalSearch { get; set; }
        string? MinScale { get; set; }
        string? MaxScale { get; set; }
        //CircularData Start
        string? ExpectedDiameter { get; set; }
        string? DiameterTolerance { get; set; }
        string? FoundDiameter { get; set; }
        bool? UseFoundDiameterAsModel    { get; set; }
        string? SyntheticDesc { get; set; }
        string? ColorType { get; set; }
        bool? IsDiameterToleranceCheckEnabled { get; set; }
        //CircularData End
        //FidBaseData End

        public XElement GenerateElement()
        {
            XElement elmt = new XElement("Root",
                new XElement("Light1Setting",
                    new XElement("LightType", this.LightType),
                    new XElement("Light1LevelPercent", this.Light1LevelPercent),
                    new XElement("Light2LevelPercent", this.Light2LevelPercent),
                    new XElement("Light3LevelPercent", this.Light3LevelPercent),
                    new XElement("Light4LevelPercent", this.Light4LevelPercent),
                    new XElement("Light5LevelPercent", this.Light5LevelPercent)
                    ),
            new XElement("CameraGain", this.CameraGain),
            new XElement("Name", this.Name),
            new XElement("FidID", this.FidID),
            new XElement("RunTimeFidID", this.RunTimeFidID),
            new XElement("ModelID", this.ModelID),
            new XElement("FidType", this.FidType),
            new XElement("ModelOrigin",
                    new XElement("X", this.ModelOriginX),
                    new XElement("Y", this.ModelOriginY)
                    ),
            new XElement("ExpectedXLocMM", this.ExpectedXLocMM),
            new XElement("ExpectedYLocMM", this.ExpectedYLocMM),
            new XElement("ExpectedZLocMM", this.ExpectedZLocMM),
            new XElement("SettlingTime", this.SettlingTime),
            new XElement("MinConfidence", this.MinConfidence),
            new XElement("SearchAreaWidth", this.SearchAreaWidth),
            new XElement("SearchAreaHeight", this.SearchAreaHeight),
            new XElement("ModelImageObj",
                    new XElement("Width", this.Width),
                    new XElement("Height", this.Height),
                    new XElement("CreatedAtResolution", this.CreatedAtResolution),
                    new XElement("OriginPoint",
                        new XElement("X", this.OriginPointX),
                        new XElement("Y", this.OriginPointY)
                        )
                    ),
            new XElement("CompositeModelImageObj", this.CompositeModelImageObj),
            new XElement("IsSkipFidProcessing", this.IsSkipFidProcessing),
            new XElement("IsSkipMark", this.IsSkipMark),
            new XElement("LocationTolerance", this.LocationTolerance),
            new XElement("MinScore", this.MinScore),
            new XElement("ModelUseRotation", this.ModelUseRotation),
            new XElement("SubPixel", this.SubPixel),
            new XElement("SubPixResolution", this.SubPixResolution),
            new XElement("LocalSearch", this.LocalSearch),
            new XElement("MinScale", this.MinScale),
            new XElement("MaxScale", this.MaxScale),
            new XElement("CircularData",
                    new XElement("ExpectedDiameter", this.ExpectedDiameter),
                    new XElement("DiameterTolerance", this.DiameterTolerance),
                    new XElement("FoundDiameter", this.FoundDiameter),
                    new XElement("UseFoundDiameterAsModel", this.UseFoundDiameterAsModel),
                    new XElement("SyntheticDesc", this.SyntheticDesc),
                    new XElement("ColorType", this.ColorType),
                    new XElement("IsDiameterToleranceCheckEnabled", this.IsDiameterToleranceCheckEnabled)
                    )
            ); 
            return elmt;
        }
    }
}
