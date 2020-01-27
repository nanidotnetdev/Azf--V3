using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Azf_MVC.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required]
        [DisplayName("Name")]
        [MaxLength(150)]
        public string UserName { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
