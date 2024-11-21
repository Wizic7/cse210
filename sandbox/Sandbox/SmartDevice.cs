abstract class SmartDevice{
    protected Boolean _is_on;
    protected DateTime _onStartTime;
    protected String _name;
    protected String _type;

    public SmartDevice(String name){
        _name = name;
        _is_on = false;
    }

    public string GetDeviceType()
    {
        return _type;
    }
    public string GetState(){
        if(_is_on)
        {
            return "on";
        }
        return "off";
    }

    public string TimeOn(){
        if(_is_on){
            DateTime now = DateTime.Now;
            TimeSpan timeDiff = now - _onStartTime;
            String returnString = "";
            
            if(timeDiff.Days > 0)
            {
                returnString +=  timeDiff + " Days ";
            }
            if(timeDiff.Hours > 0 || returnString != "")
            {
                returnString += timeDiff.Hours + " Hours ";
            }
            if(timeDiff.Minutes > 0 || returnString != "")
            {
                returnString += timeDiff.Minutes + " Minutes and ";
            }
            returnString +=timeDiff.Seconds + " Seconds";
            
            return returnString;
        }
        return "This device is off";
    }

    public void TurnOn(){
        if(_is_on == false){
            _onStartTime = DateTime.Now;
        }
        _is_on = true;
    }

    public void TurnOff(){
        _is_on = false;
    }

    public string Report()
    {
        if(_is_on){
            return _name + " is on. It has been on for " + TimeOn();
        }
        return _name + " is off";
    }
}