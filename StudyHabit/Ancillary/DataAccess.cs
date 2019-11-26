using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Configuration;
using System.Collections.Generic;

namespace StudyHabit
{
     public static class DataAccess
     {
          private static DataTable GetData(string sql)
          {
               DataTable table = new DataTable();
               try
               {
                    string cnnStr = ConfigurationManager.ConnectionStrings["StudyHabitDB"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(cnnStr))
                    {
                         using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                         {
                              adapter.Fill(table);
                         }
                    }
               }
               catch (Exception e)
               {
                    MessageBox.Show("Could not query database. Faild with: " +
                        e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               }
               return table;
          }

          public static string GetEULA()
          {
               return "This is a prototype application under development for educational " +
                    "purposes and carries absolutely no warranty. User data, including " +
                    "passwords, is not secure. Do not use a real password. The developers " + 
                    "of this application are students, and are not responsible for any " +
                    "loss of data, or any other damages.";
          }
     }
}
