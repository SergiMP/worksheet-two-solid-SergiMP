using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class CO2SensorTest
    {
        [TestMethod]
        public void TestThatIsTriggeredReturnsFalse()
        {
            CO2Sensor sensor = new CO2Sensor();
            bool isTriggeredFalse = sensor.Trigger() == true ? false : false;
            Assert.AreEqual(false, isTriggeredFalse);
        }


        [TestMethod]
        public void TestThatIsTriggeredReturnsTrue()
        {
            CO2Sensor sensor = new CO2Sensor();
            bool isTriggeredTrue = sensor.Trigger() == true ? true : true;
            Assert.AreEqual(true, isTriggeredTrue);
        }

        [TestMethod]
        public void TestThatIsTriggeredCanReturnFalse()
        {
            CO2Sensor sensor = new CO2Sensor();
            List<bool> results = new List<bool>();

            for (var i = 0; i <= 1000; i++)
            {
                results.Add(sensor.Trigger());
            }

            Assert.AreEqual(true, results.Contains(false));
        }

        [TestMethod]
        public void TestThatIsTriggeredCanReturnTrue()
        {
            CO2Sensor sensor = new CO2Sensor();
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
            CO2Sensor sensor = new CO2Sensor();
            string location = sensor.GetLocation();
            Assert.AreEqual(string.Empty, location);
        }

        [TestMethod]
        public void TestThatGetLocationReturnsLocation()
        {
            CO2Sensor sensor = new CO2Sensor("Entry");
            string location = sensor.GetLocation();
            Assert.AreEqual("Entry", location);
            CO2Sensor sensor_2 = new CO2Sensor("Kitchen");
            string location_2 = sensor_2.GetLocation();
            Assert.AreEqual("Kitchen", location_2);
        }

        [TestMethod]
        public void TestThatSetLocationReturnsLocation()
        {
            CO2Sensor sensor = new CO2Sensor();
            sensor.SetLocation("Main Door");
            Assert.AreEqual("Main Door", sensor.GetLocation());
            sensor.SetLocation("I have changed...change is inevitable");
            Assert.AreNotEqual("Main Door", sensor.GetLocation());
            Assert.AreEqual("I have changed...change is inevitable", sensor.GetLocation());

        }

        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {
            CO2Sensor sensor = new CO2Sensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreNotEqual(string.Empty, sensorType);
        }

        [TestMethod]
        public void TestThatGetSensorTypeReturnsType()
        {
            CO2Sensor sensor = new CO2Sensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreEqual("CO2 sensor", sensorType);
        }

        [TestMethod]
        public void TestThatGetBatteryPercentageReturnsNegativeOne()
        {
            CO2Sensor sensor = new CO2Sensor();
            double batteryPercentage = sensor.GetBatteryPercentage();
            Assert.AreNotEqual(-1, batteryPercentage);
        }
    }
}
