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
        String username, uid;


        public void getEvents()
        {
            con.Open();
            usernamedisplay.Content = username;
            DataTable dt = new DataTable();
            String syntax = "SELECT * from adminDB";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();

            /*foreach(DataRow row in dt.Rows)
            {
                if (!(row["uid"].ToString().Contains(username))) ;
                {
                    row.Delete();
                }
            }*/
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                if (!(row["uid"].ToString().Contains(uid)))
                {
                    row.Delete();
                }
            }
            dt.AcceptChanges();
            dt.Columns.Remove("uid");
            dt.AcceptChanges();
            datagrid.DataContext = dt.DefaultView;
        }

        public Dashboard(string _username, String _uid)
        {
            InitializeComponent();
            username = _username;
            uid = _uid;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterEvent reg = new RegisterEvent(uid);
            reg.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private void website_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Multiple Items Selected, select only 1");
            }
            else
            {
                DataRowView row = datagrid.SelectedItem as DataRowView;
                //MessageBox.Show(row.Row.ItemArray[4].ToString());
                webpage web = new webpage(row.Row.ItemArray[4].ToString());
                web.Show();
                 
                
            }
        }

        private void listevent_Click(object sender, RoutedEventArgs e)
        {
            getEvents();
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItems.Count > 1)
            {
                MessageBox.Show("Multiple Items Selected, select only 1");
            }
            else
            {
                DataRowView row = datagrid.SelectedItem as DataRowView;
                //MessageBox.Show(row.Row.ItemArray[4].ToString());
                modifyEvent mod = new modifyEvent();
                mod.eventName.Text = row.Row.ItemArray[2].ToString();
                mod.col.Text = row.Row.ItemArray[1].ToString();
                mod.time.Text = row.Row.ItemArray[3].ToString();
                mod.evID.Text = row.Row.ItemArray[0].ToString();
                mod.web.Text = row.Row.ItemArray[4].ToString();
                mod.Show();
            
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            getEvents();
        }
    }
}
