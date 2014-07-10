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
using System.Windows.Shapes;

namespace Management_System
{
    /// <summary>
    /// Interaction logic for loading.xaml
    /// </summary>
    public partial class loading : Window
    {
        public loading()
        {
            InitializeComponent();
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(@"/Management_System;component/Resources/world.png", UriKind.Relative);
            logo.EndInit();
            BitmapImage ball = new BitmapImage();
            ball.BeginInit();
            ball.UriSource = new Uri(@"/Management_System;component/Resources/ball.png", UriKind.Relative);
            ball.EndInit();
            
            world.Source = logo;
        }
    }
}
