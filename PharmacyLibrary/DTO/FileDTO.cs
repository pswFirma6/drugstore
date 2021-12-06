using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.DTO
{
    public class FileDto
    {
        public string Name { get; set; }

        public FileDto() { }

        public FileDto(string name)
        {
            Name = name;
        }
    }
}
