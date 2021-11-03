using System;
using System.Collections.Generic;
using System.Text;

namespace DrugstoreLibrary.Model
{
   public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Intensity { get; set; }
        public bool IsRecipe { get; set; }

    }
}
