using System.Collections.Generic;

namespace PlaylistSyncLibFramework.Models
{
    public class PlaylistModel
    {
        public string Id { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public List<SongModel> Songs { get; set; } = new List<SongModel>();
    }
}