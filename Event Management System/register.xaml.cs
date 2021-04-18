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
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private void register1_Click(object sender, RoutedEventArgs e)
        {
            String Name = name.Text, UiD = userid.Text, Pass = pwd.Text, Email = email.Text, No = no.Text, Gender = gender.Text;

            cmd = new SqlCommand("UserAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", UiD);
            cmd.Parameters.AddWithValue("@passwd", Pass);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@contactNo", No);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Registeration Success!");
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
