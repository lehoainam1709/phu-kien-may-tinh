using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace phu_kien_may_tinh.Models
{
    public class phukien
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name="Tên sản phẩm")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sản xuất")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

    }
}
