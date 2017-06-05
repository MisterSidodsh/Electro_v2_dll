using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electro_v2_dll;

namespace Electro_v2
{
    public partial class AddOrEditForm : Form
    {
        public ElectricalAppliance Appliance { get; set; }
        public DialogResult Result { get; set; }

        public AddOrEditForm()
        {
            InitializeComponent();
            classComboBox.Items.Add("Casual appliance");
            classComboBox.Items.Add("Cooling appliance");
            classComboBox.Items.Add("Fan");
        }

        public AddOrEditForm(ElectricalAppliance appliance) : this()
        {
            if (appliance != null)
            {
                classComboBox.Text = appliance.GetType().ToString();
                nameTextBox.Text = appliance.Name;
                powerTextBox.Text = appliance.Power.ToString();
                voltageTextBox.Text = appliance.RequiredVoltage.ToString();

                pressureTextBox.Enabled = false;
                label5.Enabled = false;
                revolutionsTextBox.Enabled = false;
                label6.Enabled = false;

                if (appliance.GetType() == typeof(CoolingAppliance))
                {
                    CoolingAppliance temporaryAppliance = (CoolingAppliance)appliance;
                    pressureTextBox.Text = temporaryAppliance.Pressure.ToString();

                    pressureTextBox.Enabled = true;
                    label5.Enabled = true;
                    revolutionsTextBox.Enabled = false;
                    label6.Enabled = false;
                }
                else if (appliance.GetType() == typeof(Fan))
                {
                    Fan temporaryAppliance = (Fan)appliance;
                    revolutionsTextBox.Text = temporaryAppliance.RevolutionsPerSecond.ToString();
                    pressureTextBox.Text = temporaryAppliance.Pressure.ToString();
                    pressureTextBox.Enabled = true;
                    label5.Enabled = true;
                    revolutionsTextBox.Enabled = true;
                    label6.Enabled = true;
                }

            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (classComboBox.SelectedIndex == 0)
            {
                Appliance = new CasualAppliance()
                {
                    Name = nameTextBox.Text,
                    Power = Convert.ToInt32(powerTextBox.Text),
                    RequiredVoltage = Convert.ToInt32(voltageTextBox.Text)
                };
            }
            if (classComboBox.SelectedIndex == 1)
            {
                Appliance = new CoolingAppliance()
                {
                    Name = nameTextBox.Text,
                    Power = Convert.ToInt32(powerTextBox.Text),
                    RequiredVoltage = Convert.ToInt32(voltageTextBox.Text),
                    Pressure = Convert.ToInt32(pressureTextBox.Text)
                };
            }
            if (classComboBox.SelectedIndex == 2)
            {
                Appliance = new Fan()
                {
                    Name = nameTextBox.Text,
                    Power = Convert.ToInt32(powerTextBox.Text),
                    RequiredVoltage = Convert.ToInt32(voltageTextBox.Text),
                    Pressure = Convert.ToInt32(pressureTextBox.Text),
                    RevolutionsPerSecond = Convert.ToInt32(revolutionsTextBox.Text)
                };
            }

            Result = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            this.Close();
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classComboBox.SelectedIndex == 0)
            {
                pressureTextBox.Enabled = false;
                label5.Enabled = false;
                revolutionsTextBox.Enabled = false;
                label6.Enabled = false;
            }
            else if (classComboBox.SelectedIndex == 1)
            {
                pressureTextBox.Enabled = true;
                label5.Enabled = true;
                revolutionsTextBox.Enabled = false;
                label6.Enabled = false;
            }
            else
            {
                pressureTextBox.Enabled = true;
                label5.Enabled = true;
                revolutionsTextBox.Enabled = true;
                label6.Enabled = true;
            }
        }
    }
}

