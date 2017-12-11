using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GreatPeople
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Occupation  { get; set; }
        public string NetWorth { get; set; }
        public string BirthYear { get; set; }
        public string KnownFor { get; set; }
        public string Description { get; set; }

        public GreatPeople()
        {

        }

        public GreatPeople(int id, string name, string occupation, string netWorth, string birthYear, string knownFor, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Occupation = occupation;
            this.NetWorth = netWorth;
            this.BirthYear = birthYear;
            this.KnownFor = knownFor;
            this.Description = description;
            
        }

    }
}
