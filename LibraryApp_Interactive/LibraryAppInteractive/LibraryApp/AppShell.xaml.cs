namespace LibraryAppInteractive;

using LibraryAppInteractive.BusinessLogic;

public partial class AppShell : Shell
{
    //Instead of creating a new library for each page (my previous mistake) i will create one in appshell and have the pages share it
    //I was unable to search for new books I had created only default ones and this is why
    //Had ai aid me with the implementation

    private Library _sharedLibrary;

    public AppShell()
    {
        InitializeComponent();

        _sharedLibrary = new Library();

        Items.Add(new TabBar
        {
            Items =
            {
                new Tab
                {
                    Title = "Browse",
                    Items =
                    {
                        new ShellContent
                        {
                            Title = "Browse Library", Content = new LibraryBrowsePage(_sharedLibrary)
                        }
                    }
                },
                new Tab
                {
                    Title = "Admin",
                    Items =
                    {
                        new ShellContent
                        {
                            Title = "Library Admin", Content = new LibraryAdminPage(_sharedLibrary)
                        }
                    }
                },
            }
        });
    }
}