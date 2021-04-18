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
    /// Interaction logic for modifyEvent.xaml
    /// </summary>
    public partial class modifyEvent : Window
    {
        public modifyEvent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private void modify_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(eventName.Text) ||
            String.IsNullOrEmpty(col.Text) ||
            String.IsNullOrEmpty(time.Text)||
            String.IsNullOrEmpty(evID.Text) ||
            String.IsNullOrEmpty(web.Text))
            {
                MessageBox.Show("One or more fields empty, please check");
            }
            else
            {
                cmd = new SqlCommand("eventModify", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eventID", Int32.Parse(evID.Text));
                cmd.Parameters.AddWithValue("@college", col.Text);
                cmd.Parameters.AddWithValue("@eventName", eventName.Text);
                cmd.Parameters.AddWithValue("@eventTime", time.Text);
                cmd.Parameters.AddWithValue("@website", web.Text);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Event Modification Success!");
                this.Close();
            }

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            eventName.Text = "";
            col.Text = "";
            time.Text = "";
            evID.Text = "";
            web.Text = "";
        }
    }
}
