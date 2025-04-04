﻿using System;

namespace MoneyManager.DataAccess.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid AssetId { get; set; }
        public string Comment { get; set; }

        public virtual Category Category { get; set; }
        public virtual Asset Asset { get; set; }
    }
}
