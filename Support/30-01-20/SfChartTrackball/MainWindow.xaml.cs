using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SfChartTrackball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            Console.WriteLine(" X Value Ini : " + ((TextBlock)sender).Text);
        }
    }

    public class ViewModel
    {
        private ObservableCollection<DataPoint> _oChartDataCollection;

        public ObservableCollection<DataPoint> ChartData
        {
            get { return _oChartDataCollection; }
            set { _oChartDataCollection = value; }
        }

        public ViewModel()
        {
            var vTemp = new ObservableCollection<DataPoint>();
              for (var i = 1; i < 150; i++)
            {
                vTemp.Add(new DataPoint { XValue = i, YValue = 5 + i*0.1 });
            }

            ChartData = vTemp;
        }
    }

    public class DataPoint
    {
        public int XValue { get; set; }

        public double YValue { get; set; }
    }
}
