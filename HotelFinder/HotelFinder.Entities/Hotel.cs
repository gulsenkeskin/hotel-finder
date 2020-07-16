using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelFinder.Entities
{
    public class Hotel
    {
        //primary key 1 den başlayıp 1 er 1er  artıyor
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required] //gerekli alan 
        public string Name { get; set; }
        [StringLength(50)]
        [Required] //gerekli alan demek
        public string City { get; set; }
    }
}
