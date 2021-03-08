using System;
using System.Collections.Generic;
using static AlarmSystem.BatteryChecker;
namespace AlarmSystem
{
    public interface ISensor
    {
        bool IsTriggered { get; set; }
        string GetLocation();
        string GetSensorType();
        public void SetLocation(string location);
    }

    public interface IBatterySensor
    {
        int Battery { get; set; }
        double GetBatteryPercentage();
        bool IsTriggered { get; set; }
        string GetLocation();
        string GetSensorType();
        public void SetLocation(string location);


    }
    public class ExtendedControlUnit : ControlUnit
    {
        //readonly List<ISensor> _sensors;
        //readonly List<IBatterySensor> _battery;
        public ExtendedControlUnit(Object sensors) : base(sensors) { }
        //public ExtendedControlUnit(List<IBatterySensor> batterysensors) : base(batterysensors) { }

        public void SecurityControlUnit()
        {
            var start = new TimeSpan(22, 0, 0);
            var end = new TimeSpan(06, 0, 0);
            var now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end))
            {
                base.PollSensors();
            }
            else
            {
                Console.WriteLine("Polling of sensors is not allowed outside scheduled hours");
            }
        }
        

    }

    public class ControlUnit
    {
        // Injected dependency to the constructor

        readonly List<ISensor> _sensors;
        readonly List<IBatterySensor> _batterysensors;

        public ControlUnit(List<ISensor> sensor) => this._sensors = sensor;
        public ControlUnit(List<IBatterySensor> sensor) => this._batterysensors = sensor;

        public ControlUnit(Object sensors)
        {
            if (sensors == null)
            {
             throw new NullReferenceException("Control unit needs at least a sensor.");
            }else if(!(sensors is List<ISensor> || sensors is List<IBatterySensor>))
            {
                //throw new Exception("Control Unit can only work with sensor objects.");
            }else if (sensors is List<ISensor>)
            {
                this._sensors = (List<ISensor>) sensors;
            }
            else
            {
                this._batterysensors = (List<IBatterySensor>) sensors;
            }
        }

        public void PollSensors()
        {
            // We added the logic to reduce the battery at each poll, regardless of whether the sensor has been triggered or not.
            foreach (IBatterySensor sensor in _batterysensors)
            {
                if (sensor.IsTriggered)
                {
                    if (sensor.GetType().ToString() != "AlarmSystem.MotionSensor")
                    {
                        sensor.Battery -= sensor.GetSensorType().ReduceBattery();
                    }
                    Console.WriteLine("A " + sensor.GetSensorType() + " sensor was triggered at " + sensor.GetLocation());

                }
                else
                {
                    if (sensor.GetType().ToString() != "AlarmSystem.MotionSensor")
                    {
                        sensor.Battery -= sensor.GetSensorType().ReduceBattery();
                    }
                    Console.WriteLine("Polled " + sensor.GetSensorType() + " at " + sensor.GetLocation() + " successfully");

                }
            }
        }

    }

}
   


 



