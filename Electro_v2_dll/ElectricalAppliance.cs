namespace Electro_v2_dll
{
    public class ElectricalAppliance
    {
        public ElectricalAppliance()
        {
            Power = 250;
            RequiredVoltage = 220;
        }

        public string Name { get; set; }
        public int Power { get; set; }
        public int RequiredVoltage { get; set; }
    }
    public class CasualAppliance : ElectricalAppliance
    {
        public CasualAppliance()
        {
            Power = 250;
            RequiredVoltage = 220;
        }

      
    }

    public class CoolingAppliance : ElectricalAppliance
    {
        public CoolingAppliance()
        {
            Power = 250;
            RequiredVoltage = 220;
            Pressure = 8;
        }

        public int Pressure { get; set; } // давление воздушного потока в килопаскалях
    }

    public class Fan : CoolingAppliance
    {
        public Fan()
        {
            Power = 250;
            RequiredVoltage = 220;
            Pressure = 8;
            RevolutionsPerSecond = 1000;
        }

        public int RevolutionsPerSecond { get; set; } // количество оборотов в секунду
    }
}