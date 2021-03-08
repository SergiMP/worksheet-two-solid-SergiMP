using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class ControlUnitTest
    {
        [TestMethod]
        public void TestThatEmptyControlAcceptsDifferentSensors(){
            
        IBatterySensor fire = new FireSensor();
        IBatterySensor smoke = new SmokeSensor();
        List<IBatterySensor> sensors = new List<IBatterySensor>();
        sensors.Add(fire);
        sensors.Add(smoke);
        ExtendedControlUnit controlUnit = new ExtendedControlUnit(sensors);
        Assert.AreEqual(2,sensors.Count);
        
        ISensor door = new MotionSensor();
        ISensor garage = new MotionSensor();
        List<ISensor> motionSensors = new List<ISensor>();
        motionSensors.Add(door);
        motionSensors.Add(garage);
        ExtendedControlUnit sensorControl = new ExtendedControlUnit(motionSensors);
        Assert.AreEqual(2,motionSensors.Count);

        }
        
        // I tried to create methods that assert ThrowsException like I did for the Irational exercice,but I couldn't
        // get the to work.
  
    }
}
