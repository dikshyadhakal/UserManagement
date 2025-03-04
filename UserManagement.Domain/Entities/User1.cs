using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    public class User1
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int ContactNumber { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
    