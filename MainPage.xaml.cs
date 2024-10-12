using Microsoft.Maui.Controls;
using System;

namespace TodoList
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializePickers();
        }

        void InitializePickers()
        {
            // Distância
            distanceFromPicker.Items.Add("Metros");
            distanceFromPicker.Items.Add("Quilômetros");
            distanceFromPicker.Items.Add("Milhas");
            distanceToPicker.Items.Add("Metros");
            distanceToPicker.Items.Add("Quilômetros");
            distanceToPicker.Items.Add("Milhas");

            // Peso
            weightFromPicker.Items.Add("Gramas");
            weightFromPicker.Items.Add("Quilogramas");
            weightFromPicker.Items.Add("Libras");
            weightToPicker.Items.Add("Gramas");
            weightToPicker.Items.Add("Quilogramas");
            weightToPicker.Items.Add("Libras");

            // Temperatura
            temperatureFromPicker.Items.Add("Celsius");
            temperatureFromPicker.Items.Add("Fahrenheit");
            temperatureFromPicker.Items.Add("Kelvin");
            temperatureToPicker.Items.Add("Celsius");
            temperatureToPicker.Items.Add("Fahrenheit");
            temperatureToPicker.Items.Add("Kelvin");
        }

        void OnConvertDistance(object sender, EventArgs e)
        {
            double value = double.Parse(distanceEntry.Text);
            string fromUnit = distanceFromPicker.SelectedItem.ToString();
            string toUnit = distanceToPicker.SelectedItem.ToString();
            double result = ConvertDistance(value, fromUnit, toUnit);
            distanceResultLabel.Text = $"{result}";
        }

        void OnConvertWeight(object sender, EventArgs e)
        {
            double value = double.Parse(weightEntry.Text);
            string fromUnit = weightFromPicker.SelectedItem.ToString();
            string toUnit = weightToPicker.SelectedItem.ToString();
            double result = ConvertWeight(value, fromUnit, toUnit);
            weightResultLabel.Text = $"{result}";
        }

        void OnConvertTemperature(object sender, EventArgs e)
        {
            double value = double.Parse(temperatureEntry.Text);
            string fromUnit = temperatureFromPicker.SelectedItem.ToString();
            string toUnit = temperatureToPicker.SelectedItem.ToString();
            double result = ConvertTemperature(value, fromUnit, toUnit);
            temperatureResultLabel.Text = $"{result}";
        }

        double ConvertDistance(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit) return value;

            // Converte para metros primeiro
            if (fromUnit == "Quilômetros") value *= 1000;
            if (fromUnit == "Milhas") value *= 1609.34;

            // Converte de metros para a unidade desejada
            if (toUnit == "Quilômetros") return value / 1000;
            if (toUnit == "Milhas") return value / 1609.34;

            return value;
        }

        double ConvertWeight(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit) return value;

            // Converte para gramas primeiro
            if (fromUnit == "Quilogramas") value *= 1000;
            if (fromUnit == "Libras") value *= 453.592;

            // Converte de gramas para a unidade desejada
            if (toUnit == "Quilogramas") return value / 1000;
            if (toUnit == "Libras") return value / 453.592;

            return value;
        }

        double ConvertTemperature(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit) return value;

            // Converte para Celsius primeiro
            if (fromUnit == "Fahrenheit") value = (value - 32) * 5 / 9;
            if (fromUnit == "Kelvin") value -= 273.15;

            // Converte de Celsius para a unidade desejada
            if (toUnit == "Fahrenheit") return (value * 9 / 5) + 32;
            if (toUnit == "Kelvin") return value + 273.15;

            return value;
        }
    }
}
