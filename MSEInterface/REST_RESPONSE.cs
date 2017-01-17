using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSEInterface
{
    /// <summary>
    /// Class for REST client call response
    /// </summary>
    public class REST_RESPONSE
    {
        //Class used to hold the response from the Media Sequencer
        public string xmlResponse { get; set; }
        public string headerLocation { get; set; }
        public string selfLink { get; set; }
        public string alternateLink { get; set; }
        public string downLink { get; set; }
    }
}
