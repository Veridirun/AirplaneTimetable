using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTimetable.Models
{
    public class FlightArrivalObject : FlightBaseObject
    {
        private string? baggageBeltNumber;
        public string? BaggageBeltNumber
        {
            get => baggageBeltNumber;
            set => baggageBeltNumber = value;
        }
    }
}
