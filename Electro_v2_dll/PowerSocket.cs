using System;
using System.Collections.Generic;

namespace Electro_v2_dll
{
    public class PowerSocket
    {
        private readonly List<ElectricalAppliance> _socket = new List<ElectricalAppliance>();


        public void AddAppliance(ElectricalAppliance appliance)
        {
            _socket.Add(appliance);
        }

        public void RemoveAppliance(ElectricalAppliance appliance)
        {
            _socket.Remove(appliance);
        }

        public int GetTotalPower()
        {
            var totalPower = 0;
            foreach (var appliance in _socket)
                totalPower += appliance.Power;
            return totalPower;
        }

        public string[] GetAppliancesInSocketStrings()
        {
            var applianceStrings = new string[_socket.Count];
            for (var i = 0; i < _socket.Count; i++)
                applianceStrings[i] =
                    $"{_socket[i].Name}, Power: {_socket[i].Power}, Required voltage: {_socket[i].RequiredVoltage}";
            return applianceStrings;
        }

        public List<ElectricalAppliance> GetElectricalAppliancesList()
        {
            return _socket;
        }
    }

    public class Printer
    {
        public void Print(PowerSocket socket)
        {
            var appliancesList = socket.GetElectricalAppliancesList();
            var i = 1;
            foreach (var appliance in appliancesList)
            {
                Console.WriteLine(
                    $"{i}. {appliance.Name}, {appliance.Power}W, {appliance.RequiredVoltage}V required");
                ++i;
            }
                
            Console.WriteLine($"Total power: {socket.GetTotalPower()}W");
        }
    }
}