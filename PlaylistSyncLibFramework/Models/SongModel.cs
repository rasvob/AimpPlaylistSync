using System;
using System.Data.HashFunction;
using System.Data.HashFunction.xxHash;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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
            ComputeSha256Hash();
        }

        private void ComputeXxHash()
        {
            IxxHash xxHash = xxHashFactory.Instance.Create();
            byte[] file = File.ReadAllBytes(Path);
            IHashValue hashValue = xxHash.ComputeHash(file);
            Hash = hashValue.AsHexString(false);
        }

        private void ComputeSha256Hash()
        {
            string ToHex(byte[] bytes, bool upperCase)
            {
                StringBuilder result = new StringBuilder(bytes.Length * 2);
                foreach (byte t in bytes)
                    result.Append(t.ToString(upperCase ? "X2" : "x2"));
                return result.ToString();
            }

            using (var hash = new SHA256Managed())
            {
                byte[] hashValue = hash.ComputeHash(File.ReadAllBytes(Path));
                Hash = ToHex(hashValue, false);
            }
        }
    }
}