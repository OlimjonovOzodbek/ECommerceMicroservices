using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities
{
    public class ProductOrdering
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public string Status { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
    }
}
