    namespace LibraryAppInteractive;

using System.Diagnostics.Contracts;

using LibraryAppInteractive.BusinessLogic;

public partial class LibraryBrowsePage : ContentPage
{

    private Library _library;

    public LibraryBrowsePage()
    {
        InitializeComponent();

        _library = new Library();
        DisplayBooks();
    }

    public LibraryBrowsePage(Library library)
    {
        InitializeComponent();

        _library = library;
        DisplayBooks();
    }



    public void OnSearchBook(object sender, EventArgs e)
        {
            string enteredName = _txtSelectName.Text;
            string enteredISBN = _txtSelectISBN.Text;

        foreach (Book book in _library.Books)
        {
            System.Diagnostics.Debug.WriteLine(book.ToString());
        }

        AssetsCollectionView.ItemsSource = null;
        AssetsCollectionView.ItemsSource = _library.Books;
    }
}