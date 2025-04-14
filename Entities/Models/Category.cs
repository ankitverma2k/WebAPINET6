using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required][StringLength(50, ErrorMessage = "Length Should less then 50 Characters & greater then 5", MinimumLength = 5)] public string? Name { get; set; }
        public string? Description { get; set; }


    }
}
