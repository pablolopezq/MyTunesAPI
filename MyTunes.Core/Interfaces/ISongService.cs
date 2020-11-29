using MyTunes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Core.Interfaces
{
    public interface ISongService
    {
        ServiceResult<Song> GetById(int id);

        ServiceResult<IEnumerable<Song>> GetSongs();

        ServiceResult<IEnumerable<Song>> GetPurchasedSongs();

        ServiceResult<Song> Purchase(int id);
    }
}
