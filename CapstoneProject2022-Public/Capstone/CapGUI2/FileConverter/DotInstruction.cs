using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileConverter
{
    internal class DotInstruction
    {
        public string? Type {get; set;}
        public string? PatternNodeId {get; set;}
        public string? InstructionId {get; set;}
        public string? Breakpoint { get; set;}
        public bool? MoveToSafeZBeforeMove {get; set;}
        public bool? IsSelected {get; set;}
        public bool? IsEnabled {get; set;}
        public bool? IsPassBlockChild { get; set;}
        public string? Applicator { get; set;}
        public string? LibraryItemId { get; set;}
        public bool? IsWeightControlOverrideEnabled {get; set;}
        public string? OverrideWeight { get; set;}

        //XYLocation element containing x,y coordinates
        public string? XYLocation { get; set;}
        public string? X { get; set;}
        public string? Y { get; set;}
        //End of XY Location

        public string? XLocation { get; set;}
        public string? YLocation {get; set;}
        public string? SelectDotType {get; set;}
        public string? DotDispenseStrategy { get; set;}

        public XElement GenerateElement()
        {
            XElement element = new XElement("Root",
                new XElement("Type", this.Type),
                new XElement("PatternNodeId", this.PatternNodeId),
                new XElement("InstructionId", this.InstructionId),
                new XElement("Breakpoint", this.Breakpoint),
                new XElement("MoveToSafeBeforeMove", this.MoveToSafeZBeforeMove),
                new XElement("IsSelected", this.IsSelected),
                new XElement("IsEnabled", this.IsEnabled),
                new XElement("IsPassBlockChild", this.IsPassBlockChild),
                new XElement("Applicator", this.Applicator),
                new XElement("LibraryItemId", this.LibraryItemId),
                new XElement("IsWeightControlOverrideEnabled", this.IsWeightControlOverrideEnabled),
                new XElement("OverrideWeight", this.OverrideWeight),
                new XElement("XYLocation",
                    new XElement("X", this.X),
                    new XElement("Y", this.Y)
                ),
                new XElement("XLocation", this.X),
                new XElement("YLocation", this.Y),
                new XElement("SelectDotType", this.SelectDotType),
                new XElement("DotDispenseStrategy", this.DotDispenseStrategy)
                );

            return element;


        }

    }
}
