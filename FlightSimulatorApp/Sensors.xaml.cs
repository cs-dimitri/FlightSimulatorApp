﻿using System;
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

namespace HomeWork
{
    /// <summary>
    /// Interaction logic for Sendors.xaml
    /// </summary>
    public partial class Sensors : UserControl
    {
        public VM_Sensor vmSensors;

        public Sensors()
        {
            InitializeComponent();
        }

        public void SetVM(VM_Sensor vM_Sensor)
        {
            this.vmSensors = vM_Sensor;
        }
    }
}
