using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.DTO
{
    public class FileDTO
    {
        public string Name { get; set; }

        public FileDTO() { }

        public FileDTO(string name)
        {
            Name = name;
        }
    }
}
