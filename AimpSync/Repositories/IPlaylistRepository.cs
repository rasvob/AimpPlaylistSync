using System.Collections.Generic;
using PlaylistSyncLibFramework.Models;

namespace AimpSync.Repositories
{
    public interface IPlaylistRepository
    {
        PlaylistModel GetModel(string path);
        IEnumerable<SongModel> GetSongsById(PlaylistModel playlist, int[] ids);
        SongModel GetSongById(PlaylistModel playlist, int id);
    }
}