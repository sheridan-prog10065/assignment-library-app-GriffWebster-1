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
    private async void OnRegisterBook(object sender, EventArgs e)
    {
            string bookName = (string)_txtName.Text;
            string bookISBN = _txtISBN.Text;
            string[] authors = _txtAuthors.Text
            //used ai to help get the entry for authors because it is a list and cant just be taken as a string
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(author => author.Trim())
            .ToArray();

            int assetNum = int.Parse(_txtAssetNum.Text);

        Library.BookType selectedBookType = Enum.Parse<Library.BookType>(_pckBookType.SelectedItem.ToString());

        _library.RegisterBook(bookName, bookISBN, authors, selectedBookType, assetNum);

        DisplayBooks();
    }
    }

