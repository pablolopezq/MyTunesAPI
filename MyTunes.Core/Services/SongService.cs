using MyTunes.Core.Entities;
using MyTunes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunes.Core.Services
{
    public class SongService : ISongService
    {
        private readonly IRepository<Song> _songRepository;

        public SongService(IRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        public ServiceResult<Song> GetById(int id)
        {
            var song = _songRepository.GetById(id);
            return song != null
                ? ServiceResult<Song>.SuccessResult(song)
                : ServiceResult<Song>.NotFoundResult(
                    $"No se encontro la cancion con el id {id}");
        }

        public ServiceResult<IEnumerable<Song>> GetPurchasedSongs()
        {
            return ServiceResult<IEnumerable<Song>>.SuccessResult(_songRepository.GetAll().Where(a => a.Purchased == true));
        }

        public ServiceResult<IEnumerable<Song>> GetSongs()
        {
            return ServiceResult<IEnumerable<Song>>.SuccessResult(_songRepository.GetAll());
        }

        public ServiceResult<Song> Purchase(int id)
        {
            var song = _songRepository.GetById(id);
            song.Purchased = true;
            return ServiceResult<Song>.SuccessResult(_songRepository.Update(song));
        }
    }
}
