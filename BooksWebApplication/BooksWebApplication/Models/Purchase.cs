﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksWebApplication.Models
{
        // покупка
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public int BookId { get; set; }
        public DateTime Date { get; set; }
    }
}