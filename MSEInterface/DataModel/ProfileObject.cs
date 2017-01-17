using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSEInterface.DataModel
{
    //Class used to hold metadata for a Trio profile 
    public class ProfileObject
    {
        public string title { get; set; }
        public string readLink { get; set; }
        public string cueLink { get; set; }
        public string takeLink { get; set; }
        public string takeOutLink { get; set; }
        public string updateLink { get; set; }
    }
}
