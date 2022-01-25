using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RainfallModell;


namespace Rainfall_StatisticApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml öüß
    /// </summary>
    public partial class MainWindow : Window
    {
        RainValue_List rainValueItems = new RainValue_List();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string location = textboxLocation.Text;
            double amount;

            try
            {
                amount = double.Parse(textboxAmount.Text);
            }
            catch (Exception exp)
            {
                textboxAmount.Background = Brushes.Red;
                Console.Beep();
                MessageBox.Show(exp.Message);
                return;
            }

            try
            {
                RainValue r1 = new RainValue(location, amount, 
                    checkboxIsCapital.IsChecked.Value, datepickerTimeStamp.SelectedDate.Value);
                listboxRainValue.Items.Add(r1);
                rainValueItems.Add(r1);
                labelaverage.Content = $"Durchschnitt: {rainValueItems.Average:0.0}";

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }
        }

        private void TextboxAmount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            textboxAmount.Background = Brushes.White;
        }
    }
}
