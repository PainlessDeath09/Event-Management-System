using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Event_Management_System
{
    /// <summary>
    /// Interaction logic for webpage.xaml
    /// </summary>
    public partial class webpage : Window
    {
        string url;
        public webpage(string _url)
        {
            InitializeComponent();
            url = _url;
        }
    }
}
