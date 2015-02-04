using System;
using System.Collections.Generic;

namespace Lab_Multimedia_Shop.Interfaces
{
    public interface IItem
    {
        string Id { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }
        IList<String> Genres { get; set; }
    }
}
