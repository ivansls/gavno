using Newtonsoft.Json;
using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gavno
{
    /// <summary>
    /// Логика взаимодействия для tables.xaml
    /// </summary>
    public partial class tables : Window
    {
        string sel = "";
        public tables()
        {
            InitializeComponent();
            combo.ItemsSource = new List<string>() { "cheques", "cups", "discounts", "orders", "pay_types", "positions", "staff", "statuses", "users" };
        }


        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = combo.Items[combo.SelectedIndex] as string;
            Grd.SelectedItem = null;
            


            if (selected == "cheques")
            {
                var json = ApiHelper.get_all_cheques();
                var result = JsonConvert.DeserializeObject<List<Check>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "cups")
            {
                var json = ApiHelper.get_all_cups();
                var result = JsonConvert.DeserializeObject<List<Cup>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "discounts")
            {
                var json = ApiHelper.get_all_discounts();
                var result = JsonConvert.DeserializeObject<List<Discount>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "orders")
            {
                var json = ApiHelper.get_all_orders();
                var result = JsonConvert.DeserializeObject<List<Order>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "pay_types")
            {
                var json = ApiHelper.get_all_pay_types();
                var result = JsonConvert.DeserializeObject<List<PayType>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "positions")
            {
                var json = ApiHelper.get_all_positions();
                var result = JsonConvert.DeserializeObject<List<Position>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "staff")
            {
                var json = ApiHelper.get_all_staff();
                var result = JsonConvert.DeserializeObject<List<Staff>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "statuses")
            {
                var json = ApiHelper.get_all_statuses();
                var result = JsonConvert.DeserializeObject<List<Status>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "users")
            {
                var json = ApiHelper.get_all_users();
                var result = JsonConvert.DeserializeObject<List<User>>(json);
                Grd.ItemsSource = result;
            }

            sel = selected;
        }



        private void Grd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                if (sel == "cheques")
                {
                    Check check = Grd.SelectedItem as Check;
                    param1.Text = check.id.ToString();
                    param2.Text = check.order_id.ToString();
                    param3.Text = check.cheque.ToString();
                    param4.Text = check.pay_type.ToString();
                }

                if (sel == "cups")
                {
                    Cup cup = Grd.SelectedItem as Cup;
                    param1.Text = cup.id.ToString();
                    param2.Text = cup.name.ToString();
                    param3.Text = cup.cost.ToString();
                    param4.Text = cup.description.ToString();
                }

                if (sel == "discounts")
                {
                    Discount disc = Grd.SelectedItem as Discount;
                    param1.Text = disc.id.ToString();
                    param2.Text = disc.discount.ToString();
                }

                if (sel == "orders")
                {
                    Order order = Grd.SelectedItem as Order;
                    param1.Text = order.id.ToString();
                    param2.Text = order.user_id.ToString();
                    param3.Text = order.staff.ToString();
                    param4.Text = order.cost.ToString();
                    param5.Text = order.status.ToString();
                    param6.Text = order.purchased_cups.ToString();
                }

                if (sel == "pay_types")
                {
                    PayType type = Grd.SelectedItem as PayType;
                    param1.Text = type.id.ToString();
                    param2.Text = type.name.ToString();
                }


                if (sel == "positions")
                {
                    Position pos = Grd.SelectedItem as Position;
                    param1.Text = pos.id.ToString();
                    param2.Text = pos.name.ToString();
                }

                if (sel == "staff")
                {
                    Staff st = Grd.SelectedItem as Staff;
                    param1.Text = st.id.ToString();
                    param2.Text = st.name.ToString();
                    param3.Text = st.position.ToString();
                    param4.Text = st.login.ToString();
                    param5.Text = st.password.ToString();
                    param6.Text = st.salt.ToString();
                }

                if (sel == "statuses")
                {
                    Status st = Grd.SelectedItem as Status;
                    param1.Text = st.id.ToString();
                    param2.Text = st.name.ToString();
                }

                if (sel == "users")
                {
                    User user = Grd.SelectedItem as User;
                    param1.Text = user.id.ToString();
                    param2.Text = user.login.ToString();
                    param3.Text = user.password.ToString();
                    param4.Text = user.salt.ToString();
                    param5.Text = user.name.ToString();
                    param6.Text = user.all_purchase_sum.ToString();
                    param7.Text = user.discount.ToString();
                }
            }
            catch
            {
                Grd.SelectedCells.Clear();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (sel == "cheques")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.add_new_cheque(json, param2.Text.ToString(), param4.Text.ToString(), param3.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "cheques";
            }

            if (sel == "cups")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.add_new_cup(json, param2.Text.ToString(), param3.Text.ToString(), param4.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "cups";
            }

            if (sel == "discounts")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.add_new_discount(json, param2.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "discounts";
            }

            if (sel == "orders")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.add_new_order(json, param2.Text.ToString(), param3.Text.ToString(), param4.Text.ToString(), param5.Text.ToString(), param6.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "orders";
            }

            if (sel == "pay_types")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.add_new_pay_type(json, param2.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "pay_types";
            }

            if (sel == "positions")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.add_new_position(json, param2.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "positions";
            }

            if (sel == "staff")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.add_new_staff(json, param2.Text, param3.Text, param4.Text, param5.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "staff";
            }

            if (sel == "statuses")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.add_new_status(json, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "statuses";
            }

            if (sel == "users")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.add_new_user(json, param2.Text, param3.Text, param5.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "users";
            }



        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (sel == "cheques")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.update_cheque(json, param1.Text, param2.Text.ToString(), param3.Text.ToString(), param4.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "cheques";
            }

            if (sel == "cups")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.update_cup(json, param1.Text, param2.Text, param3.Text.ToString(), param4.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "cups";
            }

            if (sel == "discounts")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.update_discount(json, param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "discounts";
            }

            if (sel == "orders")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.update_order(json, param1.Text, param2.Text, param3.Text, param4.Text, param5.Text, param6.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "orders";
            }

            if (sel == "pay_types")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.update_pay_type(json, param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "pay_types";
            }

            if (sel == "positions")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_position(json, param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "positions";
            }

            if (sel == "staff")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_staff(json, param1.Text, param2.Text, param3.Text, param4.Text, param5.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "staff";
            }

            if (sel == "statuses")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_status(json, param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "statuses";
            }

            if (sel == "users")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_user(json, param1.Text, param2.Text, param3.Text, param5.Text, param6.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "users";
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (sel == "cheques")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delete_cheque(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "cheques";
            }

            if (sel == "cups")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delete_cup(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "cups";
            }

            if (sel == "discounts")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delete_discount(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "discounts";
            }

            if (sel == "orders")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delete_order(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "orders";
            }

            if (sel == "pay_types")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delete_pay_type(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "pay_types";
            }

            if (sel == "positions")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.delete_position(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "positions";
            }

            if (sel == "staff")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.delete_staff(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "staff";
            }

            if (sel == "statuses")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.delete_status(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "statuses";
            }

            if (sel == "users")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.delete_user(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "users";
            }
        }
    }
}
