namespace PlaylistSyncLibFramework.Models
{
    public interface IPlaylistParser
    {
        PlaylistModel Parse(string path);
    }
}