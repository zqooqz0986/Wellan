using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModel
{
    public class Products
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Unique]
        [NotNull]
        [MaxLength(100)]
        public string Name { get; set; }

        [NotNull]
        public decimal Price { get; set; }

        [NotNull]
        public DateTime UpdatedTime { get; set; }
    }
}
