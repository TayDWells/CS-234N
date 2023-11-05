using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MarisModels
{
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }

        public override string ToString()
        {
            return StateCode + ", " + StateName;
        }

        public bool StartsWith(string v)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<Customer> Customers { get; set; }

        public static implicit operator State(string v)
        {
            throw new NotImplementedException();
        }
    }
}
