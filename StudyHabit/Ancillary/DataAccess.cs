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
          /// <summary>
          /// General query method. This is private, if you need to use it,
          /// write a public static method in this class and use that.
          /// </summary>
          /// <param name="sql">The SQL for query</param>
          /// <returns></returns>
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


          /// <summary>
          /// Not using this method at the moment.
          /// The first prototype does not have a user, we are using a local DB
          /// for simplicity.
          /// </summary>
          /// <param name="userName"></param>
          /// <param name="pw"></param>
          /// <returns></returns>
          public static DataTable AddUser(string userName, string pw)
          {
               string sql = "insert into Users(username, password)" +
                    "output inserted.*" +
                    $"values('{userName}', '{pw}')";

               return GetData(sql);
          }
     }
}
