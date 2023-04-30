using AirplaneTimetable.Models;
using Avalonia.Media.Imaging;
using HarfBuzzSharp;
using ReactiveUI;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

namespace AirplaneTimetable.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DateTime todayDate = DateTime.Now;
        public string Greeting => "Welcome to Avalonia!";
        ObservableCollection<FlightBaseObject> flightCollection;
        ObservableCollection<FlightBaseObject> FlightCollection
        {
            get
            {
                return flightCollection;
            }
            set => this.RaiseAndSetIfChanged(ref flightCollection, value);
        }
        
        IEnumerable<FlightBaseObject> flightCollectionFiltered;
        IEnumerable<FlightBaseObject> FlightCollectionFiltered
        {
            get => flightCollectionFiltered;
            set
            {
                this.RaiseAndSetIfChanged(ref flightCollectionFiltered, value);
            }
        }
        
        private int count;
        public int Count
        {
            get => count;
            set => this.RaiseAndSetIfChanged(ref count, value);
        }
        private int timeSelection;
        public int TimeSelection
        {
            get => timeSelection;
            set 
            {
                System.Diagnostics.Debug.WriteLine($"TimeSelection set to {value}");
                this.RaiseAndSetIfChanged(ref timeSelection, value);
                ChangeDirectionImages();
            }
        }
        private int directionSelection;
        public int DirectionSelection
        {
            get => directionSelection;
            set
            {
                System.Diagnostics.Debug.WriteLine($"DirectionSelection set to {value}");
                this.RaiseAndSetIfChanged(ref directionSelection, value);
                ChangeDirectionImages();
            }
        }
        private string sourceDeparture;
        public string SourceDeparture
        {
            get => sourceDeparture;
            set => this.RaiseAndSetIfChanged(ref sourceDeparture, value);
        }
        private string sourceArrival;
        public string SourceArrival
        {
            get => sourceArrival;
            set => this.RaiseAndSetIfChanged(ref sourceArrival, value);
        }
        private string tableText;
        public string TableText
        {
            get => tableText;
            set => this.RaiseAndSetIfChanged(ref tableText, value);
        }
        public MainWindowViewModel()
        {
            flightCollection = DBReader.DBLoad();
            TimeSelection = 1;
            DirectionSelection = 0;
        }
        private void ChangeDirectionImages()
        {
            if(DirectionSelection == 0)
            {
                SourceDeparture = "..\\..\\..\\Assets\\departure_active.png";
                SourceArrival = "..\\..\\..\\Assets\\arrival_inactive.png";
                TableText = "Назначение";
            }
            if(DirectionSelection == 1)
            {
                SourceDeparture = "..\\..\\..\\Assets\\departure_inactive.png";
                SourceArrival = "..\\..\\..\\Assets\\arrival_active.png";
                TableText = "Пункт вылета";
            }
            if (DirectionSelection == 0 && TimeSelection == 0) //Departure yesterday
                FlightCollectionFiltered=flightCollection.Where(x => x.FlightType == "Departure")
                    .Where(x => {
                        TimeSpan ts = x.TimetableTime - todayDate;

                        return (Math.Abs(ts.TotalDays) > 1 && (x.TimetableTime < todayDate));
                    });
            if (DirectionSelection == 0 && TimeSelection == 1) //Departure today
                FlightCollectionFiltered = flightCollection.Where(x => x.FlightType == "Departure")
                    .Where(x => {
                        TimeSpan ts = x.TimetableTime - todayDate;
                        //System.Diagnostics.Debug.WriteLine($"Сегодня {todayDate} TimetableTime={x.TimetableTime} Разница {ts.TotalDays} Выражение {Math.Abs(ts.TotalDays) < 1}");
                        return (Math.Abs(ts.TotalDays) < 1);
                    });
            if (DirectionSelection == 0 && TimeSelection == 2) //Departure tomorrow
                FlightCollectionFiltered = flightCollection.Where(x => x.FlightType == "Departure")
                    .Where(x => {
                        TimeSpan ts = x.TimetableTime - todayDate;
                        return (Math.Abs(ts.TotalDays) > 1 && (x.TimetableTime > todayDate));
                    });
            if (DirectionSelection == 1 && TimeSelection == 0) //Arrival yesterday
                FlightCollectionFiltered = flightCollection.Where(x => x.FlightType == "Arrival")
                    .Where(x => {
                        TimeSpan ts = x.TimetableTime - todayDate;
                        return (Math.Abs(ts.TotalDays) > 1 && (x.TimetableTime < todayDate));
                    });
            if (DirectionSelection == 1 && TimeSelection == 1) //Arrival today
                FlightCollectionFiltered = flightCollection.Where(x => x.FlightType == "Arrival")
                    .Where(x => {
                        TimeSpan ts = x.TimetableTime - todayDate;
                        return (Math.Abs(ts.TotalDays) < 1);
                    });
            if (DirectionSelection == 1 && TimeSelection == 2) //Arrival tomorrow
                FlightCollectionFiltered = flightCollection.Where(x => x.FlightType == "Arrival")
                    .Where(x => {
                        TimeSpan ts = x.TimetableTime - todayDate;
                        return (Math.Abs(ts.TotalDays) > 1 && (x.TimetableTime > todayDate));
                    });

        }
    }
}
