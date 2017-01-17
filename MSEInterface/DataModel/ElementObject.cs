using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSEInterface.DataModel
{
    //Class used to hold the the title and self/alternate/related links for an element object
    public class ElementObject
    {
        public string id { get; set; }
        public string selfLink { get; set; }
        public string alternateLink { get; set; }
        public string relatedLink { get; set; }
    }
}
