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
    }
}
