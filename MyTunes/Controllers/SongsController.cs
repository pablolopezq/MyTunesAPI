using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTunes.Core.Enums;
using MyTunes.Core.Interfaces;
using MyTunes.Models;

namespace MyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongDto>> Get()
        {
            var serviceResult = _songService.GetSongs();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var song = serviceResult.Result;
            return Ok(serviceResult.Result.Select(s => new SongDto
            {
                Id = s.Id,
                AlbumId = s.AlbumId,
                Artist = s.Artist,
                Duration = s.Duration,
                Name = s.Name,
                Price = s.Price,
                Rating = s.Rating
            }));
        }

        [HttpGet]
        [Route("purchased")]
        public ActionResult<IEnumerable<SongDto>> GetPurchased()
        {
            var serviceResult = _songService.GetPurchasedSongs();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var song = serviceResult.Result;
            return Ok(serviceResult.Result.Select(s => new SongDto
            {
                Id = s.Id,
                AlbumId = s.AlbumId,
                Artist = s.Artist,
                Duration = s.Duration,
                Name = s.Name,
                Price = s.Price,
                Rating = s.Rating
            }));
        }

        [HttpPut]
        [Route("{songId}/purchase")]
        public ActionResult<SongDto> Purchase(int songId)
        {
            var serviceResult = _songService.Purchase(songId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result);
        }

        [HttpGet]
        [Route("{songId}")]
        public ActionResult<AlbumDto> Get(int songId)
        {
            var serviceResult = _songService.GetById(songId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var album = serviceResult.Result;
            return Ok(new SongDto
            {
                Artist = album.Artist,
                Id = album.Id,
                Name = album.Name,
                Price = album.Price,
                AlbumId = album.AlbumId,
                Duration = album.Duration,
                Rating = album.Rating
            });
        }
    }
}
