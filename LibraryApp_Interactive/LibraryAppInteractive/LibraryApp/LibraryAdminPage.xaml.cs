using LibraryAppInteractive.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppInteractive;

public partial class LibraryAdminPage : ContentPage
{

    private Library _library;

    public LibraryAdminPage()
    {
        InitializeComponent();

        _library = new Library();
        DisplayBooks();
    }

    public LibraryAdminPage(Library library)
    {
        InitializeComponent();

        _library = library;
        DisplayBooks();
    }

    private void DisplayBooks()
    {
        System.Diagnostics.Debug.WriteLine("Book count: " + _library.Books.Count);

        foreach (Book book in _library.Books)
        {
            System.Diagnostics.Debug.WriteLine(book.ToString());
        }

        AssetsCollectionView.ItemsSource = null;
        AssetsCollectionView.ItemsSource = _library.Books;
    }
    private void OnRegisterBook(object sender, EventArgs e)
    {

    }

}