    namespace LibraryAppInteractive;

    using System.Diagnostics.Contracts;

    using LibraryAppInteractive.BusinessLogic;
using Microsoft.VisualBasic;

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

        AssetDisplayView.IsVisible = false;
    }
    
    private void OnCheckStatusClicked(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            DisplayAlert("Error", "Search for a book first", "Okay");
            return;
        }
        
        bool isAvailable = _selectedBook.CheckAvailablity();
        string statusText = isAvailable ? "Available" : "Not Available";

         DisplayAlert("Book Status", statusText, "Okay");
        
    }

    private void OnBorrowBook(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            DisplayAlert("Error", "Search for a book first", "Okay");
            return;
        }

        LibraryAsset borrowedAsset = _selectedBook.BorrowBook();
        DateTime returnDate = borrowedAsset.LoanPeriod.Value.DueDate;

        if (borrowedAsset == null)
        {
            DisplayAlert("Unavailable", "No available copies of this book", "Okay");
            return;
        }

        DisplayAlert("Thank you", $"Borrowed asset ID: {borrowedAsset.LibID}, return date is {returnDate}", "Okay");

    }
    public async void OnReturnBook(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            await DisplayAlert("Error", "Search for a book first.", "OK");
            return;
        }

        // Validate that the return entry contains a real number.
        if (!int.TryParse(_txtReturnAssetID.Text, out int assetID))
        {
            await DisplayAlert("Error", "Enter a valid asset ID.", "OK");
            return;
        }

        // Perform the return operation.
        (TimeSpan latePeriod, int lateDays, decimal fine) result = _selectedBook.ReturnBook(assetID);

        // If everything came back zero, the return may have failed.
        if (result.lateDays == 0 && result.fine == 0m)
        {
            LibraryAsset asset = _selectedBook.FindAssetByID(assetID);

            if (asset == null)
            {
                await DisplayAlert("Error", "Asset not found for this selected book.", "OK");
                return;
            }
        }

        await DisplayAlert(
            "Returned",
            $"Late Days: {result.lateDays}\nFine: ${result.fine:F2}",
            "OK"
        );

        _txtReturnAssetID.Text = string.Empty;
    }

    private void OnDisplayBookAssets(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            DisplayAlert("Error", "Search for a book first", "Okay");
            return;
        }

        List<string> assetLines = new List<string>();


        //convert asset to readable string
        foreach (LibraryAsset asset in _selectedBook.Assets)
        {
            assetLines.Add(asset.ToString());
        }

        AssetDisplayView.ItemsSource = null;
        AssetDisplayView.ItemsSource = assetLines;
        AssetDisplayView.IsVisible = true;

    }
}