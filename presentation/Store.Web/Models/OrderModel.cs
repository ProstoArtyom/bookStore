﻿using BookStore;

namespace Store.Web.Models;

public class OrderModel
{
    public int Id { get; set; }

    public OrderItemModel[] Items { get; set; } = new OrderItemModel[0];
    
    public int TotalCount { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
}