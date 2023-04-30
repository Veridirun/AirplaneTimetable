using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTimetable.Models
{
    public class FlightDepartureObject : FlightBaseObject
    {
        private string? registrationDesks;
        public string? RegistrationDesks
        {
            get => registrationDesks;
            set => registrationDesks = value;
        }
        private DateTime? registrationStartDate;
        public DateTime? RegistrationStartDate
        {
            get => registrationStartDate;
            set => registrationStartDate = value;
        }
        private DateTime? boardingStartDate;
        public DateTime? BoardingStartDate
        {
            get => boardingStartDate;
            set => boardingStartDate = value;
        }
        private string? boardingGateNum;
        public string? BoardingGateNum
        {
            get => boardingGateNum;
            set => boardingGateNum = value;
        }
    }
}
