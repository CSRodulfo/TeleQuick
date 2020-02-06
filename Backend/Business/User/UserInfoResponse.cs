using Business.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.User
{
    public class UserInfoResponse
    {
        public string Key { get; set; }
        public string Dni { get; set; }
        public string DniType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Floor { get; set; }
        public string DepartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public List<OptIn> OptIn { get; set; }
        public Province Province { get; set; }
        public string RegistrationMethod { get; set; }
        public bool IsGoogle { get; set; }
        public string SocialId { get; set; }
        public int NumberOfIncorrectPaswordAttempts { get; set; }
    }
}
