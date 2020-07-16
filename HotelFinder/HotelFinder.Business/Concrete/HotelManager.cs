using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;

namespace HotelFinder.Business.Concrete
{
    //CLASS I PUBLİC YAZMAYI VE IHOTELSERVİCEDEN İMPLEMENTE ETMEYİ UNUTMA
    public class HotelManager:IHotelService
    {
        private IHotelRepository _hotelRepository; //EKLEE

        public HotelManager(IHotelRepository hotelRepository) //EKLEE
        {
            _hotelRepository = hotelRepository;

        }
        //İMPLEMENTE EDİLEN METHODLAR

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id>0)
            {
                return await _hotelRepository.GetHotelById(id);
            }
            
            throw new Exception("id can not be less than 1");

        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
           await _hotelRepository.DeleteHotel(id);
        }
    }
}
