using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows;
using System.Data.SQLite;
using System.Configuration;
using System.Collections.Generic;
using System.IO;

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

                    //string cnnStr = ConfigurationManager.ConnectionStrings["StudyHabitDB"].ConnectionString;  // For remote DB in App.config
                    //string database = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudyHabitDB.mdf"); // local DB in app direcotry
                    //string cnnStr = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\StudyHabitDB.mdf;Integrated Security = True; Connect Timeout = 30";
                    string cnnStr = "Data Source = |DataDirectory|\\StudyHabitDB.db; Version = 3";

                    using (SQLiteConnection connection = new SQLiteConnection(cnnStr))
                    {
                         using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection))
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

          public static DataTable AddCourse(string name, string type, string code, string term, string year)
          {
               string sql =
                    "insert into Course(Name, CourseType, Code, Term, Year)" +
                    $"values('{name}', '{type}', '{code}', '{term}', '{year}')";

               return GetData(sql);
          }

          public static DataTable GetCourses()
          {
               string sql = "select * from Course";
               return GetData(sql);
          }
     }
}
