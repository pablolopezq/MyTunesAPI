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
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlbumDto>> Get()
        {
            var serviceResult = _albumService.GetAlbums();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var albums = serviceResult.Result;
            return Ok(albums.Select(a => new AlbumDto
            { 
                Artist = a.Artist,
                Date = a.Date,
                Description = a.Description,
                Genre = a.Genre,
                Id = a.Id,
                Img = a.Img,
                Name = a.Name,
                Price = a.Price,
                Rating = a.Rating
            }));
        }

        [HttpGet]
        [Route("{albumId}")]
        public ActionResult<AlbumDto> Get(int albumId)
        {
            var serviceResult = _albumService.GetById(albumId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var album = serviceResult.Result;
            return Ok(new AlbumDto 
            { 
                Artist = album.Artist,
                Date = album.Date,
                Description = album.Description,
                Genre = album.Genre,
                Id = album.Id,
                Img = album.Img,
                Name = album.Name,
                Price = album.Price,
                Rating = album.Rating
            });
        }

        [HttpGet]
        [Route("purchased")]
        public ActionResult<IEnumerable<AlbumDto>> GetPurchased()
        {
            var serviceResult = _albumService.GetPurchasedAlbums();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var albums = serviceResult.Result;
            return Ok(albums.Select(a => new AlbumDto
            {
                Artist = a.Artist,
                Date = a.Date,
                Description = a.Description,
                Genre = a.Genre,
                Id = a.Id,
                Img = a.Img,
                Name = a.Name,
                Price = a.Price,
                Rating = a.Rating
            }));
        }

        [HttpGet]
        [Route("{albumId}/duration")]
        public ActionResult<int> GetDuration(int albumId)
        {
            var serviceResult = _albumService.GetAlbumDuration(albumId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return serviceResult.Result;
        }

        [HttpPut]
        [Route("{albumId}/purchase")]
        public ActionResult<AlbumDto> Purchase(int albumId)
        {
            var serviceResult = _albumService.Purchase(albumId);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result);
        }

        [HttpPut]
        [Route("{albumId}/{rating}")]
        public ActionResult<AlbumDto> Rating(int albumId, int rating)
        {
            var serviceResult = _albumService.SetRating(albumId, rating);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result);
        }
    }
}
