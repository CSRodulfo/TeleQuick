using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Business
{
    public class UserAccount : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
