using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class AppCompany
    {
        public Guid Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Hotline { get; set; }
        public string About { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string Address { get; set; }

    }
}