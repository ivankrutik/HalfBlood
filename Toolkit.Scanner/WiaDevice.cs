namespace Toolkit.Scanner
{
    internal class WiaDevice
    {
        public string DeviceID { get; private set; }
        public string Manufacturer { get; private set; }
        public string Name { get; private set; }
        public DeviceTypes Type { get; private set; }

        internal WiaDevice(WIA.IDevice device)
        {
            this.DeviceID = device.DeviceID;
            this.Name = (string)device.Properties.GetProperty(7);
            this.Manufacturer = (string)device.Properties.GetProperty(3);
            this.Type = (DeviceTypes)((int)device.Properties.GetProperty(5));
        }

    }
}
