using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSEInterface.DataModel
{
    //Class used to hold the the title and self/alternate links for a show object
    public class ShowObject
    {
        public string title { get; set; }
        public string selfLink { get; set; }
        public string alternateLink { get; set; }
        public string relatedLink { get; set; }
    }
}
