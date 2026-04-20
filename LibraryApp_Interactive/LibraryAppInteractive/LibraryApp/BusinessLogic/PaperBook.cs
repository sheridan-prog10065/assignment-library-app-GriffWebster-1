using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public class PaperBook : Book
{

    private const int MAX_BORROW_DAYS = 30;
    private const float LATE_PENALTY_PER_DAY = 0.25f;

    public PaperBook(string bookName, string bookISBN, string[] authors) : base(bookName, bookISBN, authors)
    {
    }

    public override LibraryAsset BorrowBook()
    {
        LibraryAsset asset = FindNextAvailableAsset();

        if (asset == null)
        {
            //
        }

        DateTime borrowedOn = DateTime.Now;
        DateTime dueDate = borrowedOn.AddDays(MAX_BORROW_DAYS);

        asset.Status = AssetStatus.Loaned;

        asset.LoanPeriod = new LoanPeriod(borrowedOn, DateTime.MinValue, dueDate);

        return asset;

    }

    public override (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        LibraryAsset asset = FindAssetByID(libID);

        if (asset == null || asset.LoanPeriod == null)
        {
            return (TimeSpan.Zero, 0, 0m);
        }

        LoanPeriod oldLoan = asset.LoanPeriod.Value;

        LoanPeriod completedLoan = new LoanPeriod(
            oldLoan.BorrowedOn,
            DateTime.Now,
            oldLoan.DueDate
        );

        TimeSpan latePeriod = completedLoan.LatePeriod;

        int lateDays = 0;
        if (latePeriod.TotalDays > 0)
        {
            lateDays = (int)Math.Ceiling(latePeriod.TotalDays);
        }

        decimal fine = (decimal)(lateDays * LATE_PENALTY_PER_DAY);

        // when returned the asset becomes available again.
        asset.Status = AssetStatus.Available;
        asset.LoanPeriod = null;

        return (latePeriod, lateDays, fine);
    }


}
