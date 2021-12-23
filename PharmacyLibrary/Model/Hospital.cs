using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public string HospitalName { get; set; }

        public Address HospitalAddress { get; set; }
        public ConnectionInfo HospitalConnectionInfo { get; set; }
        public Hospital() { }

        public Hospital(int id, string hospitalName, Address hospitalAddress, ConnectionInfo hospitalConnectionInfo)
        {
            Id = id;
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
            HospitalConnectionInfo = hospitalConnectionInfo;
        }

        public Hospital(string hospitalName, Address hospitalAddress, ConnectionInfo hospitalConnectionInfo)
        {
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
            HospitalConnectionInfo = hospitalConnectionInfo;
        }

    }
}