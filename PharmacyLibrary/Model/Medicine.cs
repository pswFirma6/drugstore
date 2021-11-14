using System;
using System.Collections.Generic;
using System.Text;

namespace DrugstoreLibrary.Model
{
   public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Decription { get; set; }
        public bool Prescribed { get; set; }
        public string SideEffects { get; set; }
        public string RecommendedDose { get; set; }
        public int Quantity { get; set; }
        public double Intensity { get; set; }

        public Medicine(int id, string name, string manufacturer, string decription, bool prescribed, string sideEffects, string recommendedDose, int quantity, double intensity)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Decription = decription;
            Prescribed = prescribed;
            SideEffects = sideEffects;
            RecommendedDose = recommendedDose;
            Quantity = quantity;
            Intensity = intensity;
        }
    }
}
