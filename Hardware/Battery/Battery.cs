using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHardwareMonitor.Hardware.Battery {
  internal class Battery : Hardware {
    public override HardwareType HardwareType {
      get { return HardwareType.Battery; }
    }

    private BatteryInformation bi;
    private readonly Sensor fullChargeCapacity/*, powerState*/, currentCapacity, voltage/*, rate*/, capacityPercent;

    public Battery(ISettings settings): base("Battery", new Identifier("Battery"), settings) {
      int sensorIndex = 0;

      fullChargeCapacity = new Sensor("Battery FC", sensorIndex++, SensorType.Energy, this, settings);
      currentCapacity = new Sensor("Battery CC", sensorIndex++, SensorType.Energy, this, settings);
      voltage = new Sensor("Battery V", sensorIndex++, SensorType.Voltage, this, settings);
      capacityPercent = new Sensor("Battery CC%", sensorIndex++, SensorType.Load, this, settings);

      ActivateSensor(fullChargeCapacity);
      ActivateSensor(currentCapacity);
      ActivateSensor(voltage);
      ActivateSensor(capacityPercent);
    }

    public override void Update() {
      bi = BatteryInfo.GetBatteryInformation();

      fullChargeCapacity.Value = bi.FullChargeCapacity;
      currentCapacity.Value = bi.CurrentCapacity;
      voltage.Value = bi.Voltage / 1000f;
      capacityPercent.Value = ((float)bi.CurrentCapacity / (float)bi.FullChargeCapacity) * 100f;
    }
  }
}
