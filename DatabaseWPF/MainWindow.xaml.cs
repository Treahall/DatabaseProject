using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace DatabaseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        string DataConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\ClassWork5DB.mdb";
        public MainWindow()
        {
            cn = new OleDbConnection(DataConnectionString);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            data += "EmployeeID" + "\tAssetID" + "\t\tDescription\n";
            while (read.Read())
            {
                data += read[0].ToString() +
                    "\t\t" + read[1].ToString() + 
                    "\t\t" + read[2].ToString() + "\n";

            }
            AssetsTextBox.Text = data;
            cn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            data += "EmployeeID" + "\tFirstName" + "\tLastName\n";
            while (read.Read())
            {
                data += read[0].ToString() +
                    "\t\t" + read[1].ToString() +
                    "\t\t" + read[2].ToString() + "\n";

            }
            EmployeesTextBox.Text = data;
            cn.Close();
        }
    }
}
