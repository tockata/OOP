using System;
using Lab_Multimedia_Shop.Enums;
using Lab_Multimedia_Shop.Model;

namespace Lab_Multimedia_Shop.Interfaces
{
    public interface IRent
    {
        Item Item { get; set; }
        RentStatus RentStatus { get; set; }
        DateTime RentDate { get; set; }
        DateTime DeadLine { get; set; }
        DateTime DateOfReturn { get; set; }

        decimal CalculateFine();
    }
}
