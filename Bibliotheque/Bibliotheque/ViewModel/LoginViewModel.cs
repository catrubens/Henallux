using Bibliotheque.DataAccess;
using Bibliotheque.Exceptions;
using Bibliotheque.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace Bibliotheque.ViewModel
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _commandMainPage;
        private ICommand _commandSearch;
        private ICommand _commandReservation;
        private ICommand _loginButton;
        private String _email;
        private String _password;
        private INavigationService _navigationService;
        private List<Book> bookReservation = new List<Book>();

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            bookReservation = (List<Book>)e.Parameter;
        }        

        private async void Login()
        {
            try
            {
                if (CanExecute() == true)
                {
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                    BorrowerAccess borrowerAccess = new BorrowerAccess();
                    var loginOk = await borrowerAccess.VerifiyLoginAsync(Email, Password);

                    if (loginOk)
                    {
                        localSettings.Values["Email"] = Email;
                        string str = loader.GetString("Connect");
                        ShowToast(str);
                        _navigationService.NavigateTo("MainPage",bookReservation);
                    }
                    else
                    {
                        string str = loader.GetString("Login_PWD_Wrong");
                        throw new WrongEmailPwdException(str);
                    }       
                }
                else
                {
                    var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                    string str = loader.GetString("Login_PWD_Missing");
                    throw new EmptyFieldsException(str);
                }
            }
            catch (EmptyFieldsException e)
            {
                ShowToast(e.ErrorMessage);
            }
            catch (WrongEmailPwdException e)
            {
                ShowToast(e.ErrorMessage);
            }
            catch (NoNetworkException e)
            {
                ShowToast(e.ErrorMessage);
            }
        }

        public async void ShowToast(String value)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(value);
            await dialog.ShowAsync();
        }

        public bool CanExecute()
        {
            return (Email == null || Password == null) ? false : true;
        }

// Command from button

        public ICommand LoginButton
        {
            get
            {
                if (_loginButton == null)
                {
                    _loginButton = new RelayCommand(() => Login());
                }
                return _loginButton;
            }
        }

// Command from bar

        public ICommand CommandReservation
        {
            get
            {
                if (_commandReservation == null)
                    _commandReservation = new RelayCommand(() => Reservation());
                return _commandReservation;
            }
        }

        private void Reservation()
        {
            _navigationService.NavigateTo("Reservation",bookReservation);
        }

        public ICommand CommandMainPage
        {
            get
            {
                if (_commandMainPage == null)
                    _commandMainPage = new RelayCommand(() => MainPage());
                return _commandMainPage;
            }
        }

        private void MainPage()
        {
            _navigationService.NavigateTo("MainPage",bookReservation);
        }

        public ICommand CommandSearch
        {
            get
            {
                if (_commandSearch == null)
                    _commandSearch = new RelayCommand(() => Search());
                return _commandSearch;
            }
        }

        private void Search()
        {
            _navigationService.NavigateTo("Search",bookReservation);
        }

// Getter and Setter 

        public String Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
    }
}
