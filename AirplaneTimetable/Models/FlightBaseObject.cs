using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTimetable.Models
{
    public class FlightBaseObject
    {
        private string flightType;
        public string FlightType
        {
            get => flightType;
            set => flightType = value;
        }
        private string companyID;
        public string CompanyID
        {
            get => companyID;
            set => companyID = value;
        }
        private long flightNumber;
        public long FlightNumber 
        {
            get => flightNumber;
            set => flightNumber = value;
        }
        private string departureFrom;
        public string DepartureFrom
        {
            get => departureFrom;
            set => departureFrom = value;
        }
        private string arrivalTo;
        public string ArrivalTo
        {
            get => arrivalTo;
            set => arrivalTo = value;
        }
        private DateTime timetableTime;
        public DateTime TimetableTime
        {
            get => timetableTime; 
            set => timetableTime = value;
        }
        private DateTime probableTime;
        public DateTime ProbableTime
        {
            get => probableTime; 
            set => probableTime = value;
        }
        private string gate;
        public string Gate
        {
            get => gate; 
            set => gate = value;
        }
        private string flightStatus;
        public string FlightStatus
        {
            get => flightStatus; 
            set => flightStatus = value;
        }
        private string companyName;
        public string CompanyName
        {
            get => companyName;
            set => companyName = value;
        }
        private string airplaneType;
        public string AirplaneType
        {
            get => airplaneType;  
            set => airplaneType = value;
        }
        
        private Bitmap companyImage;
        public Bitmap CompanyImage
        {
            get => companyImage;
            set => companyImage = value;
        }
        
    }
}
