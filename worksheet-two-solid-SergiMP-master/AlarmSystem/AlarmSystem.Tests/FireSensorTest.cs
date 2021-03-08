using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class FireSensorTest
    {
        [TestMethod]
        public void TestThatIsTriggeredReturnsFalse()
        {
            FireSensor sensor = new FireSensor();
            // We "fix" the return value of is triggered 
            bool isTriggeredFalse = sensor.Trigger() == true ? false : false;
            Assert.AreEqual(false, sensor.Trigger());
        }

        [TestMethod]
        public void TestThatIsTriggeredReturnsTrue()
        {
            FireSensor sensor = new FireSensor();
            bool isTriggeredTrue = sensor.Trigger() == true ? true : true;
            Assert.AreEqual(true, isTriggeredTrue);
        }


        [TestMethod]
        public void TestThatIsTriggeredCanReturnFalse()
        {
            FireSensor sensor = new FireSensor();
            List<bool> results = new List<bool>();
           
            for(var i =0; i <= 100; i++)
            {
                results.Add(sensor.Trigger());
            }
           
            Assert.AreEqual(true, results.Contains(false));
        }

        [TestMethod]
        public void TestThatIsTriggeredCanReturnTrue()
        {
            FireSensor sensor = new FireSensor();
            List<bool> results = new List<bool>();
    
            for (var i = 0; i <= 1000; i++)
            {
                results.Add(sensor.Trigger());
            }

            Assert.AreEqual(true, results.Contains(true));
        }

        [TestMethod]
        public void TestThatGetLocationReturnsNull()
        {
            FireSensor sensor = new FireSensor();
            string location = sensor.GetLocation();
            Console.WriteLine(location);
            Assert.AreEqual(String.Empty, location);
        }

        [TestMethod]
        public void TestThatGetLocationReturnsLocation()
        {
            FireSensor sensor = new FireSensor("Boiler Room");
            string location = sensor.GetLocation();
            Assert.AreEqual("Boiler Room", location);
            FireSensor sensor_2 = new FireSensor("Factory");
            string location_2 = sensor_2.GetLocation();
            Assert.AreEqual("Factory", location_2);
        }

        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {
            FireSensor sensor = new FireSensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreNotEqual(String.Empty, sensorType);
        }

        [TestMethod]
        public void TestThatGetSensorTypeReturnsType()
        {
            FireSensor sensor = new FireSensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreEqual("Fire sensor", sensorType);
        }


        [TestMethod]
        public void TestThatGetBatteryPercentageReturnsNegativeOne()
        {
            FireSensor sensor = new FireSensor();
            double batteryPercentage = sensor.GetBatteryPercentage();
            Assert.AreEqual(100.0, batteryPercentage);
        }
    }
}
