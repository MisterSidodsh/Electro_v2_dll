using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electro_v2_dll;

namespace Electro_v2
{
    public partial class Main : Form
    {
        private PowerSocket _socket = new PowerSocket();
        public Main()
        {
            InitializeComponent();
        }

        public void RefreshInfo()
        {
            textBox1.Text = $"Total power: {_socket.GetTotalPower()}";
        }

        private void AddButton_Click(object sender, EventArgs e) // add
        {
            AddOrEditForm addEditForm = new AddOrEditForm();
            addEditForm.ShowDialog();
            if (addEditForm.Result == DialogResult.OK)
            {
                listBox1.Items.Add(
                    $"{addEditForm.Appliance.Name} {addEditForm.Appliance.Power}W {addEditForm.Appliance.RequiredVoltage}V");
                _socket.AddAppliance(addEditForm.Appliance);
                RefreshInfo();
            }
            addEditForm.Dispose();
        }

        private void DeleteButton_Click(object sender, EventArgs e) // delete
        {
            if (listBox1.SelectedItem == null) return;
            _socket.RemoveAppliance(_socket.GetElectricalAppliancesList()[listBox1.SelectedIndex]);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            RefreshInfo();
        }

        private void EditButton_Click(object sender, EventArgs e) // edit
        {
            if (listBox1.SelectedItem != null)
            {
                AddOrEditForm addEditForm = new AddOrEditForm(_socket.GetElectricalAppliancesList()[listBox1.SelectedIndex]);
                addEditForm.ShowDialog();
                if (addEditForm.Result == DialogResult.OK)
                {
                    _socket.GetElectricalAppliancesList()[listBox1.SelectedIndex] = addEditForm.Appliance;
                    RefreshInfo();
                }
                addEditForm.Dispose();
            }
        }

        private void RandomButton_Click(object sender, EventArgs e) // random
        {
            _socket = ApplianceFactory.CreatePowerSocket();
            List<ElectricalAppliance> applianceList = _socket.GetElectricalAppliancesList();
            listBox1.Items.Clear();
            foreach (var appliance in applianceList)
            {
                listBox1.Items.Add($"{appliance.Name} {appliance.Power}W {appliance.RequiredVoltage}V");
            }
            RefreshInfo();
        }
    }
}
