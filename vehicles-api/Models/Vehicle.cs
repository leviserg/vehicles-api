using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vehicles_api.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Model")]
        public string Model { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Price { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateLastChanged")]
        public DateTime DateLastChanged { get; set; } = DateTime.Now;

        public string ImageUrl { get; set; }

    }
}
