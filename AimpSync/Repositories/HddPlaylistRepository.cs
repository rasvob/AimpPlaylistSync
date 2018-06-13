using System.Collections.Generic;
using System.IO;
using System.Linq;
using PlaylistSyncLibFramework;
using PlaylistSyncLibFramework.Models;

namespace AimpSync.Repositories
{
    public class HddPlaylistRepository: IPlaylistRepository
    {
        public IPlaylistParser Parser { get; set; }

        public HddPlaylistRepository()
        {
            Parser = new AimpPlaylistParser();
        }


        public PlaylistModel GetModel(string path)
        {
            return Parser.Parse(path);
        }

        public IEnumerable<SongModel> GetSongsById(PlaylistModel playlist, int[] ids)
        {
            return playlist.Songs.Where(t => ids.Any(s => s == t.Id));
        }

        public SongModel GetSongById(PlaylistModel playlist, int id)
        {
            return playlist.Songs.FirstOrDefault(t => t.Id == id);
        }
    }
}