class Room
{
    private List<SmartDevice> _devices = new List<SmartDevice>();

    public Room(List<SmartDevice> devices)
    {
        _devices = devices;
    }

    public String getDevices()
    {
        return "";
    }

    public void TurnOffLights()
    {
        foreach( SmartDevice device in _devices)
        if(device.GetDeviceType().ToLower() == "light") 
        {
            device.TurnOff();
        }
    }
    public void TurnOffAll()
    {
        _devices.ForEach(device => device.TurnOff());
    }
    public void TurnOnAll()
    {
        _devices.ForEach(device => device.TurnOn());    
    }

    public void ReportAll()
    {
        _devices.ForEach(device => Console.WriteLine(device.Report()));
    }

    public void ReportOn()
    {
        foreach(SmartDevice device in _devices)
        {
            if(device.GetState() == "on")
            {
                Console.WriteLine(device.Report());
            }
        }
    }

    public void ReportLongest()
    {
        string longestReport = "";
        int longestReportLength = 0;

        foreach(SmartDevice device in _devices)
        {
            if(device.GetState() == "on")
            {
                string report = device.Report();
                if(report.Length > longestReportLength)
                {
                    longestReportLength = report.Length;
                    longestReport = report;
                }
            }
        }

        if(longestReportLength == 0)
        {
            Console.WriteLine("There are no devices on in this room");
        }
        else 
        {
            Console.WriteLine(longestReport);
        }
    }
}