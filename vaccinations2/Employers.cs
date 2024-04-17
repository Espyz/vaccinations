using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinations2
{
    internal class Employers
    {
        private readonly int id;
        private readonly string name;
        private readonly string lastName;
        private readonly string middleName;
        private DateTime lastVaccinationDate;

        public string Name { get => name; }
        public string LastName { get => lastName; }
        public string MiddleName { get => middleName; }
        public DateTime LastVaccinationDate { get => lastVaccinationDate; set => lastVaccinationDate = value; }

        public Employers(string _lastName, string _name, string _middleName, int _id) 
        {
            name = _name;
            lastName = _lastName;
            middleName = _middleName;
            id = _id;
        }
        public Employers(string _lastName, string _name, int _id) 
        {
            name = _name;
            lastName = _lastName;
            id = _id;
        }
        public Employers(string _lastName, string _name, string _middleName, DateTime _lastVaccinationDate, int _id) 
        {
            name = _name;
            lastName = _lastName;
            middleName = _middleName;
            lastVaccinationDate = _lastVaccinationDate;
            id = _id;
        }
        public Employers(string _lastName, string _name, DateTime _lastVaccinationDate, int _id) 
        {
            name = _name;
            lastName = _lastName;
            lastVaccinationDate = _lastVaccinationDate;
            id = _id;
        }

        public void Print()
        {
            Console.WriteLine($"{ id }. { lastName } { name } { middleName }, последняя вакцинация { lastVaccinationDate.ToShortDateString()}");
        }
    }
}
