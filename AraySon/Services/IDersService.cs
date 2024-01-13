using AraySon.Dtos;
using AraySon.Models;

namespace AraySon.Services
{
    public interface IDersService
    {
        List<Ders> DersGet();
        void DersEkleGuncelle(CreateOrEditDersDto input);

        Ders DersIdGet(int id);
        void DersSil(int id);
        void DersEkle(CreateOrEditDersDto input);
        void DersGuncelle(CreateOrEditDersDto input);
    }
}
