### 1.Implement the FireSensor methods

   - 5% of the time it is called, it raises an alarm => Done
   - Drains 10% battery between each poll => Done 
    
### 2.Implement the SmokeSensor methods.

   - 10% of the time it is called, it raises an alarm => Done
   - Drains 20% battery between each poll => Done
   
   - (we have also created a new type of sensor CO2)
    
### 3.Investigate the ControlUnit.PollSensors() method. What are its current responsibilities? (No need to do anything,just make sure you find all responsibilities before you continue).
  
  - Poll sensor initialized the different Sensor Objects
  - Iterate through all the different sensors and:
          - Reduces the battery of each one
          - Outputs a message depending on whether the sensor has been triggered or polled correctly.

### 4.Instead of "newing up" sensors when we call PollSensors(), we want to pass a collection of sensors in to the control unit. However, we don't want to pass the sensors in when we are polling. When we poll sensors, the control unit should be configured with all of the required sensors.(Hint: Dependency Inversion Principle).

  - So if we understood correctly, PollSensors() "needs" to be provided with the collection of sensors to be polled rather than those being initialized within the method.

- What we did is to inject a dependency to Isensor, on the  ControlUnit constructor, so now it takes a collection of Isensors as requested on point 4 (If we understood correctly!!!)
        
        List<ISensor> _sensors;
        public ControlUnit(List<ISensor> sensor) => this._sensors = sensor;
 
### 5.Investigate the PollSensors method again, same as #4. What are the responsibilities now?

-PollSensors() simply iterates through the sensors, reduces the battery and outputs a message as requested.

### 6. A new use case! This is no longer an alarm system for only detecting hazards; it should now also include security such as motion and heat sensors. However, these sensors don't run on battery power so one of the ISensor interface methods is now redundant for a whole set of sensors. Which method is this and what SOLID principle does this break?

- This would mean that we cannot replace a bateryless sensor by one running on battery without breaking the code, so it breaks the Liskov Substitution principle.

### 7.Following the principle you determined in #6, solve the problem by following the presentation slide hints on this principle.

- Since we need to "isolate what changes" we will have to add a further level of abstraction, in this example we will have to "pull out" the battery methods.

- In this example we have created a **new interface** called **IBatterySensor**
- We got a **public abstract class Sensors : ISensor** and a **public abstract class BatterySensors : Sensors, IBatterySensor**
- We can now create a **Bateryless** class that inherits from **Sensors** so all the common methods, except those that involve a 
  battery are available.
- We couldn't avoid the duplication of the code since both interfaces difered only on the battery methods.

### 9.Security sensors should only be polled at night between 22:00–06:00. This is the same for all security sensors. Since we don't want to mix security sensor and hazard sensor behaviour in the same polling mechanism, we decide to make use of inheritance and create a new SecurityControlUnit which extends the existing ControlUnit. Our intention is to pass in the security sensors through the (base) parent constructor and then implement a rule that checks the current time and if it's between 22:00–06:00, we poll the sensors using the existing method, which already does the heavy lifting for us.

- => done

### 10.Which SOLID principle are we maintaining/not breaking by doing this?

 -Since we don't need to modify the base class, we are maintaining the OPEN FOR EXTENSION CLOSE FOR MODIFICATION PRINCIPLE
