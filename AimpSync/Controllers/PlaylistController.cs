using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AimpSync.Config;
using AimpSync.Repositories;
using AimpSync.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using PlaylistSyncLibFramework.Models;

namespace AimpSync.Controllers
{
    public class PlaylistController
    {
        private readonly IOptions<PlaylistSettings> _settings;
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistController(IOptions<PlaylistSettings> settings, IPlaylistRepository playlistRepository)
        {
            _settings = settings;
            _playlistRepository = playlistRepository;
        }

        [HttpGet]
        [Route("playlist")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SongViewModel>))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            try
            {
                PlaylistModel playlistModel = _playlistRepository.GetModel(_settings.Value.PlaylistPath);
                IEnumerable<SongViewModel> songViewModels = playlistModel.Songs.Select(t =>
                {
                    var res = new SongViewModel();
                    res.MapFromModel(t);
                    return res;
                });
                return new OkObjectResult(songViewModels);
            }
            catch (FileNotFoundException e)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [Route("playlist/info/{id}")]
        [ProducesResponseType(200, Type = typeof(SongViewModel))]
        [ProducesResponseType(404)]
        public IActionResult GetSongInfoById(int id)
        {
            try
            {
                PlaylistModel playlistModel = _playlistRepository.GetModel(_settings.Value.PlaylistPath);
                SongModel song = _playlistRepository.GetSongById(playlistModel, id);

                if (song is null)
                {
                    return new NotFoundResult();
                }

                var res = new SongViewModel();
                res.MapFromModel(song);
                return new OkObjectResult(res);
            }
            catch (FileNotFoundException e)
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [Route("playlist/download/{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            try
            {
                PlaylistModel playlistModel = _playlistRepository.GetModel(_settings.Value.PlaylistPath);
                SongModel song = _playlistRepository.GetSongById(playlistModel, id);

                if (song is null)
                {
                    return new NotFoundResult();
                }

                return new PhysicalFileResult(song.Path, "application/octet-stream");
            }
            catch (FileNotFoundException e)
            {
                return new NotFoundResult();
            }
        }
    }
}