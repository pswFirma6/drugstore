using PharmacyLibrary.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhramacyLibrary.Model
{
   public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public MedicineType MedicineType { get; set; }
        public string Description { get; set; }
        public bool IsPrescribed { get; set; }
        public string SideEffects { get; set; }
        public string RecommendedDose { get; set; }
        public int Quantity { get; set; }
        public double Intensity { get; set; }

        public Medicine(int id, string name, string manufacturer, MedicineType medicineType, string description, bool isPrescribed, string sideEffects, string recommendedDose, int quantity, double intensity)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            MedicineType = medicineType;
            Description = description;
            IsPrescribed = isPrescribed;
            SideEffects = sideEffects;
            RecommendedDose = recommendedDose;
            Quantity = quantity;
            Intensity = intensity;
        }
    }
}
