using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ETickets.Data;

namespace ETickets.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }


        [Display(Name ="Name")]
        public string Name { get; set; }

        [Display(Name = "Description ")]
        public string Description { get; set; }


        [Display(Name = "Image")]
        public string ImageURL { get; set; }


        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "StartDate")]
        public DateTime StartDate{ get; set; }


        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }



        public MovieCategory MovieCategory { get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }

        //Cinema

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]

        public Cinema Cinema{ get; set; }

        //Cinema

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]

        public Producer producer { get; set; }


        //public string Description { get; set; }

        //public string ImageUrl { get; set; }


        //public string Name { get; set; }

        //public string Description { get; set; }

        //public string ImageUrl { get; set; }
    }
}

