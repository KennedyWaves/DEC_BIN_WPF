using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DEC_BIN_WPF
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
        bool go = false;
        public string bindec(string bin){

            int dev_dec = 0;
        int exp=1;
        string resultado="";
        char[] cbin = bin.ToCharArray();
        int compr = cbin.Length;
        for(int x = (compr-1);x>=0;x--){
            if(cbin[x]=='1'){
                dev_dec = dev_dec + exp;
            }
            exp = exp*2;
        }
        resultado = dev_dec.ToString();
        return resultado;
        }

        public string decbin(float dec)
        {
            float mod2 = 0;
            string bin = "";
            string intra = "";
            do{
            
                mod2 = dec % 2;
                intra = mod2.ToString();
                bin = intra+bin;
                if (mod2==1){
                    dec = dec - 1;
                }
                dec = dec/2;
            }
            while(!(dec < 1));
            return bin;
        }

        public string read(bool spec)
        {
            string bin = textBox1.Text;
            int qchar = bin.Length;
            lbl_qchar.Content = "Caracteres digitados: " + qchar;
            if(spec==true){
		        bin = txtoutput.Text;
                textBox1.Text = bin;
            }
	        else{
		        bin = textBox1.Text;
            }
            return bin;
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            go = true;
            string bin = read(false);
            float dec;
            if (radio_decbin.IsChecked == true)
            {
                if (bin == "")
                {
                    bin = "0";
                }
                dec = Convert.ToSingle(bin);
                txtoutput.Text = decbin(dec);
            }
            else
            {
                if (bin == "")
                {
                    bin = "0";
                }
                txtoutput.Text = bindec(bin);
            }
        }

        private void radio_decbin_Click(object sender, RoutedEventArgs e)
        {
        }

        private void radio_bindec_Click(object sender, RoutedEventArgs e)
        {
        }

        private void radio_bindec_Checked(object sender, RoutedEventArgs e)
        {
            string bin = read(true);
            if (bin == "")
            {
                bin = "0";
            }
            txtoutput.Text = bindec(bin);
        }

        private void radio_decbin_Checked(object sender, RoutedEventArgs e)
        {
            if (go)
            {
                float dec;
                string bin = read(true);
                if (bin == "")
                {
                    bin = "0";
                }
                dec = Convert.ToSingle(bin);
                txtoutput.Text = decbin(dec);
            }
        }
    }
}
