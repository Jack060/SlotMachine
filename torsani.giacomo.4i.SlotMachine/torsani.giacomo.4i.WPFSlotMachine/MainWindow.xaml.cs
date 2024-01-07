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
using System.Windows.Threading;
using torsani.giacomo._4i.LibSlotMachine;

namespace torsani.giacomo._4i.WPFSlotMachine
{
    public partial class MainWindow : Window
    {
        SlotMachine s = new SlotMachine();
        bool lock1 = false;
        bool lock2 = false;
        bool lock3 = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGira_Click(object sender, RoutedEventArgs e)
        {
            if(s.coin != 0)
            {
                s.Gira();
                TxtSlot1.Text = Convert.ToString(s.let1);
                TxtSlot2.Text = Convert.ToString(s.let2);
                TxtSlot3.Text = Convert.ToString(s.let3);
                TxtCoin.Text = Convert.ToString(s.coin);
                if (s.WPFControl() == true)
                {
                    MessageBox.Show($"HAI VINTO {s.vincita} MONETE!");
                    TxtVincita.Text = Convert.ToString(s.vincita);
                }
            }
            else
            {
                MessageBox.Show("non hai abbastanza monete");
            }
            TxtCoin.Text = Convert.ToString(s.coin);
        }

        private void BtnCoin_Click(object sender, RoutedEventArgs e)
        {
            s.coin = s.coin+Convert.ToInt16(InsCoin.Text);
            TxtCoin.Text = Convert.ToString(s.coin);
            InsCoin.Text = "0";
        }

        private void BtnLock1_Click(object sender, RoutedEventArgs e)
        {
            lock2 = !lock2;
        }

        private void BtnLock2_Click(object sender, RoutedEventArgs e)
        {
            lock3 = !lock3;
        }
        
        private void BtnLock3_Click(object sender, RoutedEventArgs e)
        {
            lock1 = !lock1;
        }

        private void BtnRitira_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"HAI RITIRATO TUTTE LE MONETE, HAI VINTO {s.coin} MONETE");
            TxtCoin.Text = "0";
            s.coin = 0;
        }
    }
}