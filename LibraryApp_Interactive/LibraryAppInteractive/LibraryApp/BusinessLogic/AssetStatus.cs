using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic;

public enum AssetStatus
{
    //Status of a book, whether it is available for use or not
    NotAvailable,
    Available,
    Loaned,
    Reserved
}
