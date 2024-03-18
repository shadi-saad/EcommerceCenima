﻿namespace EcommerceCenima.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
