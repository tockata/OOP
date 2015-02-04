using System;
using Lab_Multimedia_Shop.Model;

namespace Lab_Multimedia_Shop.Interfaces
{
    public interface ISale
    {
        Item Item { get; set; }
        DateTime SaleDate { get; set; }
    }
}
