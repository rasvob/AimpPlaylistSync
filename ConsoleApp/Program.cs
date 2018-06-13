using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistSyncLibFramework;
using PlaylistSyncLibFramework.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AimpPlaylistParser parser = new AimpPlaylistParser();
            PlaylistModel model = parser.Parse(@"D:\MP3\MYxPLAYLIST.aimppl4");
        }
    }
}
