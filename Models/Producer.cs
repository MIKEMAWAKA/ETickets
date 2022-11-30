using System;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Producer
    {


        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biograph")]
        public string Bio { get; set; }


        public List<Movie> Movies { get; set; }
    }
}

