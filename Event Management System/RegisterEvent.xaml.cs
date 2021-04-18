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
    /// Interaction logic for RegisterEvent.xaml
    /// </summary>
    public partial class RegisterEvent : Window
    {
        String username;

        public RegisterEvent(string _username)
        {
            InitializeComponent();
            username = _username;
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String Ename = eventName.Text, college = col.Text, Etime = time.Text, eID = evID.Text, website = web.Text;
            cmd = new SqlCommand("EventAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eventID", eID);
            cmd.Parameters.AddWithValue("@college", college);
            cmd.Parameters.AddWithValue("@eventName", Ename);
            cmd.Parameters.AddWithValue("@eventTime", Etime);
            cmd.Parameters.AddWithValue("@uid", username);
            cmd.Parameters.AddWithValue("@website", website);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Event Registeration Success!");


            this.Close();
        }
    }
}
