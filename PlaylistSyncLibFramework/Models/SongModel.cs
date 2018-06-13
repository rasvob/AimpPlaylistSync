using System;
using System.Data.HashFunction;
using System.Data.HashFunction.xxHash;
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
        public string Hash { get; set; }
        public int Id { get; set; }

        public void ComputeHash()
        {
            IxxHash xxHash = xxHashFactory.Instance.Create();
            byte[] file = File.ReadAllBytes(Path);
            IHashValue hashValue = xxHash.ComputeHash(file);
            Hash = hashValue.AsHexString(false);
        }
    }
}