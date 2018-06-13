using System.IO;
using PlaylistSyncLibFramework.Models;

namespace AimpSync.ViewModels
{
    public class SongViewModel: IViewModelMapper<SongModel>
    {
        public string Name { get; set; }
        public string  FileName { get; set; }
        public int Length { get; set; }
        public int Size { get; set; }
        public string Hash { get; set; }
        public int Id { get; set; }

        public void MapFromModel(SongModel model)
        {
            Length = model.Length;
            Size = model.Size;
            Hash = model.Hash;
            Id = model.Id;
            FileName = Path.GetFileName(model.Path);

            if (model.Artist != string.Empty && model.Name != string.Empty)
            {
                Name = $"{model.Artist} - {model.Name}";
            }
            else
            {
                Name = Path.GetFileNameWithoutExtension(model.Path);
            }
        }

        public SongModel MapToModel()
        {
            SongModel model = new SongModel()
            {
                Id = Id,
                Name = Name,
                Hash = Hash,
                Length = Length,
                Size = Size,
            };

            return model;
        }
    }
}