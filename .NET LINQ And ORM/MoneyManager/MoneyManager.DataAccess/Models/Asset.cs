using System;
using System.Collections.Generic;

namespace MoneyManager.DataAccess.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
