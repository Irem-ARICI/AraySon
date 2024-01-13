using AraySon.Dtos;
using AraySon.Models;

namespace AraySon.Services
{
    public interface IUrunService
    {
        List<UrunDto> UrunlerGet(GetUrunlerInput input);

        void UrunEkleGuncelle(CreateOrEditUrunDto input);

        Urun UrunIdGet(Guid id);

        void UrunSil(Guid id);
    }
}
