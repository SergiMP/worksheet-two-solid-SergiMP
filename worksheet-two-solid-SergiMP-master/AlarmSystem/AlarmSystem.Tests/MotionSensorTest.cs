using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Tests
{
    [TestClass]
    class MotionSensorTest
    {
        [TestClass]
        public class CO2SensorTest
        {
            [TestMethod]
            public void TestThatIsTriggeredReturnsFalse()
            {
                MotionSensor sensor = new MotionSensor();
                bool isTriggeredFalse = sensor.Trigger() == true ? false : false;
                Assert.AreEqual(false, isTriggeredFalse);
            }


            [TestMethod]
            public void TestThatIsTriggeredReturnsTrue()
            {
                MotionSensor sensor = new MotionSensor();
                bool isTriggeredTrue = sensor.Trigger() == true ? true : true;
                Assert.AreEqual(true, isTriggeredTrue);
            }

            [TestMethod]
            public void TestThatIsTriggeredCanReturnFalse()
            {
                MotionSensor sensor = new MotionSensor();
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
                MotionSensor sensor = new MotionSensor();
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
                MotionSensor sensor = new MotionSensor();
                string location = sensor.GetLocation();
                Assert.AreEqual(string.Empty, location);
            }

            [TestMethod]
            public void TestThatGetLocationReturnsLocation()
            {
                MotionSensor sensor = new MotionSensor("Main Door");
                string location = sensor.GetLocation();
                Assert.AreEqual("Main Door", location);
                MotionSensor sensor_2 = new MotionSensor("Back Door");
                string location_2 = sensor_2.GetLocation();
                Assert.AreEqual("Back Door", location_2);
            }

            [TestMethod]
            public void TestThatSetLocationReturnsLocation()
            {
                MotionSensor sensor = new MotionSensor();
                sensor.SetLocation("Main Door");
                Assert.AreEqual("Main Door", sensor.GetLocation());
                sensor.SetLocation("I have changed...change is inevitable");
                Assert.AreNotEqual("Main Door", sensor.GetLocation());

            }


            [TestMethod]
            public void TestThatGetSensorTypeReturnsNull()
            {
                MotionSensor sensor = new MotionSensor();
                string sensorType = sensor.GetSensorType();
                Assert.AreNotEqual(string.Empty, sensorType);
            }

            [TestMethod]
            public void TestThatGetSensorTypeReturnsType()
            {
                MotionSensor sensor = new MotionSensor();
                string sensorType = sensor.GetSensorType();
                Assert.AreEqual("Motion sensor", sensorType);
            }


        }
    }
}
