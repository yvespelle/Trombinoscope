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

        // -----------------------------------------------------------------------------------------------------------------------------------------------
        // -----------------------------------Methode afficher détails à partir d'une photo---------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------------------------------------

        private void AfficherDetails(int p)
        {
            if (box[p].Image != null) // empeche d'avoir une erreur lorsqu'on clic sur unr photo "vide"
            {
                popup = new popup();
                popup.Show();
                AfficherLeNom(p);
                AfficherLesCoordonnees(p);
                AfficherLesClients(p);
                AfficherPhotoPopUp(p);
            }

        }


        private void AfficherLeNom(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);
            
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





        private void AfficherLesCoordonnees(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
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
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);


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




        // -----------------------------------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------- Methode afficher la photo dans une popup ----------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        private void AfficherPhotoPopUp(int p)
        {
            string connetionString = null;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connetionString);

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

        // -----------------------------------------------------------------------------------------------------------------------------------------------
        // ------------------------------------- Methode afficher le contact par recherche de nom --------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------------------------------------


        private void AfficherProfilRecherche()
        {
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connetionString);
            List<ImageList> list = new List<ImageList>();
            SqlCommand cmd;
            //string val = comboBox1.Items.
            try
            {
                if (textBoxRechercher.Text != "")
                {
                    string dept = textBoxRechercher.Text + "%"; // récupère la valeur correspondante au texte entré dans la combobox
                    string query = String.Format(@"SELECT PHOTO FROM IDENTIFIANTS WHERE PRENOM LIKE @dept OR NOM LIKE @dept ORDER BY PRENOM"); // on ne recupère que l'image
                    cmd = new SqlCommand(query, sqlConn);
                    cmd.Parameters.AddWithValue("@dept", dept);

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
                    {
                        label41.ForeColor = Color.FromArgb(192, 0, 0);
                        label41.Text = "Il n'y a pas de contact correspondante à votre recherche.";
                    }
                }
                else
                {
                    label41.ForeColor = Color.FromArgb(192, 0, 0);
                    label41.Text = "Merci de renseigner un Nom ou un Prénom."; // label au dessus de la barre de recherche par nom/prenom
                }
            }
            catch (Exception)
            {
                labelTextChoix.ForeColor = Color.FromArgb(192, 0, 0);
                labelTextChoix.Text = "echec de connexion";
            }
        }




        private void AfficherNomRecherche()
        {
            // connexion à la base
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connetionString);
            SqlCommand cmd;
            //string val = comboBox1.Items.
            try
            {
                if (textBoxRechercher.Text != "")
                {
                    string dept = textBoxRechercher.Text + "%"; // récupère la valeur correspondante au texte entré dans la combobox
                    string query = String.Format(@"SELECT PRENOM, NOM, BUREAU, DEPARTEMENT FROM IDENTIFIANTS WHERE PRENOM LIKE @dept OR NOM LIKE @dept ORDER BY PRENOM"); // on ne recupère que l'image
                    cmd = new SqlCommand(query, sqlConn);
                    cmd.Parameters.AddWithValue("@dept", dept);

                    cmd.Connection.Open();

                    ConstructionTextBoxListe();
                    ViderlabelListe();

                    SqlDataReader reader = cmd.ExecuteReader();
                    j = 1;
                    while (reader.Read())
                    {

                        for (int i = 0; i < reader.FieldCount-1; i++)
                        {
                            string[] tab = new string[reader.FieldCount];
                            tab[i] = reader.GetValue(i).ToString(); //récupération du résultat dans un tableau avant de le retourner
                            labelListe[j].Text = labelListe[j].Text + tab[i] + Environment.NewLine;
                            labelListe[j].Visible = true;
                        }

                        string departement = reader.GetValue(reader.FieldCount - 1).ToString();
                        if (departement == "LBT")
                            labelListe[j].ForeColor = Color.FromArgb(192, 25, 50); // ROUGE
                        if (departement == "LLD")
                            labelListe[j].ForeColor = Color.FromArgb(64, 130, 99); // VERT  
                        if (departement == "LJM")
                            labelListe[j].ForeColor = Color.FromArgb(215, 107, 0); // ORAGNE
                        if (departement == "EOP")
                            labelListe[j].ForeColor = Color.FromArgb(0, 128, 192); // BLEU 
                        if (departement == "RH")
                            labelListe[j].ForeColor = Color.FromArgb(132, 0, 132); //VIOLET 

                        j++;
                    }

                    reader.Close();
                    sqlConn.Close();
                }
            }

            catch (Exception)
            {
                labelTextChoix.Text = "echec de connexion";
            }

        }
    }
}

