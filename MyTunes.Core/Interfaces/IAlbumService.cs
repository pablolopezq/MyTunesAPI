using MyTunes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Core.Interfaces
{
    public interface IAlbumService
    {
        ServiceResult<Album> GetById(int id);

        ServiceResult<IEnumerable<Album>> GetAlbums();

        ServiceResult<IEnumerable<Album>> GetPurchasedAlbums();

        ServiceResult<Album> Purchase(int id);

        ServiceResult<Album> SetRating(int id, int rating);

        ServiceResult<int> GetAlbumDuration(int id);
    }
}
