﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akaryakıt_otamasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double D_benzin95 = 0, D_benzin97 = 0, D_dizel = 0, D_eurodizel = 0, D_lpg = 0;//depo bilgirini tutmak için
        double E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_eurodizel = 0, E_lpg = 0;//eklenenleri tutmak için
        double F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_eurodizel = 0, F_lpg = 0;//fiyat bilgisi
        double S_benzin95 = 0, S_benzin97 = 0, S_dizel = 0, S_eurodizel = 0, S_lpg = 0;//satılan yakıt
        string[] depo_bilgileri;
        string[] fiyat_bilgileri;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Benzin (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Benzin (97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }


            if (comboBox1.Text == "Eurodizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Lpg")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "...........";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            S_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            S_dizel = double.Parse(numericUpDown3.Value.ToString());
            S_eurodizel = double.Parse(numericUpDown4.Value.ToString());
            S_lpg = double.Parse(numericUpDown5.Value.ToString());

            if(numericUpDown1.Enabled==true)
            {
                D_benzin95 = D_benzin95 - S_benzin95;
                label29.Text = Convert.ToString(S_benzin95 * F_benzin95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                D_benzin97 = D_benzin97 - S_benzin97;
                label29.Text = Convert.ToString(S_benzin97 * F_benzin97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                D_dizel = D_dizel - S_dizel;
                label29.Text = Convert.ToString(S_dizel * F_dizel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                D_eurodizel = D_eurodizel - S_eurodizel;
                label29.Text = Convert.ToString(S_eurodizel * F_eurodizel);
            }
            else if(numericUpDown5.Enabled==true)
            {
                D_lpg= D_lpg - S_lpg;
                label29.Text = Convert.ToString(S_lpg * F_lpg);
            }

            depo_bilgileri[0] = Convert.ToString(D_benzin95);
            depo_bilgileri[1] = Convert.ToString(D_benzin97);
            depo_bilgileri[2] = Convert.ToString(D_dizel);
            depo_bilgileri[3] = Convert.ToString(D_eurodizel);
            depo_bilgileri[4]= Convert.ToString(D_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt",depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressBar_güncelle();
            numericupdown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox6.Text) / 100);
                fiyat_bilgileri[0]=Convert.ToString(F_benzin95);

            }
            catch (Exception)
            {

                textBox6.Text = "hata";
            }
            try
            {
                F_benzin97 = F_benzin97 + (F_benzin97 * Convert.ToDouble(textBox7.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(F_benzin97);

            }
            catch (Exception)
            {

                textBox7.Text = "hata";
            }
            try
            {
                F_dizel = F_dizel + (F_dizel * Convert.ToDouble(textBox8.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(F_dizel);

            }
            catch (Exception)
            {

                textBox8.Text = "hata";
            }
            try
            {
                F_eurodizel = F_eurodizel + (F_eurodizel * Convert.ToDouble(textBox9.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(F_eurodizel);

            }
            catch (Exception)
            {

                textBox9.Text = "hata";
            }
            try
            {
                F_lpg = F_lpg + (F_lpg * Convert.ToDouble(textBox10.Text) / 100);
                fiyat_bilgileri[4] = Convert.ToString(F_lpg);

            }
            catch (Exception)
            {

                textBox10.Text = "hata";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt",fiyat_bilgileri);
            txt_fiyat_oku();
            txt_fiyat_yaz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < D_benzin95 + E_benzin95 || E_benzin95 <= 0)
                    textBox1.Text = "hata";
                else
                    depo_bilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);

            }
            catch (Exception)
            {

                textBox1.Text = "hata"; 
            }


            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < D_benzin97 + E_benzin97 || E_benzin97 <= 0)
                    textBox2.Text = "hata";
                else
                    depo_bilgileri[1] = Convert.ToString(D_benzin97 + E_benzin97);
                    

            }
            catch (Exception)
            {

                textBox2.Text = "hata";
            }

            try
            {
                E_dizel= Convert.ToDouble(textBox3.Text);
                if (1000 < D_dizel + E_dizel || E_dizel <= 0)
                    textBox3.Text = "hata";
                else
                    depo_bilgileri[2] = Convert.ToString(D_dizel + E_dizel);

            }
            catch (Exception)
            {

                textBox3.Text = "hata";
            }
            try
            {
                E_eurodizel = Convert.ToDouble(textBox4.Text);
                if (1000 < D_eurodizel + E_eurodizel || E_eurodizel <= 0)
                    textBox4.Text = "hata";
                else
                    depo_bilgileri[3] = Convert.ToString(D_eurodizel + E_eurodizel);

            }
            catch (Exception)
            {

                textBox4.Text = "hata";
            }
            try
            {
                E_lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < D_lpg + E_lpg || E_lpg <= 0)
                    textBox5.Text = "hata";
                else
                    depo_bilgileri[4] = Convert.ToString(D_lpg + E_lpg);

            }
            catch (Exception)
            {

                textBox5.Text = "hata";
            }
            
            System.IO.File.WriteAllLines(Application.StartupPath+"\\depo.txt",depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressBar_güncelle();
            numericupdown_value();
            
            
        }

        
        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_dizel = Convert.ToDouble(depo_bilgileri[2]);
            D_eurodizel = Convert.ToDouble(depo_bilgileri[3]);
            D_lpg = Convert.ToDouble(depo_bilgileri[4]);
        }
        private void txt_depo_yaz()
        {
            label6.Text = D_benzin95.ToString("N");
            label7.Text = D_benzin97.ToString("N");
            label8.Text = D_dizel.ToString("N");
            label9.Text=D_eurodizel.ToString("N");
            label10.Text=D_lpg.ToString("N");
        }
        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95=Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            F_eurodizel= Convert.ToDouble(fiyat_bilgileri[3]);
            F_lpg = Convert.ToDouble(fiyat_bilgileri[4]);
        }
        private void txt_fiyat_yaz()
        {
            label15.Text=F_benzin95.ToString("N");
            label14.Text=F_benzin97.ToString("N");
            label18.Text=F_dizel.ToString("N");
            label17.Text=F_eurodizel.ToString("N");
            label16.Text=F_lpg.ToString("N");
        }
        private void progressBar_güncelle()
        {
            progressBar1.Value=Convert.ToUInt16(D_benzin95);
            progressBar2.Value=Convert.ToUInt16(D_benzin97);
            progressBar3.Value = Convert.ToUInt16(D_dizel);
            progressBar4.Value = Convert.ToUInt16(D_eurodizel);
            progressBar5.Value = Convert.ToUInt16(D_lpg);
        }
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum=decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_eurodizel.ToString());
            numericUpDown5.Maximum=decimal.Parse(D_lpg.ToString()); 
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "akaryakıt otamasyonu";
            progressBar1.Maximum = 1000; //progresbarın maximum değeri
            progressBar2.Maximum = 1000;
            progressBar3.Maximum= 1000;
            progressBar4.Maximum= 1000;
            progressBar5.Maximum= 1000;
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progressBar_güncelle();

            string[] yakıt_türleri = { "Benzin (95)", "Benzin (97)", "Dizel", "Eurodizel", "Lpg" };
            comboBox1.Items.AddRange(yakıt_türleri);


            numericUpDown1.Enabled = false;//dışarıdan yazı yazılmaması için
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;//satış bölümünde artış 2"şer 2"şer olması için 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;


            numericUpDown1.Increment = 0.1M;//arttırmanın virgülden sonra başlaması için
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;


            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

         
            
        }
    }
}
