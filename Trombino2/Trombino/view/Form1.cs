using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trombino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(216, 216, 216);

            // couleurs du bandeau des pages
            panel1.BackColor = Color.FromArgb(128, 128, 128); //gris
            panel2.BackColor = Color.FromArgb(192, 0, 0); // Rouge

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.Items.Add(new { Text = "Service Recrutement", Value = "RH" });
            comboBox1.Items.Add(new { Text = "Département LLD", Value = "LLD" });
            comboBox1.Items.Add(new { Text = "Département LJM", Value = "LJM" });
            comboBox1.Items.Add(new { Text = "Département LBT", Value = "LBT" });
            comboBox1.Items.Add(new { Text = "Service EOP", Value = "EOP" });
            comboBox1.Items.Add(new { Text = "Tous", Value = "Tous" });




        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AfficherLesImages();
            AfficherTousNoms();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            //label2.Text = " vous avez choisi : " + nom;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AfficherDetails(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AfficherDetails(2);
            //label2.Text = "photo appelée 2";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AfficherDetails(3);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AfficherDetails(7);
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            AfficherDetails(37);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AfficherDetails(4);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AfficherDetails(5);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            AfficherDetails(6);

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            AfficherDetails(35);
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            AfficherDetails(5);
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            AfficherDetails(6);
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            AfficherDetails(7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AfficherDetails(8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            AfficherDetails(9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            AfficherDetails(10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AfficherDetails(11);

        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            AfficherDetails(39);

        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            AfficherDetails(38);

        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            AfficherDetails(36);

        }

        private void pictureBox35_Click_1(object sender, EventArgs e)
        {
            AfficherDetails(35);

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            AfficherDetails(34);

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            AfficherDetails(33);

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            AfficherDetails(32);

        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            AfficherDetails(31);

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

            AfficherDetails(30);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            AfficherDetails(29);

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            AfficherDetails(28);

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            AfficherDetails(27);

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            AfficherDetails(26);

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            AfficherDetails(25);

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            AfficherDetails(24);

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            AfficherDetails(23);

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            AfficherDetails(22);

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            AfficherDetails(21);

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            AfficherDetails(20);

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            AfficherDetails(19);

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            AfficherDetails(18);

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            AfficherDetails(17);

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            AfficherDetails(16);

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

            AfficherDetails(15);

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            AfficherDetails(14);

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            AfficherDetails(13);

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            AfficherDetails(12);
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            AfficherDetails(40);

        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            AfficherDetails(41);

        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            AfficherDetails(44);

        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            AfficherDetails(43);

        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            AfficherDetails(42);

        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            AfficherDetails(45);

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AfficherProfilRecherche();
            AfficherNomRecherche();
        }
    }
}
