using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Catagory
    {
        [Key]
        public int catagory_id { get; set; }
        public string catagory_name { get; set; }
    }
}
