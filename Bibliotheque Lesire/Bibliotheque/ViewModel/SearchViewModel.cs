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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Bibliotheque.ViewModel
{
    public class SearchViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private ObservableCollection<Categorie> _categorieItems;
        private ICommand _search;
        private ICommand _commandMainPage;
        private ICommand _commandReservation;
        private String _wordSearch;
        private Categorie _selectedCategory;
        private ObservableCollection<Book> _booksSearch;
        private List<Book> bookReservation = new List<Book>();
        private Book _selectedBook;

        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            this._wordSearch = null;
            bookReservation = (List<Book>)e.Parameter;
            LoadCategory();
        }

        public async void LoadCategory()
        {
            CategorieAccess categorieAccess = new CategorieAccess();
            try
            { 
                CategorieItems = await categorieAccess.GetCategories();
            }
            catch (NoNetworkException e)
            {
                ShowToast(e.ErrorMessage);
            }
        }      

        private async void SearchBook()
        {
            BookAccess bookAccess = new BookAccess();
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            try
            {
                if (CanExecute() == true)
                {
                    var codeCategorie = SelectedCategory.CodeCategorie;
                    codeCategorie = codeCategorie.Replace(" ", "_");
                    BooksSearch = await bookAccess.GetBookSearch(WordSearch, codeCategorie);
                    if(BooksSearch.Count == 0)
                    {
                        string str = loader.GetString("NoResult");
                        ShowToast(str);
                    }
                }
                else
                {                    
                    string str = loader.GetString("Search_Missing");
                    throw new EmptyFieldsException(str);
                }
            }
            catch (EmptyFieldsException e)
            {
                ShowToast(e.ErrorMessage);
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
            var dialog = new Windows.UI.Popups.MessageDialog(book.Title + "\n" + strVR);
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
                if (duplicate == false)
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

        public bool CanExecute()
        {
            return (WordSearch == null || SelectedCategory == null) ? false : true;
        }

// Command from button 

        public ICommand Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new RelayCommand(() => SearchBook());
                }
                return _search;
            }
        }

// Getter and Setter

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

        public ObservableCollection<Book> BooksSearch
        {
            get { return _booksSearch; }

            set
            {
                _booksSearch = value;
                RaisePropertyChanged("BooksSearch");
            }
        }

        public ObservableCollection<Categorie> CategorieItems
        {
            get { return _categorieItems; }

            set
            {
                _categorieItems = value;
                RaisePropertyChanged("CategorieItems");
            }
        }

        public String WordSearch
        {
            get { return _wordSearch; }
            set
            {
                _wordSearch = value;
                RaisePropertyChanged("WordSearch");
            }
        }

        public Categorie SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
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
            _navigationService.NavigateTo("Reservation", bookReservation);
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
            _booksSearch = null;
            _navigationService.NavigateTo("MainPage", bookReservation);
        }
    }
}
