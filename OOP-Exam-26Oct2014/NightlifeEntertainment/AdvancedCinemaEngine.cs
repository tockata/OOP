using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    public class AdvancedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = GetPerformance(commandWords[1]);
            var soldTickets =
                from ticket in performance.Tickets
                where ticket.Status == TicketStatus.Sold
                select ticket;

            int ticketsCount = soldTickets.Count();
            decimal totalPrice = CalculateTotalPrice(soldTickets);

            StringBuilder report = new StringBuilder();
            report.AppendFormat("{0}: {1} ticket(s), total: ${2:F2}", performance.Name, ticketsCount, totalPrice)
                .AppendLine();
            report.AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location).AppendLine();
            report.AppendFormat("Start time: {0}", performance.StartTime);

            this.Output.AppendLine(report.ToString());
        }

        private decimal CalculateTotalPrice(IEnumerable<ITicket> soldTickets)
        {
            decimal price = 0;
            foreach (var soldTicket in soldTickets)
            {
                price += soldTicket.Price;
            }

            return price;
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string searchPhrase = commandWords[1].ToLower();
            DateTime startDateTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);

            var performanceSearchResult =
                from performance in this.Performances
                where performance.Name.ToLower().Contains(searchPhrase)
                where performance.StartTime >= startDateTime
                orderby performance.StartTime, performance.BasePrice descending, performance.Name
                select performance;

            StringBuilder searchResult = new StringBuilder();
            searchResult.AppendFormat("Search for \"{0}\"", commandWords[1]).AppendLine();
            searchResult.AppendFormat("Performances:").AppendLine();

            if (performanceSearchResult.Count() == 0)
            {
                searchResult.AppendFormat("no results").AppendLine();
            }
            else
            {
                foreach (var performance in performanceSearchResult)
                {
                    searchResult.AppendFormat("-{0}", performance.Name).AppendLine();
                }
            }

            var venuesSearchResult =
                from venue in this.Venues
                where venue.Name.ToLower().Contains(searchPhrase)
                orderby venue.Name
                select venue;

            searchResult.AppendFormat("Venues:").AppendLine();
            if (venuesSearchResult.Count() == 0)
            {
                searchResult.AppendFormat("no results").AppendLine();
            }
            else
            {
                foreach (var venue in venuesSearchResult)
                {
                    searchResult.AppendFormat("-{0}", venue.Name).AppendLine();
                    var matchingPerformances =
                        from performance in this.Performances
                        where performance.Venue.Equals(venue)
                        where performance.StartTime >= startDateTime
                        orderby performance.StartTime, performance.BasePrice descending, performance.Name
                        select performance;

                    if (matchingPerformances.Count() != 0)
                    {
                        foreach (var matchingPerformance in matchingPerformances)
                        {
                            searchResult.AppendFormat("--{0}", matchingPerformance.Name).AppendLine();
                        }
                    }
                }
            }

            this.Output.Append(searchResult.ToString());
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            int ticketsCount = int.Parse(commandWords[4]);
            if (!this.Venues.Contains(venue) || !this.Performances.Contains(performance))
            {
                throw new ArgumentException("There are not enough available seats, or venue or performance name are invalid!");
            }

            switch (commandWords[1])
            {
                case "vip":
                    for (int i = 0; i < ticketsCount; i++)
                    {
                        performance.AddTicket(new Vip(performance));
                    }

                    break;
                case "student":
                    for (int i = 0; i < ticketsCount; i++)
                    {
                        performance.AddTicket(new Student(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "theatre":
                    var theatreVenue = this.GetVenue(commandWords[5]);
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), theatreVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concertVenue = this.GetVenue(commandWords[5]);
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), concertVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }
    }
}
