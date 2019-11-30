﻿using StudyHabit.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;


namespace StudyHabit.View
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow : Window
     {
          public MainWindow()
          {
               InitializeComponent();
               Tabs.Visibility = Visibility.Hidden;
          }

          public void SwichToTabs()
          {
               Login.Visibility = Visibility.Hidden;
               Tabs.Visibility = Visibility.Visible;
          }
     }
}
