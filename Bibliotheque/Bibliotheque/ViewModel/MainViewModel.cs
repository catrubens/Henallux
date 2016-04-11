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
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Bibliotheque.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private ICommand _goSearch;
        private ICommand _goLogin;
        private ICommand _commandReservation;
        private ObservableCollection<Book> _books30DaysLast;
        private Book _selectedBook;
        private List<Book> bookReservation = new List<Book>();

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;            
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("Email");
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if ( e.Parameter != "")
                 bookReservation = (List<Book>)e.Parameter;
            LoadBook30LastDays();
            var test = bookReservation;
        }

        public async void LoadBook30LastDays()
        {
            BookAccess bookAccess = new BookAccess();
            try
            {
                Books30DaysLast = await bookAccess.GetBook30LastDays();
            }
            catch (NoNetworkException e)
            {
                ShowToast(e.ErrorMessage);
            }
        }

        private async void BookReseravation_Click(Book book)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            string strVR = loader.GetString("ValideReservation");
            string yes = loader.GetString("Yes");
            string no = loader.GetString("No");
            var dialog = new Windows.UI.Popups.MessageDialog(book.Title+"\n" + strVR);      
            dialog.Commands.Add(new Windows.UI.Popups.UICommand(yes) { Id = 1 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand(no) { Id = 0 });

            var result = await dialog.ShowAsync();

            if ((int)result.Id == 1)
            {
                var duplicate = false;
                foreach (var b in bookReservation)
                {
                    if (b.NumBook == book.NumBook)
                        duplicate = true;
                }
                if(duplicate == false)
                    bookReservation.Add(book);
                else
                {
                    var str = loader.GetString("Duplicate");
                    dialog = new Windows.UI.Popups.MessageDialog(str);
                    await dialog.ShowAsync();
                }
            }
        }

        public async void ShowToast(String value)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(value);
            await dialog.ShowAsync();
        }

// Getter and Setter

        public ObservableCollection<Book> Books30DaysLast
        {
            get { return _books30DaysLast; }

            set
            {
                _books30DaysLast = value;
                RaisePropertyChanged("Books30DaysLast");
            }
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }

            set
            {
                _selectedBook = value;
                if (_selectedBook != null)
                {
                    RaisePropertyChanged("SelectedBook");
                    BookReseravation_Click(_selectedBook);
                }
            }
        }

// Command from button

        public ICommand GoSearch
        {
            get
            {   
                if ( _goSearch == null)
                {
                    _goSearch = new RelayCommand(() => GoSearchPage());
                }
                return _goSearch;
            }
        }

        private void GoSearchPage()
        {
            _navigationService.NavigateTo("Search",bookReservation);
        }

        public ICommand GoLogin
        {
            get
            {
                if (_goLogin == null)
                {
                    _goLogin = new RelayCommand(() => GoLoginPage());
                }
                return _goLogin;
            }
        }

        private void GoLoginPage()
        {
            _navigationService.NavigateTo("Login",bookReservation);
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
            _navigationService.NavigateTo("Reservation", bookReservation);
        }
    }
}
