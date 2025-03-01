using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 999.99, ErrorMessage = "Range must be between 1 to 999.99 only.")]
        public double Price { get; set; }

        [MaxLength(200, ErrorMessage = "Length cannot exceed more than 200 characters.")]
        public string Description { get; set; }

        public ICollection<PImages>? ImgUrls { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public string? HomeImgUrl { get; set; }
    }
}
