using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class AddressDetailsDto
    {
        public string Employee_Id { get; set; }
        public string AddressType { get; set; }
        public string DoorNo { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string LandMark { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
    }
}
