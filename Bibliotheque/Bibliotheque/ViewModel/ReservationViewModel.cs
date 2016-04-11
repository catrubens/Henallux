using Bibliotheque.DataAccess;
using Bibliotheque.Exceptions;
using Bibliotheque.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace Bibliotheque.ViewModel
{
    public class ReservationViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private ICommand _commandMainPage;
        private ICommand _commandSearch;
        private ICommand _bookDelete;
        private ICommand _goValide;        
        private List<Book> bookReservation = new List<Book>();
        private ObservableCollection<Book> _booksReservation;
        private ObservableCollection<Book> bookConvert;
        private string mail;

        public ReservationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            bookReservation = (List<Book>)e.Parameter;
            bookConvert = new ObservableCollection<Book>(bookReservation);
            BooksReservation = bookConvert;
        }

        private async void Validation()
        {
            ReservationAccess reservationAccess = new ReservationAccess();
            try
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                mail = (string)localSettings.Values["Email"];
                if (CanExecute() == true)
                {
                    await reservationAccess.AddReservation(mail, bookReservation);
                    string str = loader.GetString("success");
                    ShowToast(str);
                    bookReservation.Clear();
                    _navigationService.NavigateTo("MainPage", bookReservation);
                }
                else
                {
                    if (mail == null)
                    {                      
                        string str = loader.GetString("Email_Missing");
                        throw new EmptyFieldsException(str);
                    }
                    else
                    {
                        string str = loader.GetString("List_Missing");
                        throw new EmptyFieldsException(str);
                    }
                }
            }
            catch (EmptyFieldsException e)
            {
                ShowToast(e.ErrorMessage);
            }
            catch (ErrorData e)
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
            return (bookReservation.Count == 0 || mail == null) ? false : true;
        }

// Getter and Setter

        public ObservableCollection<Book> BooksReservation
        {
            get { return _booksReservation; }

            set
            {
                _booksReservation = value;
                RaisePropertyChanged("BooksReservation");
            }
        }

// Command from button

        public ICommand GoValide
        {
            get
            {
                if (_goValide == null)
                {
                    _goValide = new RelayCommand(() => Validation());
                }
                return _goValide;
            }
        }        

        public ICommand BookDelete
        {
            get
            {
                if (_bookDelete == null)
                {
                    _bookDelete = new RelayCommand<Book>(DeleteBook);
                }
                return _bookDelete;
            }
        }

        private void DeleteBook(Book book)
        {
            BooksReservation.Remove(book);
            bookReservation = BooksReservation.ToList();
        }

// Command of bar

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
            _navigationService.NavigateTo("MainPage", bookReservation);
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
            _navigationService.NavigateTo("Search", bookReservation);
        }
    }
}
