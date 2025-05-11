using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
    }
}
