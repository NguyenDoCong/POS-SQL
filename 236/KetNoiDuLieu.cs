﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236
{
    public class KetNoiDuLieu
    {
        //public SqlConnection kndl = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True");

        //private static KetNoiDuLieu instance; // Ctrl + R + E

        //public static KetNoiDuLieu Instance
        //{
        //    get { if (instance == null) instance = new KetNoiDuLieu(); return KetNoiDuLieu.instance; }
        //    private set { KetNoiDuLieu.instance = value; }
        //}

        private KetNoiDuLieu() { }

        //private string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True";

        public static DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listP = query.Split(' ');
                    int i = 0;
                    foreach (string item in listP)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public static int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listP = query.Split(' ');
                    int i = 0;
                    foreach (string item in listP)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public static object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listP = query.Split(' ');
                    int i = 0;
                    foreach (string item in listP)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }

    }
}
