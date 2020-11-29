using MyTunes.Core.Entities;
using MyTunes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunes.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _albumRepository;
        private readonly IRepository<Song> _songRepository;

        public AlbumService(IRepository<Album> albumRepository, IRepository<Song> songRepository)
        {
            _albumRepository = albumRepository;
            _songRepository = songRepository;
        }

        public ServiceResult<int> GetAlbumDuration(int id)
        {
            var songs = _songRepository.GetAll().Where(s => s.AlbumId == id).Select(a => a.Duration);
            return ServiceResult<int>.SuccessResult(songs.Sum());
        }

        public ServiceResult<IEnumerable<Album>> GetAlbums()
        {
            return ServiceResult<IEnumerable<Album>>.SuccessResult(_albumRepository.GetAll());
        }

        public ServiceResult<Album> GetById(int id)
        {
            return ServiceResult<Album>.SuccessResult(_albumRepository.GetById(id));
        }

        public ServiceResult<IEnumerable<Album>> GetPurchasedAlbums()
        {
            return ServiceResult<IEnumerable<Album>>.SuccessResult(_albumRepository.GetAll().Where(a => a.Purchased == true));
        }

        public ServiceResult<Album> SetRating(int id, int rating)
        {
            var album = _albumRepository.GetById(id);
            album.Rating = rating;
            return ServiceResult<Album>.SuccessResult(_albumRepository.Update(album));
        }

        public ServiceResult<Album> Purchase(int id)
        {
            var album = _albumRepository.GetById(id);
            album.Purchased = true;
            return ServiceResult<Album>.SuccessResult(_albumRepository.Update(album));
        }
    }
}
