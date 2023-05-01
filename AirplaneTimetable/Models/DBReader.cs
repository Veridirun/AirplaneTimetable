using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.X11;
using Microsoft.Data.Sqlite;
using Tmds.DBus;

namespace AirplaneTimetable.Models
{
    public static class DBReader
    {
        public static ObservableCollection<FlightBaseObject> DBLoad()
        {
            ObservableCollection<FlightBaseObject> flightCollection = new ObservableCollection<FlightBaseObject>();
            string sqlExpression = "SELECT * FROM Flights";
            //using (var connection = new SqliteConnection("DataSource = C:\\Users\\Kirill\\source\\repos\\AirplaneTimetable\\bdgen\\bin\\Debug\\net6.0\\flightsdata.db"))
            using (var connection = new SqliteConnection("DataSource = ..\\..\\..\\Assets\\flightsdata.db"))
            {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                        while (reader.Read() == true)
                        {
                            var flightNumber = reader["FlightNumber"];
                            var flightType = reader["FlightType"];
                            var companyID = reader["CompanyID"];
                            var departureFrom = reader["DepartureFrom"];
                            var arrivalTo = reader["ArrivalTo"];

                            var timetableTime = reader["TimetableTime"];
                            var probableTime = reader["ProbableTime"];

                            var gate = reader["Gate"];
                            var flightStatus = reader["FlightStatus"];
                            var companyName = reader["CompanyName"];
                            var airplaneType = reader["AirplaneType"];
                            var baggageBeltNumber = reader["BaggageBeltNumber"];
                            var registrationDesks = reader["RegistrationDesks"];

                            var registrationStartDate = reader["RegistrationStartDate"];
                            var boardingStartDate = reader["BoardingStartDate"];
                            var boardingGateNum = reader["BoardingGateNum"];

                            Bitmap companyImage = new Bitmap(reader.GetStream(16));

                            if ((string)flightType == "Arrival") 
                            {
                                flightCollection.Add(new FlightArrivalObject
                                {
                                    FlightType = (string)flightType,
                                    CompanyID = (string)companyID,
                                    FlightNumber = (long)flightNumber,
                                    DepartureFrom = (string)departureFrom,
                                    ArrivalTo = (string)arrivalTo,
                                    TimetableTime = ConvertToDateTime((string)timetableTime),
                                    ProbableTime = ConvertToDateTime((string)probableTime),
                                    Gate = (string)gate,
                                    FlightStatus = (string)flightStatus,
                                    CompanyName = (string)companyName,
                                    AirplaneType = (string)airplaneType,
                                    BaggageBeltNumber = (string)baggageBeltNumber,
                                    CompanyImage=companyImage
                                });;
                            }
                            
                            if ((string)flightType == "Departure")
                            {
                                flightCollection.Add(new FlightDepartureObject
                                {

                                    FlightType = (string)flightType,
                                    CompanyID = (string)companyID,
                                    FlightNumber = (long)flightNumber,
                                    DepartureFrom = (string)departureFrom,
                                    ArrivalTo = (string)arrivalTo,
                                    TimetableTime = ConvertToDateTime((string)timetableTime),
                                    ProbableTime = ConvertToDateTime((string)probableTime),
                                    Gate = (string)gate,
                                    FlightStatus = (string)flightStatus,
                                    CompanyName = (string)companyName,
                                    AirplaneType = (string)airplaneType,
                                    RegistrationDesks = (string)registrationDesks,
                                    RegistrationStartDate = ConvertToDateTime((string)registrationStartDate),
                                    BoardingStartDate = ConvertToDateTime((string)boardingStartDate),
                                    BoardingGateNum = (string)boardingGateNum,
                                    CompanyImage=companyImage
                                });
                            }
                            
                    }
                        return flightCollection;
                }
            }
        }
            return null;
        }
        public static DateTime ConvertToDateTime(string str)
        {
            //str += ".000";
            string pattern = @"(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})";
            if (Regex.IsMatch(str, pattern))
            {
                Match match = Regex.Match(str, pattern);
                int year = Convert.ToInt32(match.Groups[1].Value);
                int month = Convert.ToInt32(match.Groups[2].Value);
                int day = Convert.ToInt32(match.Groups[3].Value);
                int hour = Convert.ToInt32(match.Groups[4].Value);
                int minute = Convert.ToInt32(match.Groups[5].Value);
                int second = Convert.ToInt32(match.Groups[6].Value);
                //System.Diagnostics.Debug.WriteLine($"Время считано {year}-{month}-{day} {hour}:{minute}:{second}");
                return new DateTime(year, month, day, hour, minute, second);
            }
            else
            {
                throw new Exception("Unable to parse.");
            }
        }

    }
    
}
