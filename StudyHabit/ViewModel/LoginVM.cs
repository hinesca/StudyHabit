using StudyHabit.Model;
using StudyHabit.View;
using System;
using System.ComponentModel;
using System.Security;
using System.Windows;

/// <summary>
/// The view model for the login screen
/// </summary>
namespace StudyHabit.ViewModel
{
     public class LoginVM : ViewModelBase
     {
          /// <summary>
          /// Constructor
          /// </summary>
          public LoginVM(LoginView view)
          {
               /* Coupling the View and ViewModel like this breaks MVVM.
                * We don't normally do this, but it is necessary in this situation
                * to keep the user's password secure.*/
               View = view;
               User = new User();
               PropertyChanged += OnPropertyChanged;
               LoginCommand = new RelayCommand(Login, LoginCanExecute);
               NewAccountCommand = new RelayCommand(NewAccount, NewAccountCanExecute);
               ShowEULACommand = new RelayCommand(ShowEULA);
          }

          /********************************************************************
           * LoginVM Properties
           * *****************************************************************/
          public User User {get; set;}
          private LoginView View { get; set; }

          public string Prompt
          {
               get
               {
                    if (IsNewUser)
                         return "New Accout Setup";
                    else return "User Login";
               }
          }

          public string Username
          {
               get { return User.UserName; }
               set
               {
                    User.UserName = value;
                    NotifyPropertyChanged();
               }
          }
          private bool _isNewUser = false;

          public bool IsNewUser
          {
               get { return _isNewUser; }
               set
               {
                    _isNewUser = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("IsNotNewUser");
               }
          }

          public bool IsNotNewUser
          {
               get { return !_isNewUser; }
          }

          private bool _userAgrees = false;
          public bool UserAgrees
          {
               get { return _userAgrees; }
               set
               {
                    _userAgrees = value;
                    NotifyPropertyChanged();
               }
          }


          /********************************************************************
           * LoginVM Commands and Command Properties
           * *****************************************************************/
          public RelayCommand LoginCommand { get; private set; }
          public RelayCommand NewAccountCommand { get; private set; }
          public RelayCommand ShowEULACommand { get; private set; }

          private void Login(object o)
          {
               //throw new NotImplementedException();
          }

          private bool LoginCanExecute(object o)
          {
               if (!string.IsNullOrWhiteSpace(Username))
                    return true;
               else return false;
          }

          private void NewAccount(object o)
          {
               //throw new NotImplementedException();
          }

          private bool NewAccountCanExecute(object o)
          {
               if (!string.IsNullOrWhiteSpace(Username)
                    && UserAgrees)
                    return true;
               else return false;
          }

          private void ShowEULA(object o)
          {
               MessageBox.Show(DataAccess.GetEULA(), "EULA", MessageBoxButton.OK, MessageBoxImage.None);
          }

          /********************************************************************
           * LoginVM Methods
           * *****************************************************************/
          private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
          {
               if (e.PropertyName == "IsNewUser")
               {
                    NotifyPropertyChanged("Prompt");
               }
          }
     }
}
