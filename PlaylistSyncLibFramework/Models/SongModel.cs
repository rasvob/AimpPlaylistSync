using System;
using System.IO;
using System.Security.Cryptography;

namespace PlaylistSyncLibFramework.Models
{
    public class SongModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Length { get; set; }
        public int Size { get; set; }
        public string Sha256 { get; set; }
        public int Id { get; set; }

        public void ComputeHash()
        {
            using (var crypt = new SHA256Managed())
            {
                byte[] hash = crypt.ComputeHash(File.ReadAllBytes(Path));
                Sha256 = BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}