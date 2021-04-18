using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Event_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        
      
        public void getData()
        {
            //fetch data from db
            con.Open();
            String syntax = "SELECT * from personDB";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            MessageBox.Show(dr[0].ToString());

        }

       

        private void login_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            String userid = uid.Text;
            String passwd = pass.Password;
            DataTable dt = new DataTable();
            
            String syntax = "SELECT * from personDB";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            String username;
            // MessageBox.Show(dt.Rows.ToString());
            int found = 0;
            foreach(DataRow row in dt.Rows)
            {
                if(row["uid"].ToString()==userid)
                {
                    if (row["passwd"].ToString() == passwd)
                    {
                        MessageBox.Show("Login Success");
                        found = 1;
                        username = row["name"].ToString();
                        Dashboard dash = new Dashboard(username, userid);
                        this.Close();
                        dash.Show();
                    }
                    else if(String.IsNullOrEmpty(passwd))
                    {
                        MessageBox.Show("Password cannot be empty");
                        found = 1;
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrect, Please check");
                        found = 1;
                    }
                }
                
            }
            if (found == 0)
                MessageBox.Show("UserID not found. Please Register as a new user");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            register reg = new register();
            reg.Show();
        }
    }
}
