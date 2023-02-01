using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static System.Net.Mime.MediaTypeNames;

namespace SfChartTrackball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            Console.WriteLine(" X Value Ini : " + ((TextBlock)sender).Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.AnnotationX = vm.AnnotationX + 1;
            vm.AnnotationTxt = vm.AnnotationX.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.AnnotationX = vm.AnnotationX - 1;
            vm.AnnotationTxt = vm.AnnotationX.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            vm.AnnotationX = vm.ChartData.Count;
            vm.AnnotationTxt = vm.AnnotationX.ToString();
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DataPoint> _oChartDataCollection;

        private string _annotationTxt;
        private double _annotationX;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataPoint> ChartData
        {
            get { return _oChartDataCollection; }
            set 
            { 
                _oChartDataCollection = value;
                OnPropertyChanged(nameof(ChartData));
            }
        }

        public double AnnotationX
        {
            get { return _annotationX; }
            set 
            { 
                _annotationX = value;
                OnPropertyChanged(nameof(AnnotationX));
            }
        }
        public string AnnotationTxt
        {
            get { return _annotationTxt; }
            set 
            { 
                _annotationTxt = value;
                OnPropertyChanged(nameof(AnnotationTxt));
            }
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DataPoint
    {
        public int XValue { get; set; }

        public double YValue { get; set; }
    }
}
