    namespace LibraryAppInteractive;

    using System.Diagnostics.Contracts;

    using LibraryAppInteractive.BusinessLogic;

    public partial class LibraryBrowsePage : ContentPage
    {

        private Library _library;
        private Book _selectedBook;

        public LibraryBrowsePage()
        {
            InitializeComponent();
        }

        public LibraryBrowsePage(Library library)
        {
            InitializeComponent();
            _library = library;
        }

    public void OnSearchBook(object sender, EventArgs e)
        {
            string enteredName = _txtSelectName.Text;
            string enteredISBN = _txtSelectISBN.Text;

            Book foundBook = null;

            if (!string.IsNullOrEmpty(enteredName))
            {
                foundBook = _library.FindBookByName(enteredName);
            }
            else if (!string.IsNullOrEmpty(enteredISBN))
            {
                foundBook = _library.FindBookByISBN(enteredISBN);
            }
            else
            {
                DisplayAlert("Error", "Enter a book name or ISBN", "Okay");
                return;
            }

            if (foundBook == null)
            {
                BookNameLabel.Text = "Book not found";
                BookAuthorsLabel.Text = "-";
                BookIsbnLabel.Text = "-";
                _selectedBook = null;

                DisplayAlert("Not Found", "No matching book was found.", "OK");
                return;
            }

            _selectedBook = foundBook;

            BookNameLabel.Text = foundBook.Name;
            BookAuthorsLabel.Text = string.Join(", ", foundBook.Authors);
        BookIsbnLabel.Text = foundBook.ISBN.ToString();


        }
    }