using System;
using System.Collections.Generic;

namespace AlarmSystem
{
    class Program
    {
        static void Main(string[] args)

        {
         
            List<IBatterySensor> batterysensorsList = new List<IBatterySensor>();
            IBatterySensor smoke = new SmokeSensor();
            IBatterySensor co2 = new CO2Sensor("Boiler");
            batterysensorsList.Add(smoke);
            batterysensorsList.Add(co2);

            List<ISensor> batteryless = new List<ISensor>();
            ISensor entry = new MotionSensor("Entry");
            ISensor garage = new MotionSensor("Garage");
            batteryless.Add(entry);
            batteryless.Add(garage);
            
           
            ExtendedControlUnit controlUnit = new ExtendedControlUnit(batterysensorsList);
            ExtendedControlUnit motioncontrolUnit = new ExtendedControlUnit(batteryless);
          
            controlUnit.SecurityControlUnit();
            string input = "poll";
            while (!(input.Equals("exit")))
            {
                Console.WriteLine("Type \"poll\" to poll all sensors once or \"exit\" to exit");
                input = Console.ReadLine();
                if (input.Equals("poll"))
                {
                    controlUnit.SecurityControlUnit();
                }
            }
        }
    }
}
