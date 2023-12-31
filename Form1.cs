﻿using System;
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

            if (txtEkran.Text.Substring(txtEkran.Text.Length - 1, 1) == "/" || txtEkran.Text.Substring(txtEkran.Text.Length - 1, 1) == "*" || txtEkran.Text.Substring(txtEkran.Text.Length - 1, 1) == "-" || txtEkran.Text.Substring(txtEkran.Text.Length - 1, 1) == "+" || txtEkran.Text.Substring(txtEkran.Text.Length - 1, 1) == "x")
                txtEkran.Text = txtEkran.Text.Substring(0, txtEkran.Text.Length - 1);

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
                txtEkran.Text = txtEkran.Text;
        }
        private decimal Bol(object sender)
        {
            if (btnBol == sender)
            {
                try
                {
                    int index = txtEkran.Text.IndexOf("/");
                    decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                    decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                    decimal snc = Math.Round(deger1 / deger2, 4);
                    return (decimal)snc;
                }
                catch (Exception)
                {
                    string[] gg = txtEkran.Text.Split('/');
                    decimal sonuc = 0;
                    if (gg[0] == "")
                        gg[0] = "0";
                    else
                        sonuc = Convert.ToDecimal(gg[0]);
                    try
                    {
                        for (int i = 1; i <= gg.Length - 1; i++)
                        {
                            sonuc = sonuc / Convert.ToDecimal(gg[i]);
                        }
                        return sonuc;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }
        private decimal Carp(object sender)
        {
            if (btnCarp == sender)
            {
                try
                {
                    int index = txtEkran.Text.Replace("*", "x").IndexOf("x");
                    decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                    decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                    decimal snc = Math.Round(deger1 * deger2, 4);
                    return (decimal)snc;
                }
                catch (Exception)
                {
                    string[] gg = txtEkran.Text.Replace("*","x").Split('x');
                    decimal sonuc = 0;
                    if (gg[0] == "")
                        gg[0] = "0";
                    else
                        sonuc = Convert.ToDecimal(gg[0]);
                    try
                    {
                        for (int i = 1; i <= gg.Length - 1; i++)
                        {
                            sonuc = sonuc * Convert.ToDecimal(gg[i]);
                        }
                        return sonuc;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }
        private decimal Cikar(object sender)
        {
            if (btnCikar == sender)
            {
                try
                {
                    int index = txtEkran.Text.IndexOf("-");
                    decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                    decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                    decimal snc = Math.Round(deger1 - deger2, 4);
                    return (decimal)snc;
                }
                catch (Exception)
                {
                    string[] gg = txtEkran.Text.Split('-');
                    decimal sonuc = 0;
                    if (gg[0] == "")
                        gg[0] = "0";
                    else
                        sonuc = Convert.ToDecimal(gg[0]);
                    try
                    {
                        for (int i = 1; i <= gg.Length - 1; i++)
                        {
                            sonuc = sonuc - Convert.ToDecimal(gg[i]);
                        }
                        return sonuc;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }
        private decimal Topla(object sender)
        {
            if (btnTopla == sender)
            {
                try
                {
                    int index = txtEkran.Text.IndexOf("+");
                    decimal deger1 = Convert.ToDecimal(txtEkran.Text.Substring(0, index));
                    decimal deger2 = Convert.ToDecimal(txtEkran.Text.Substring((index + 1), (txtEkran.Text.Length - (index + 1))));
                    decimal snc = Math.Round(deger1 + deger2, 4);
                    return (decimal)snc;
                }
                catch (Exception)
                {
                    string[] gg = txtEkran.Text.Split('+');
                    decimal sonuc = 0;
                    if (gg[0] == "")
                        gg[0] = "0";
                    else
                        sonuc = Convert.ToDecimal(gg[0]);
                    try
                    {
                        for (int i = 1; i <= gg.Length - 1; i++)
                        {
                            sonuc = sonuc + Convert.ToDecimal(gg[i]);
                        }
                        return sonuc;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
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
                e.Handled = true; //Etkisizleştir
            }
        }
    }
}
