using Newtonsoft.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace gavno
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


        private void in_Click(object sender, RoutedEventArgs e)
        {
            var json = ApiHelper.get_all_staff();
            var result = JsonConvert.DeserializeObject<List<Staff>>(json);



            foreach (var record in result)
            {
                if (login.Text == record.login && password.Text == record.password)
                {

                    byte[] in_passwordBytes = Encoding.UTF8.GetBytes(password.Text);
                    byte[] base_passwordBytes = Encoding.UTF8.GetBytes(record.password);
                    byte[] base_saltedPassword = new byte[record.salt.Length + Encoding.UTF8.GetBytes(record.password).Length];
                    byte[] out_saltedPassword = new byte[record.salt.Length + Encoding.UTF8.GetBytes(password.Text).Length];

                    using var hash = new SHA256CryptoServiceProvider();

                    /*byte[] bytHash = hashAlg.ComputeHash(bytValue);
                    return Convert.ToBase64String(bytHash);*/

                    byte[] base_hashed = hash.ComputeHash(base_saltedPassword);

                    byte[] out_hashed = hash.ComputeHash(out_saltedPassword);

                    if (Convert.ToBase64String(base_hashed) == Convert.ToBase64String(out_hashed))
                    {
                        tables tables_ = new tables();
                        tables_.Show();
                        this.Close();

                    }

                    


                }
            }




        }
    }
}