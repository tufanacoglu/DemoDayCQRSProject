﻿namespace DemoDayCQRSProject.CQRS.Results.CustomerResults
{
    public class GetCustomerQueryResult
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
    }
}
