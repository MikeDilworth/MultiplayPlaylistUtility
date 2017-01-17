using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSEInterface.Constants
{
    public class ContentTypes
    {
        public const string MSE_Directory_Collection = "application/atom+xml;type=feed";
        public const string Directory = "application/atom+xml;type=entry";
        public const string Playlist = "application/vnd.vizrt.payload+xml;type=playlist";
        public const string VDF_Document = "application/vnd.vizrt.payload+xml;type=element";
        public const string Text_Plain = "text/plain";
        public const string PlaylistActivation = "application/vnd.vizrt.playlistactivation+xml";
        // Approach to grouping modified by Viz 08/16/2016
        // public const string Group_Creation = "application/atom+xml;type=feed";
        public const string Group_Creation = "application/atom+xml;type=entry";
    }
}
