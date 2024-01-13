using AraySon.Dtos;
using AraySon.Models;

namespace AraySon.Services
{
    public interface IKategoriService
    {
        List<Kategori> KategoriGet();

        Kategori KategoriIdGet(int id);

        void KategoriEkleGuncelle(CreateOrEditKategoriDto input);

        void KategoriSil(int id);

    }
}
