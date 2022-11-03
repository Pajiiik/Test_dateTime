using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_DateTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DateTime datum_narozeni = new DateTime();
        string dat;
        int delka_cisla;
        string rodne_cislo, pr56;
        Random rng = new Random();
        long nahoda;
        string vyss, zaver;

        private void button2_Click(object sender, EventArgs e)
        {
            string pocet;
            int zeny = 0,muzi = 0;

            foreach (string s in list)
            {
                pocet = s[2].ToString() + s[3].ToString();
                if (int.Parse(pocet) > 50)
                {
                    zeny++;
                }
                else
                {
                    muzi++;
                }
            }
            maskedTextBox3.Text = "muži: " + muzi.ToString() + "    | | | | |   " + "ženy: " + zeny.ToString();
            maskedTextBox3.Visible = true;
        }

        int butt_counter = 0;
        List<string> list = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            butt_counter++;
            if (butt_counter >= 2)
                button2.Visible = true;
            rodne_cislo = "";
            datum_narozeni = dateTimePicker1.Value;


            dat = datum_narozeni.ToString("ddMMyyyy");


            delka_cisla = dat.Length;



            for (int i = delka_cisla - 2; i != delka_cisla; i++)
            {
                rodne_cislo = rodne_cislo + dat[i]; //rok
            }


            for (int i = 2; i != 4; i++)
            {
                rodne_cislo = rodne_cislo + dat[i]; //mesic
            }

            if (radioButton2.Checked)
            {
                int vysledek = int.Parse(rodne_cislo);
                vysledek = vysledek + 50;               //mesic
                rodne_cislo = vysledek.ToString();
            }


            for (int i = 0; i != 2; i++)
            {
                rodne_cislo = rodne_cislo + dat[i];
            }

            if (rodne_cislo.Length < 6)
            {
                rodne_cislo = "0" + rodne_cislo;
            }

            nahoda = rng.Next(99, 999);

            pr56 = rodne_cislo + "/" + nahoda.ToString();
            maskedTextBox1.Text = pr56;
            nahoda = (nahoda * 10) + 1;
            rodne_cislo = rodne_cislo + nahoda.ToString();
            nahoda = long.Parse(rodne_cislo);

            do
            {
                nahoda++;

                if (nahoda % 10 == 0)
                {
                    nahoda = nahoda + 10;
                }
                else if (nahoda % 100 == 0)
                {
                    nahoda = nahoda + 100;
                }
                else if (nahoda % 1000 == 0)
                {
                    nahoda = nahoda + 1000;
                }
            } while (nahoda % 11 != 0);
            zaver = "";
            vyss = nahoda.ToString();
            for (int i = 0; i < vyss.Length; i++)
            {
                if (i == 6)
                    zaver = zaver + "/";
             zaver = zaver + vyss[i].ToString();
            }

            maskedTextBox2.Text = zaver;

            list.Add(zaver);


        }
    }
}
