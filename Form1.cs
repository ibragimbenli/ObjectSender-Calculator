using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn1.Click += Btn1_Click;
            btnSil.Click += BtnSil_Click;
            txtEkran.KeyDown += new KeyEventHandler(txtEkran_KeyDown);
            txtEkran.TextChanged += new EventHandler(txtEkran_TextChanged);
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            txtEkran.Focus();
            if (txtEkran.Text.Length > 0)
                txtEkran.Text = txtEkran.Text.Substring(0, txtEkran.Text.Length - 1);
        }
        private void txtEkran_TextChanged(object sender, EventArgs e)
        {
            txtEkran.SelectionStart = txtEkran.Text.Length;
            txtEkran.ScrollToCaret();
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            txtEkran.Focus();
            txtEkran.Text += ((Button)sender).Text.Replace("*", "x");
            if (btnClean == sender)
                txtEkran.Text = string.Empty;
        }
        private void btnSonuc_Click(object sender, EventArgs e)
        {
            if (btnSonuc == sender && txtEkran.Text.Contains("/"))
            {
                txtEkran.Text = Bol(btnBol).ToString();
            }
            else if (btnSonuc == sender && (txtEkran.Text.Contains("x") || txtEkran.Text.Contains("*")))
            {
                txtEkran.Text = Carp(btnCarp).ToString();
            }
            else if (btnSonuc == sender && txtEkran.Text.Contains("-"))
            {
                txtEkran.Text = Cikar(btnCikar).ToString();
            }
            else if (btnSonuc == sender && txtEkran.Text.Contains("+"))
            {
                txtEkran.Text = Topla(btnTopla).ToString();
            }
            else
                txtEkran.Text = string.Empty;
        }
        private decimal Bol(object sender)
        {
            if (btnBol == sender)
            {
                int index = txtEkran.Text.IndexOf("/");
                decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                decimal snc = Math.Round(deger1 / deger2, 4);
                return (decimal)snc;
            }
            return 0;
        }
        private decimal Carp(object sender)
        {
            if (btnCarp == sender)
            {
                int index = txtEkran.Text.Replace("*", "x").IndexOf("x");
                decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                decimal snc = Math.Round(deger1 * deger2, 4);
                return (decimal)snc;
            }
            return 0;
        }
        private decimal Cikar(object sender)
        {
            if (btnCikar == sender)
            {
                int index = txtEkran.Text.IndexOf("-");
                decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                decimal snc = Math.Round(deger1 - deger2, 4);
                return (decimal)snc;
            }
            return 0;
        }
        private decimal Topla(object sender)
        {
            if (btnTopla == sender)
            {
                int index = txtEkran.Text.IndexOf("+");
                decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                decimal snc = Math.Round(deger1 + deger2, 4);
                return (decimal)snc;
            }
            return 0;
        }
        private void txtEkran_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSonuc_Click(btnSonuc, e);
            else if (e.KeyCode == Keys.Escape)
                txtEkran.Text = string.Empty;
            else if (e.KeyCode == Keys.Back)
            {
                if (txtEkran.Text.Length > 0)
                    txtEkran.Text = txtEkran.Text.Substring(0, txtEkran.Text.Length - 1);
            }
        }
        private void txtEkran_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '*' && e.KeyChar != '-' && e.KeyChar != '+' && e.KeyChar != ',')
            {
                e.Handled = true; // Etkisizleştir

            }
        }
    }
}
