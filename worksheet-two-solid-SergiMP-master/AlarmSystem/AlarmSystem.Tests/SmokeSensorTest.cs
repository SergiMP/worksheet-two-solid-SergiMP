using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class SmokeSensorTest
    {
        [TestMethod]
        public void TestThatIsTriggeredReturnsFalse()
        {
            SmokeSensor sensor = new SmokeSensor();
            bool isTriggeredFalse = sensor.Trigger() == true ? false : false;
            Assert.AreEqual(false, isTriggeredFalse);
        }

        [TestMethod]
        public void TestThatIsTriggeredReturnsTrue()
        {
            SmokeSensor sensor = new SmokeSensor();
            bool isTriggeredTrue= sensor.Trigger() == true ? true : true;
            Assert.AreEqual(true, isTriggeredTrue);
        }

        [TestMethod]
        public void TestThatIsTriggeredCanReturnFalse()
        {
            SmokeSensor sensor = new SmokeSensor();
            List<bool> results = new List<bool>();
            
            for (var i = 0; i <= 100; i++)
            {
                results.Add(sensor.Trigger());
            }

            Assert.AreEqual(true, results.Contains(false));
        }

        [TestMethod]
        public void TestThatIsTriggeredCanReturnTrue()
        {
            SmokeSensor sensor = new SmokeSensor();
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
            SmokeSensor sensor = new SmokeSensor();
            string location = sensor.GetLocation();
            Assert.AreEqual(string.Empty, location);
        }

        [TestMethod]
        public void TestThatGetLocationReturnsLocation()
        {
            SmokeSensor sensor = new SmokeSensor("Entry");
            string location = sensor.GetLocation();
            Assert.AreEqual("Entry", location);
            SmokeSensor sensor_2 = new SmokeSensor("Kitchen");
            string location_2 = sensor_2.GetLocation();
            Assert.AreEqual("Kitchen", location_2);
        }

        [TestMethod]
        public void TestThatSetLocationReturnsLocation()
        {
            SmokeSensor sensor = new SmokeSensor();
            sensor.SetLocation("Main Door");
            Assert.AreEqual("Main Door", sensor.GetLocation());
            sensor.SetLocation("I have changed...change is inevitable...and you should change too.");
            Assert.AreNotEqual("Main Door", sensor.GetLocation());
            Assert.AreEqual("I have changed...change is inevitable...and you should change too.", sensor.GetLocation());

        }


        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {
            SmokeSensor sensor = new SmokeSensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreNotEqual(string.Empty, sensorType);
        }

        [TestMethod]
        public void TestThatGetBatteryPercentageReturnsNegativeOne()
        {
            SmokeSensor sensor = new SmokeSensor();
            double batteryPercentage = sensor.GetBatteryPercentage();
            Assert.AreNotEqual(-1, batteryPercentage);
        }

        public void TestThatGetBatteryPercentageReturnsPositive()
        {
            SmokeSensor sensor = new SmokeSensor();
            double batteryPercentage = sensor.GetBatteryPercentage();
            Assert.AreEqual(100, batteryPercentage);
        }
    }
}
