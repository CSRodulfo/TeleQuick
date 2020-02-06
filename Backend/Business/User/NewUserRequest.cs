using System;
using System.Collections.Generic;
using System.Text;

namespace Business.User
{
    public class NewUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Dni { get; set; }
        public string DniType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public Int32 Gender { get; set; }
        public string RegisteredFrom { get; set; }
        public string SourceUrl { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Floor { get; set; }
        public string DepartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public IList<string> Profiles { get; set; }
        public IList<string> Themes { get; set; }
        public List<string> OptIns { get; set; }
        public NewUserRequest()
        {
            this.DniType = "dni";
        }
    }
}
