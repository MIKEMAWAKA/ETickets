using System;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor
    {

        [Key]
        public int Id { get; set; }
         
        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage ="Profile Picture URL is required")]
        public string ProfilePictureURL { get; set; }


         [Display(Name ="Full Name")]
          [Required(ErrorMessage ="Full Name is required")]
         public string FullName { get; set; }
      

         [Display(Name ="Biograph")]
          [Required(ErrorMessage ="Biograph is required")]
          [StringLength(50,MinimumLength =3,ErrorMessage ="Full Name must be betwween 3 and 50 chars")]
         public string Bio { get; set; }


        //Relationships
        public List<Actor_Movie> Actor_Movies { get; set; }




    }
}

