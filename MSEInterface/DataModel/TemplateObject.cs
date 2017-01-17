using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSEInterface.DataModel
{
    //Class used to hold the the title and self/alternate links for a template object
    public class TemplateObject
    {
        public string title { get; set; }
        public string selfLink { get; set; }
        public string alternateLink { get; set; }
    }
}
