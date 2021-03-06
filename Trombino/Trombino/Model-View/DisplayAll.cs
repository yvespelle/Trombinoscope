﻿using System;
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
        int i;
        int j = 1;
        popup popup;



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
                    string query = String.Format(@"SELECT PHOTO FROM IDENTIFIANTS"); // on ne recupère que l'image
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
                ViderlabelListe();

                SqlDataReader reader = cmd.ExecuteReader();
                j = 1;
                while (reader.Read())
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string[] tab = new string[reader.FieldCount];
                        tab[i] = reader.GetValue(i).ToString(); //récupération du résultat dans un tableau avant de le retourner
                        labelListe[j].Text = labelListe[j].Text + tab[i] + Environment.NewLine;
                        labelListe[j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        labelListe[j].Visible = true;
                    }
                    j++;
                }

                reader.Close();
                sqlConn.Close();

            }
            catch (Exception)
            {
                labelTextChoix.Text = "echec de connexion";
            }

        }


    }
}
