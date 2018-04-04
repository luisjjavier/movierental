using System;
using System.Collections.Generic;

namespace Webapp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public ISet<Rental> Rentals { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public int LanguageId { get; set; }
        public int OriginalLanguageId { get; set; }
        public Language OrginalLanguage { get; set; }
        public Language Language { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public decimal ReplacementCost { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public ISet<Category> Categories { get; set; }
        public DateTime Created { get; set; }
    }
}