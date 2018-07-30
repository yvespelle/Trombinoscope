using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Trombino
{
    public partial class Form1
    {
        PictureBox[] box;
        Label[] labelListe;
        
        // conversion données brute en photo 
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }


        // efface les photos non utilisées 
        public void ViderBox()
        {
            foreach (PictureBox pb in box)
            {
                if (pb != null)
                {
                    pb.Image = null;
                }
            }
        }

        private void ViderlabelListe()
        {
            foreach (Label lb in labelListe)
            {
                if (lb != null)
                {
                    lb.Text = null;
                }
            }
        }


        public void ConstructionBox()
        {
            box = new PictureBox[50];

            box[1] = pictureBox1;
            box[2] = pictureBox2;
            box[3] = pictureBox3;
            box[4] = pictureBox4;
            box[5] = pictureBox5;
            box[6] = pictureBox6;
            box[7] = pictureBox7;
            box[8] = pictureBox8;
            box[9] = pictureBox9;
            box[10] = pictureBox10;
            box[11] = pictureBox11;
            box[12] = pictureBox12;
            box[13] = pictureBox13;
            box[14] = pictureBox14;
            box[15] = pictureBox15;
            box[16] = pictureBox16;
            box[17] = pictureBox17;
            box[18] = pictureBox18;
            box[19] = pictureBox19;
            box[20] = pictureBox20;
            box[21] = pictureBox21;
            box[22] = pictureBox22;
            box[23] = pictureBox23;
            box[24] = pictureBox24;
            box[25] = pictureBox25;
            box[26] = pictureBox26;
            box[27] = pictureBox27;
            box[28] = pictureBox28;
            box[29] = pictureBox29;
            box[30] = pictureBox30;
            box[31] = pictureBox31;
            box[32] = pictureBox32;
            box[33] = pictureBox33;
            box[34] = pictureBox34;
            box[35] = pictureBox35;
            box[36] = pictureBox36;
            box[37] = pictureBox37;
            box[38] = pictureBox38;
            box[39] = pictureBox39;
            box[40] = pictureBox40;
            box[41] = pictureBox41;
            box[42] = pictureBox42;
            box[43] = pictureBox43;
            box[44] = pictureBox44;
            box[45] = pictureBox45;
        }


        private void ConstructionTextBoxListe()
        {
            labelListe = new Label[50];

            labelListe[1] = label1;
            labelListe[2] = label2;
            labelListe[3] = label3;
            labelListe[4] = label4;
            labelListe[5] = label5;
            labelListe[6] = label6;
            labelListe[7] = label7;
            labelListe[8] = label8;
            labelListe[9] = label9;
            labelListe[10] = label10;
            labelListe[11] = label11;
            labelListe[12] = label12;
            labelListe[13] = label13;
            labelListe[14] = label14;
            labelListe[15] = label15;
            labelListe[16] = label16;
            labelListe[17] = label17;
            labelListe[18] = label18;
            labelListe[19] = label19;
            labelListe[20] = label20;
            labelListe[21] = label21;
            labelListe[22] = label22;
            labelListe[23] = label23;
            labelListe[24] = label24;
            labelListe[25] = label25;
            labelListe[26] = label26;
            labelListe[27] = label27;
            labelListe[28] = label28;
            labelListe[29] = label29;
            labelListe[30] = label30;
            labelListe[31] = label31;
            labelListe[32] = label32;
            labelListe[33] = label33;
            labelListe[34] = label34;
            labelListe[35] = label35;
            labelListe[36] = label36;
            labelListe[37] = label37;
            labelListe[38] = label38;
            labelListe[39] = label39;
            labelListe[40] = label40;

        }

    }


}


