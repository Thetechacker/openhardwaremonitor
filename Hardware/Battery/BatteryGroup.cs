using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware.CPU;

namespace OpenHardwareMonitor.Hardware.Battery {
  internal class BatteryGroup : IGroup {
    private readonly List<Battery> hardware = new List<Battery>();

    public BatteryGroup(ISettings settings) {
      hardware.Add(new Battery(settings));
    }

    public IHardware[] Hardware {
      get {
        return hardware.ToArray();
      }
    }

    public string GetReport() {
      return "<BatteryGroupNullReport>";
    }

    public void Close() {
      return;
    }
  }
}
