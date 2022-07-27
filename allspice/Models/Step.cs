using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace allspice.Models
{
    public class Step
    {
        public int Position { get; set; }
        public string Body { get; set; }
        public int RecipeId { get; set; }
    }
}