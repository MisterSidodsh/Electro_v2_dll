using System;

namespace Electro_v2_dll
{
    public class ApplianceFactory
    {
        public static PowerSocket CreatePowerSocket()
        {
            var rand = new Random();
            var socket = new PowerSocket();

            string[] casualapplianceNames = {"Dishwasher", "Refrigerator", "Microwave", "TV", "Radio", "Computer", "Stereo"};
            string[] coolingApplianceNames = {"Conditioner", "Air extractor"};
            string[] fanNames = {"BlackFan", "WhiteFan"};
            int[] voltageTypes = {55, 110, 220};


            for (var i = 0; i < rand.Next(10, 50); i++)
            {
               
                var type = rand.Next(0, 2);
                switch (type)
                {
                    case 0:
                        var casualappliance = new CasualAppliance
                        {
                            Name = casualapplianceNames[rand.Next(0, casualapplianceNames.Length)],
                            Power = rand.Next(1, 1000),
                            RequiredVoltage = voltageTypes[rand.Next(0, voltageTypes.Length)]
                        };
                        socket.AddAppliance(casualappliance);
                        break;
                    case 1:
                        var coolingAppliance = new CoolingAppliance
                        {
                            Name = coolingApplianceNames[rand.Next(0, coolingApplianceNames.Length)],
                            Power = rand.Next(1, 1000),
                            RequiredVoltage = voltageTypes[rand.Next(0, voltageTypes.Length)],
                            Pressure = rand.Next(1, 8)
                        };
                        socket.AddAppliance(coolingAppliance);
                        break;
                    case 2:
                        var fan = new Fan
                        {
                            Name = fanNames[rand.Next(0, fanNames.Length)],
                            Power = rand.Next(1, 1000),
                            Pressure = rand.Next(1, 8),
                            RequiredVoltage = voltageTypes[rand.Next(0, voltageTypes.Length)],
                            RevolutionsPerSecond = rand.Next(2, 8) * 1000
                        };
                        socket.AddAppliance(fan);
                        break;
                }
            }
            return socket;
        }
    }
}
