using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Convertor.Views;

namespace Convertor//TODO: смысловые переменные и имена. ексепшены, попробовать упростить код делегатами с аргументами
{
    public partial class Form1 : Form, IView
    {
        public double InputDegree
        {
            get
            {
                return Convert.ToDouble(_inputBox.Text);
            }
        }

        public int InputIndexSelected { get; private set; } = -1;
        public int OutputIndexSelected { get; private set; } = -1;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        public event EventHandler<EventArgs> SetedTemperature;

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputIndexSelected = comboBox1.SelectedIndex;
        }

        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutputIndexSelected = comboBox2.SelectedIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("По шкале Цельсия");
            comboBox1.Items.Add("По шкале Фаренгейта");
            comboBox1.Items.Add("По шкале Кельвина");

            comboBox2.Items.Add("По шкале Цельсия");
            comboBox2.Items.Add("По шкале Фаренгейта");
            comboBox2.Items.Add("По шкале Кельвина");
        }

        public void SetTemperature(double value)
        {
            _outputBox.Text = value.ToString();
        }

        private void translateDegreeButton_Click(object sender, EventArgs e)
        {
            double test;
            if (!double.TryParse(_inputBox.Text, out test))
            {
                MessageBox.Show("Введен неверный формат данных. Введите число");
            }
            else if (InputIndexSelected == -1 || OutputIndexSelected == -1)
            {
                MessageBox.Show("Выберите исходную/конечную шкалу");
            }
            else
            {
                SetedTemperature?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
