using System;
using System.IO;
using System.Text.RegularExpressions;
using PlaylistSyncLibFramework.Models;

namespace PlaylistSyncLibFramework
{
    public class AimpPlaylistParser: IPlaylistParser
    {
        public PlaylistModel Parse(string path)
        {
            var res = new PlaylistModel();
            string[] lines = File.ReadAllLines(path);

            Regex idRx = new Regex("{(?<id>[\\w-]+)}");
            Match idMatch = idRx.Match(lines[1]);
            res.Id = idMatch.Value.Substring(1, idMatch.Value.Length - 2);

            res.Name = lines[2].Substring(lines[2].IndexOf('=') + 1);
            res.Duration = int.Parse(lines[4].Substring(lines[4].IndexOf('=') + 1));
            res.Size = int.Parse(lines[6].Substring(lines[6].IndexOf('=') + 1));

            int songListIdx = Array.IndexOf(lines, "#-----CONTENT-----#") + 1;

            for (var i = songListIdx; i < lines.Length; i++)
            {
                var line = lines[i].Split('|');
                var song = new SongModel
                {
                    Path = line[0],
                    Name = line[1],
                    Artist = line[2],
                    Album = line[3],
                    Length = Convert.ToInt32(line[14]),
                    Size = Convert.ToInt32(line[15]),
                    Id = i - songListIdx
                };
                song.ComputeHash();
                res.Songs.Add(song);
            }

            return res;
        }
    }
}