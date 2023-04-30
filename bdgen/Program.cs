using Microsoft.Data.Sqlite;

using (var connection = new SqliteConnection("Data Source=flightsdata.db"))
{
    connection.Open();
    SqliteCommand command = new SqliteCommand();
    command.Connection = connection;

    /*   
       command.CommandText = "CREATE TABLE Flights(FlightNumber INTEGER NOT NULL PRIMARY KEY UNIQUE, " +
                                                   "FlightType TEXT NOT NULL, " +
                                                   "CompanyID TEXT NOT NULL, " +
                                                   "DepartureFrom TEXT NOT NULL, " +
                                                   "ArrivalTo TEXT NOT NULL, " +
                                                   "TimetableTime TEXT NOT NULL, " +
                                                   "ProbableTime TEXT NOT NULL, " +
                                                   "Gate TEXT NOT NULL, " +
                                                   "FlightStatus TEXT NOT NULL, " +
                                                   "CompanyName TEXT NOT NULL, " +
                                                   "AirplaneType TEXT NOT NULL, " +
                                                   "BaggageBeltNumber TEXT, " +
                                                   "RegistrationDesks TEXT, " +
                                                   "RegistrationStartDate TEXT, " +
                                                   "BoardingStartDate TEXT, " +
                                                   "BoardingGateNum TEXT, " +
                                                   "CompanyImage BLOB); ";


       command.ExecuteNonQuery();
       Console.WriteLine("Таблица Flights создана");
       */
    /*
    command.CommandText = "INSERT INTO Flights (FlightNumber, FlightType, CompanyID, DepartureFrom, " +
                                                "ArrivalTo, TimetableTime, ProbableTime, " +
                                                "Gate, FlightStatus, CompanyName, " +
                                                "AirplaneType, BaggageBeltNumber) VALUES " +

                                                "(5006, 'Arrival', 'S7', 'Санкт-Петербург', " +
                                                "'Новосибирск', '2023-04-25 01:05:00', '2023-04-25 01:02:00', " +
                                                "'A', 'Рейс прибыл', 'S7 Airlines'," +
                                                "'Airbus', 3)";
    int number = command.ExecuteNonQuery();
    Console.WriteLine($"В таблицу Users добавлено объектов: {number}");
    command.CommandText = "INSERT INTO Flights (FlightNumber, FlightType, CompanyID, DepartureFrom, " +
                                                "ArrivalTo, TimetableTime, ProbableTime, " +
                                                "Gate, FlightStatus, CompanyName, " +
                                                "AirplaneType, RegistrationDesks, RegistrationStartDate, " +
                                                "BoardingStartDate, BoardingGateNum) VALUES " +

                                                "(436, 'Departure', 'G6', 'Новосибирск', " +
                                                "'Ереван', '2023-04-26 01:30:00', '2023-04-26 01:30:00', " +
                                                "'Б', 'Отменён', 'FlyArna'," +
                                                "'Airbus', '-', '2023-04-25 23:00:00'," +
                                                "'2023-04-26 00:30:00', '-')";
    number = command.ExecuteNonQuery();
    */
    string[] arrayFlightType = new string[] { "'Departure'", "'Arrival'" };
    string[] arrayCompanyID = new string[] { "'S7'", "'EO'", "'YK'", "'2S'", "'6R'" };
    string[] arrayCity = new string[] { "'Сочи'", "'Пхукет'", "'Ульяновск'", "'Анталья'", "'Ташкент'", "'Стамбул'" };
    string[] arrayGate = new string[] { "'А'", "'Б'", "'С'", "'Д'" };
    string[] arrayDepartureFlightStatus = new string[] { "'Вылетел'", "'Регистр. завершена'", "'Регистрация'", "'По расписанию'", "'Задерживается'" };
    string[] arrayArrivalFlightStatus = new string[] { "'Рейс прибыл'", "'Задерживается'", "'Ожидается'", "'По расписанию'"};
    string[] arrayСompanyName = new string[] { "'Shirak Avia'", "'Azur Air'", "'S7 Airlines'", "'Алроса'", "'Uzbekistan Airways'" };
    string[] arrayAirplaneType = new string[] { "'B-737'", "'Embraer-170'", "'Airbus'", "'A-321'" };

    int startFlightNumber = 100;
    int number = 0;
    int amount = 0;
    Random randNum = new Random();
    for (int i = 0; i < 30; i++)
    {
        number=randNum.Next(2);
        if (number == 0) //add Departure
        {
            int randDay = 1 + randNum.Next(3);
            int randHour = randNum.Next(24);
            int randMinute = randNum.Next(60);
            string tempRegistrationDesks="'";
            for(int j = 0; j < 5; j++) //gen RegistrationDesks
            {
                tempRegistrationDesks+=(1+randNum.Next(30)).ToString();
                if(j!=4)
                    tempRegistrationDesks+=",";
            }
            tempRegistrationDesks += "'";
            command.CommandText = "INSERT INTO Flights (FlightNumber, FlightType, CompanyID, DepartureFrom, " +
                                            "ArrivalTo, TimetableTime, ProbableTime, " +
                                            "Gate, FlightStatus, CompanyName, " +
                                            "AirplaneType, RegistrationDesks, RegistrationStartDate, " +
                                            "BoardingStartDate, BoardingGateNum) VALUES " +

                                            "("+startFlightNumber.ToString()+", 'Departure', "+ //FlightNumber
                                            arrayCompanyID[randNum.Next(arrayCompanyID.Length)] +//FlightType
                                            ", 'Новосибирск', " + //always novosibirsk DepartureFrom
                                            arrayCity[randNum.Next(arrayCity.Length)] + //ArrivalTo
                                            ", "+
                                            "'2023-05-0"+
                                            randDay.ToString()+" "+ randHour.ToString()+ ":"+randMinute.ToString()+":00'" +//TimetableTime
                                            ", "+
                                            "'2023-05-0" +
                                            randDay.ToString() + " " + (randHour+randNum.Next(24-randHour)).ToString() + ":" + (randMinute + randNum.Next(60-randMinute)).ToString() + ":00'" +//ProbableTime
                                            ", " +
                                            arrayGate[randNum.Next(arrayGate.Length)] + //Gate
                                            ", "+
                                            arrayDepartureFlightStatus[randNum.Next(arrayDepartureFlightStatus.Length)] + //FlightStatus
                                            ", "+
                                            arrayСompanyName[randNum.Next(arrayСompanyName.Length)] + //CompanyName
                                            ", " +
                                            arrayAirplaneType[randNum.Next(arrayAirplaneType.Length)] + //AirplaneType
                                            ", "+
                                            tempRegistrationDesks+ //RegistrationDesks
                                            ", "+
                                            "'2023-05-0"+
                                            randDay.ToString() + " " + (randHour + randNum.Next(24-randHour)).ToString() + ":" + (randMinute + randNum.Next(60-randMinute)).ToString() + ":00'" +//RegistrationStartDate
                                            ", " +
                                            "'2023-05-0"+
                                            randDay.ToString() + " " + (randHour + randNum.Next(24-randHour)).ToString() + ":" + (randMinute + randNum.Next(60-randMinute)).ToString() + ":00'" +//BoardingStartDate
                                            ", " +
                                            "'"+
                                            randNum.Next(10).ToString()+ //BoardingGateNum
                                            "')";
        }
        if (number == 1) //add Arrival
        {
            int randDay = 1 + randNum.Next(3);
            int randHour = randNum.Next(24);
            int randMinute = randNum.Next(60);
            string tempRegistrationDesks = "'";
            for (int j = 0; j < 5; j++) //gen RegistrationDesks
            {
                tempRegistrationDesks += (1 + randNum.Next(30)).ToString();
                if (j != 4)
                    tempRegistrationDesks += ",";
            }
            tempRegistrationDesks += "'";
            command.CommandText = "INSERT INTO Flights (FlightNumber, FlightType, CompanyID, DepartureFrom, " +
                                                        "ArrivalTo, TimetableTime, ProbableTime, " +
                                                        "Gate, FlightStatus, CompanyName, " +
                                                        "AirplaneType, BaggageBeltNumber) VALUES "+

                                            "(" + startFlightNumber.ToString() + ", 'Arrival', " + //FlightNumber
                                            arrayCompanyID[randNum.Next(arrayCompanyID.Length)] +//FlightType
                                            ", "+ arrayCity[randNum.Next(arrayCity.Length)] + ", " + // DepartureFrom
                                            "'Новосибирск'" + //always novosibirsk ArrivalTo
                                            ", " +
                                            "'2023-05-0" +
                                            randDay.ToString() + " " + randHour.ToString() + ":" + randMinute.ToString() + ":00'" +//TimetableTime
                                            ", " +
                                            "'2023-05-0" +
                                            randDay.ToString() + " " + (randHour + randNum.Next(24 - randHour)).ToString() + ":" + (randMinute + randNum.Next(60 - randMinute)).ToString() + ":00'" +//ProbableTime
                                            ", " +
                                            arrayGate[randNum.Next(arrayGate.Length)] + //Gate
                                            ", " +
                                            arrayArrivalFlightStatus[randNum.Next(arrayArrivalFlightStatus.Length)] + //FlightStatus
                                            ", " +
                                            arrayСompanyName[randNum.Next(arrayСompanyName.Length)] + //CompanyName
                                            ", " +
                                            arrayAirplaneType[randNum.Next(arrayAirplaneType.Length)] + //AirplaneType
                                            ", " +
                                            "'" +
                                            randNum.Next(10).ToString() + //BoardingGateNum
                                            "')";
        }
        startFlightNumber += 1+randNum.Next(10);
        amount+=command.ExecuteNonQuery();
        //Console.WriteLine(command.CommandText);
        command.CommandText = string.Empty;
    }
    Console.WriteLine($"В таблицу Flights добавлено объектов: {amount}");

}

Console.Read();
