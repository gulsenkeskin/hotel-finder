using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService; //EKLEE

        public HotelsController(IHotelService hotelService) //EKLEEEEEE
        {
            _hotelService = hotelService;
        }

        //METHOTLAR YAZ


        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels= await _hotelService.GetAllHotels();
            return Ok(hotels);//200+data
        }

        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] //api/hotels/gethotelbyid/2
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel=await _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel); //200+data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Get hotel by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")] //api/hotels/gethotelbyid/nae
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            //null kontrolü
            if (hotel!=null)
            {
                return Ok(hotel); //200+data
            }

            return NotFound(); //404
        } 


        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            var createdHotel= await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new {id = createdHotel.Id}, createdHotel); //201+ data
        }


        /// <summary>
        /// update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id)!=null) //bana gelen otelin id si veritabanında varsa
            {
                return Ok(await _hotelService.UpdateHotel(hotel)); //200+data
               
            }

            return NotFound();
        }

        /// <summary>
        /// Delete the hotel
        /// </summary>
        /// <param name="id"></param>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (await _hotelService.GetHotelById(id) != null) //bana gelen otelin id si veritabanında varsa
            {
               await _hotelService.DeleteHotel(id);
                return Ok(); //200
                
            }

            return NotFound();
        }
    }
}
