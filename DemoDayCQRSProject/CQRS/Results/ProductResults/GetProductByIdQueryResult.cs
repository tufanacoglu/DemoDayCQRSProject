﻿namespace DemoDayCQRSProject.CQRS.Results.ProductResults
{
    public class GetProductByIdQueryResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
