using System.IO;
using PlaylistSyncLibFramework.Models;

namespace AimpSync.ViewModels
{
    public class SongViewModel: IViewModelMapper<SongModel>
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Size { get; set; }
        public string Sha256 { get; set; }
        public int Id { get; set; }

        public void MapFromModel(SongModel model)
        {
            Length = model.Length;
            Size = model.Size;
            Sha256 = model.Sha256;
            Id = model.Id;

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
                Sha256 = Sha256,
                Length = Length,
                Size = Size,
            };

            return model;
        }
    }
}