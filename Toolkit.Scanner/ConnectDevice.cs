namespace Toolkit.Scanner
{
    using System;
    using WIA;

    public class ConnectDevice : IDisposable
    {
        private DeviceManager _deviceManager;
        private Device _wiaDev;
        private CommonDialog _wiaDiag;
        private Item _scaner;

        public CommonDialog WiaDiag { get { return _wiaDiag ?? new CommonDialog(); } }
        public Item Scaner { get { return _scaner; } }

        public void ConnectScanner(string scanerGuid = "")
        {
            _deviceManager = new DeviceManager();
            if (scanerGuid == "")
            {
                _wiaDev = _deviceManager.DeviceInfos.get_Item(1).Connect();
            }
            else
            {
                for (var i = 1; i < _deviceManager.DeviceInfos.Count + 1; i++)
                {
                    if ((string)_deviceManager.DeviceInfos[i].Properties.GetProperty(3) != scanerGuid)
                    {
                        _wiaDev = _deviceManager.DeviceInfos.get_Item(i).Connect();
                        return;
                    }
                }
            }
            _scaner = _wiaDev.Items[1];
        }

        /// <summary>
        /// The select scaner.
        /// </summary>
        public void SelectScaner(Device device = null)
        {
            _wiaDiag = _wiaDiag ?? new CommonDialog();
            _wiaDev = device ?? _wiaDiag.ShowSelectDevice(WiaDeviceType.CameraDeviceType, false, false);
            _scaner = _wiaDev.Items[1];
        }

        public void Dispose()
        {
            _deviceManager = null;
            _wiaDiag = null;
            _wiaDev = null;
        }
    }
}
