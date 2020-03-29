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
using Microsoft.Maps.MapControl.WPF;

namespace HomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            IFlightSimulatorModel myFlightSimulatorModel = new MyFlightSimulatorModel(new MyTelnetClient());


            VM_Sensor vmSensor = new VM_Sensor(myFlightSimulatorModel);

           // Map map = my_map;
            VM_Map vmMap = new VM_Map(myFlightSimulatorModel);





            VM_Navigator_Controller vmController = new VM_Navigator_Controller(myFlightSimulatorModel);
            Joystick_Var.SetVM(vmController);

            Sensors_Var.SetVM(vmSensor);

            DataContext = new
            {
                vmMap,
                vmSensor,
                vmController
            };

           // myFlightSimulatorModel.connect("127.0.0.1", "7771");
         //  myFlightSimulatorModel.start();

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //For sake of joystick
        private void ButtonMouse_Up(object sender, MouseButtonEventArgs e)
        {
            this.Joystick_Var.SetPiptickToCenter();
            Joystick_Var.mouseIsPressed = false;
        }


    }
}
