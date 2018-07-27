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
        int i;
        int j = 1;
        popup popup;


        private void connexion()
        {
            string connetionString = null;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                //label1.Text = "Connexion établie";
                SqlCommand requete = cnn.CreateCommand();
                requete.CommandText = "SELECT * FROM IDENTIFIANTS";
                SqlDataReader dataReader = requete.ExecuteReader();


                string[] tab = new string[dataReader.FieldCount];


                dataReader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Echec de connexion ! ");
            }
        }


        // -----------------------------------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------- Methode afficher les photos -----------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        private void AfficherLesImages()
        {

            // connexion à la base
            string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connetionString);
            List<ImageList> list = new List<ImageList>();
            SqlCommand cmd;
            //string val = comboBox1.Items.
            try
            {
                if (comboBox1.Text == "Tous" || comboBox1.Text == "")
                {
                    comboBox1.Text = "Tous";
                    string query = String.Format(@"SELECT PHOTO, NOM FROM IDENTIFIANTS"); // on ne recupère que l'image
                    cmd = new SqlCommand(query, sqlConn);
                }
                else
                {
                    string dept = (comboBox1.SelectedItem as dynamic).Value; // récupère la valeur correspondante au texte entré dans la combobox
                    string query = String.Format(@"SELECT PHOTO FROM IDENTIFIANTS WHERE DEPARTEMENT= @dept"); // on ne recupère que l'image
                    cmd = new SqlCommand(query, sqlConn);
                    cmd.Parameters.AddWithValue("@dept", dept);

                }

                cmd.Connection.Open();


                ConstructionBox();
                ViderBox();

                SqlDataReader reader = cmd.ExecuteReader();
                j = 1;
                while (reader.Read())
                {

                    ImageList _image = new ImageList();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        byte[] data = (byte[])reader[i];
                        MemoryStream ms = new MemoryStream(data);
                        Image image = new Bitmap(ms); // on converti en Bitmap pour récupérer une image
                        box[j].Image = image; // affichage de l'image dans la PictureBox
                        list.Add(_image);
                        j++;
                    }
                }

                reader.Close();
                sqlConn.Close();

                if (list.Count == 0)
                    labelTextChoix.Text = "Il n'y a pas de photo correspondante à la recherche.";
            }
            catch (Exception)
            {
                labelTextChoix.Text = "echec de connexion";
            }

        }





        private void AfficherTousNoms()
        {
            // connexion à la base
            string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connetionString);
            SqlCommand cmd;
            //string val = comboBox1.Items.
            try
            {
                if (comboBox1.Text == "Tous" || comboBox1.Text == "")
                {
                    comboBox1.Text = "Tous";
                    string query = String.Format(@"SELECT PRENOM, NOM FROM IDENTIFIANTS"); // on ne recupère que l'image
                    cmd = new SqlCommand(query, sqlConn);
                }
                else
                {
                    string dept = (comboBox1.SelectedItem as dynamic).Value; // récupère la valeur correspondante au texte entré dans la combobox
                    string query = String.Format(@"SELECT PRENOM, NOM FROM IDENTIFIANTS WHERE DEPARTEMENT= @dept"); // on ne recupère que l'image
                    cmd = new SqlCommand(query, sqlConn);
                    cmd.Parameters.AddWithValue("@dept", dept);
                }

                cmd.Connection.Open();

                ConstructionTextBoxListe();
                //ViderlabelListe();

                SqlDataReader reader = cmd.ExecuteReader();
                j = 1;
                while (reader.Read())
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string[] tab = new string[reader.FieldCount];
                        tab[i] = reader.GetValue(i).ToString(); //récupération du résultat dans un tableau avant de le retourner
                        labelListe[1].Text = labelListe[1].Text + tab[i] + Environment.NewLine;
                        j++;
                    }
                }

                reader.Close();
                sqlConn.Close();

            }
            catch (Exception)
            {
                labelTextChoix.Text = "echec de connexion";
            }

        }


        // -----------------------------------------------------------------------------------------------------------------------------------------------
        // -----------------------------------Methode afficher détails à partir d'une photo---------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------------------------------------

        private void AfficherDetails(int p)
        {
            popup = new popup();
            popup.Show();
            AfficherLeNom(p);
            AfficherLesCoordonnees(p);
            AfficherLesClients(p);
            AfficherPhotoPopUp(p);

        }






        private void AfficherLeNom(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);

            if (box[p].Image != null) // empeche d'avoir une erreur lorsqu'on clic sur unr photo "vide"
            {
                byte[] code = imageToByteArray(box[p].Image);
                cnn.Open();

                SqlCommand requete = cnn.CreateCommand();
                requete.CommandText = "SELECT NOM, PRENOM FROM IDENTIFIANTS WHERE PHOTO=@PHOTO";
                requete.Parameters.Add(new SqlParameter("@PHOTO", code)); // récupération du parametre à afficher

                SqlDataReader dataReader = requete.ExecuteReader();

                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        string[] tab = new string[dataReader.FieldCount];
                        tab[i] = dataReader.GetValue(i).ToString(); //récupération du résultat dans un tableau avant de le retourner
                        popup.textBoxPopup1.Text = popup.textBoxPopup1.Text + tab[i] + Environment.NewLine + Environment.NewLine;

                    }
                }

                dataReader.Close();
                cnn.Close();
            }
        }





        private void AfficherLesCoordonnees(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ypelle\source\repos\Trombino\Trombino\Database1.mdf;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);

            if (box[p].Image != null) // empeche d'avoir une erreur lorsqu'on clic sur unr photo "vide"
            {
                byte[] code = imageToByteArray(box[p].Image);
                cnn.Open();

                SqlCommand requete = cnn.CreateCommand();
                requete.CommandText = "SELECT TELEPHONE, MAIL FROM IDENTIFIANTS WHERE PHOTO=@PHOTO";
                requete.Parameters.Add(new SqlParameter("@PHOTO", code)); // récupération du parametre à afficher

                SqlDataReader dataReader = requete.ExecuteReader();

                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        string[] tab = new string[dataReader.FieldCount];
                        tab[i] = dataReader.GetValue(i).ToString(); //récupération du résultat dans un tableau avant de le retourner
                        popup.textBoxPopup2.Text = popup.textBoxPopup2.Text + tab[i] + Environment.NewLine;


                    }
                }

                dataReader.Close();
                cnn.Close();

            }
        }


        private void AfficherLesClients(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ypelle\source\repos\Trombino\Trombino\Database1.mdf;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);

            if (box[p].Image != null) // empeche d'avoir une erreur lorsqu'on clic sur unr photo "vide"
            {
                byte[] code = imageToByteArray(box[p].Image);
                cnn.Open();

                SqlCommand requete = cnn.CreateCommand();
                requete.CommandText = "SELECT CLIENTS, COLLABORATEURS FROM IDENTIFIANTS WHERE PHOTO=@PHOTO";
                requete.Parameters.Add(new SqlParameter("@PHOTO", code)); // récupération du parametre à afficher

                SqlDataReader dataReader = requete.ExecuteReader();

                while (dataReader.Read())
                {

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        string[] tab = new string[dataReader.FieldCount];
                        tab[i] = dataReader.GetValue(i).ToString(); //récupération du résultat dans un tableau avant de le retourner
                        popup.textBoxPopup3.Text = popup.textBoxPopup3.Text + tab[i] + Environment.NewLine + Environment.NewLine;
                        popup.Show();

                    }
                }

                dataReader.Close();
                cnn.Close();
            }
        }




        // -----------------------------------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------- Methode afficher la photo dans une popup ----------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        private void AfficherPhotoPopUp(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ypelle\source\repos\Trombino\Trombino\Database1.mdf;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);

            if (box[p].Image != null)
            {  // empeche d'avoir une erreur lorsqu'on clic sur unr photo "vide"
                byte[] code = imageToByteArray(box[p].Image);
                cnn.Open();
                //label1.Text = "Connexion établie";

                SqlCommand requete = cnn.CreateCommand();
                requete.CommandText = "SELECT PHOTO FROM IDENTIFIANTS WHERE PHOTO=@PHOTO";
                requete.Parameters.Add(new SqlParameter("@PHOTO", code)); // récupération du parametre à afficher

                SqlDataReader reader = requete.ExecuteReader();

                while (reader.Read())
                {

                    byte[] data = (byte[])reader[i];
                    MemoryStream ms = new MemoryStream(data);
                    Image image = new Bitmap(ms); // on converti en Bitmap pour récupérer une image
                    popup.pictureBox1.Image = image; // affichage de l'image dans la PictureBox
                }

            }

        }


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
            Label[] labelListe = new Label[50];
            labelListe[1] = label1;
            labelListe[2] = label2;

        }

    }
}


