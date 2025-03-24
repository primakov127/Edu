using System;
using System.Collections.Generic;

namespace MoneyManager.DataAccess.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public Guid? ParentId { get; set; }
        public string Color { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Subcategories { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
