namespace FrontEnd.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; } = null!;
        public IEnumerable<CustomerViewModel> Customers { get; set; }
        public int? EmployeeId { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public int? ShipperId { get; set; }
        public IEnumerable<ShipperViewModel> Shippers { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        public string? ShipName { get; set; }

        public string? ShipAddress { get; set; }

        public string? ShipCity { get; set; }

        public string? ShipRegion { get; set; }

        public string? ShipPostalCode { get; set; }

        public string? ShipCountry { get; set; }
    }
}
