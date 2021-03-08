using System;
using System.Runtime.CompilerServices;

namespace AlarmSystem
{

    // This class deals with the triggering of Alarms and potentially the
    // reset sensor alarm functions.
    

    // Reduces the battery of the different types of sensors, can potentially add methods to
    // recharge the battery.
    public static class BatteryChecker
    {
        public static int ReduceBattery(this string Type)
        {
            switch (Type)
            {
                case "Fire sensor":
                    return 10;
                case "Smoke sensor":
                    return 20;
                case "CO2 sensor":
                    return 15;
                default:
                    return 0;
            }
        }

    }

    public abstract class Sensors : ISensor
    {


           public string Location { get; set; }

           public bool IsTriggered { get; set; }

        public bool Trigger()
            {

               var Type = this.GetSensorType().ToString();
               int probability = 0;
               Random rnd = new Random();
              switch (Type)
              {
                case "Fire sensor":
                    probability = 5;
                    break;
                case "Smoke sensor":
                    probability = 10;
                    break;
                case "CO2 sensor":
                    probability = 2;
                    break;
                case "Motion sensor":
                    probability = 50;
                    break;
                default:
                    Console.WriteLine("This sensor is not recognized.");
                    break;
              }

                 IsTriggered = probability >= rnd.Next(1, 101);

                 return IsTriggered;
            }



        public string GetLocation()
            {
                return this.Location;
            }

            public void SetLocation(string location)
            {
                this.Location = location;
            }

            public string GetSensorType()
            {
                var typeSensor = this.GetType()
                    .ToString()
                    .Split(".")[1]
                    .Split(new string[] {"Sensor"}, StringSplitOptions.None)[0]
                    .ToString();
                return $"{typeSensor} sensor";
            }         


        }

        public abstract class BatterySensors : IBatterySensor
    {
        public string Location { get; set; }
        public int Battery { get; set; }
        
        public bool IsTriggered { get; set; }

        public void SetLocation(string location)
        {
            this.Location = location;
        }
        public string GetLocation()
        {
            return this.Location;
        }

        public string GetSensorType()
        {
            var typeSensor = this.GetType()
           .ToString()
           .Split(".")[1]
           .Split(new string[] { "Sensor" }, StringSplitOptions.None)[0]
           .ToString();
            return $"{typeSensor} sensor";
        }

        protected int SetBattery()
        {
            return this.GetSensorType().ReduceBattery();
        }


        public double GetBatteryPercentage()
        {
            return (this.Battery / 100.0) * 100;
        }

        public bool Trigger()
        {

            var Type = this.GetSensorType().ToString();
            int probability = 0;
            Random rnd = new Random();
            switch (Type)
            {
                case "Fire sensor":
                    probability = 5;
                    break;
                case "Smoke sensor":
                    probability = 10;
                    break;
                case "CO2 sensor":
                    probability = 2;
                    break;
                default:
                    Console.WriteLine("This sensor is not recognized.");
                    break;
            }

            IsTriggered = probability >= rnd.Next(1, 101);

            return IsTriggered;
        }


    }



    public class MotionSensor: Sensors
    {

        public MotionSensor()
        {
            this.Location = "";
        }

        public MotionSensor(string location)
        {
            this.Location = location;
        }
    }

    public class FireSensor : BatterySensors
    {


            public FireSensor()
            {
                Battery = 100;
                this.Location = "";

            }

            // Constructor Overloading to reflect location.
            public FireSensor(string location)
            {
                this.Battery = 100;
                this.Location = location;
            }

        }

        public class SmokeSensor : BatterySensors
    {

            public SmokeSensor()
            {
                this.Battery = 100;
                this.Location = "";

            }

            // Constructor Overloading to reflect location.
            public SmokeSensor(string location)
            {
                this.Battery = 100;
                this.Location = location;
            }

        }

        public class CO2Sensor : BatterySensors
    {
            public CO2Sensor()
            {
                this.Battery = 100;
                this.Location = "";
            }

            public CO2Sensor(string location)
            {
                this.Battery = 100;
                this.Location = location;
            }

        }
    }

