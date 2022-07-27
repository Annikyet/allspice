using System.Collections.Generic;

namespace allspice.Models
{
  public class Recipe
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Category { get; set; }
        // public string Description { get; set; }
        public string CreatorID { get; set; }
        public Profile Creator { get; set; }
    }
}