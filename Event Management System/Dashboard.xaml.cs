using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String username;
        public Dashboard(string _username)
        {
            InitializeComponent();
            username = _username;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterEvent reg = new RegisterEvent();
            reg.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            usernamedisplay.Content = username;
            DataTable dt = new DataTable();
            String syntax = "SELECT * from adminDB";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
        }
    }
}
