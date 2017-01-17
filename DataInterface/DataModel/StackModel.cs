using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterface.DataModel
{
    public class StackModel
    {
        public Double ixStackID { get; set; }
        public string StackName { get; set; }
        public Int16 StackType { get; set; }
        public string ShowName { get; set; }
        public Int16 ConceptID { get; set; }
        public string ConceptName { get; set; }
        public string Notes { get; set; }
    }
}
