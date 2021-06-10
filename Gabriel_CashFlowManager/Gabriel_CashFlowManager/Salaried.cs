using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_CashFlowManager
{
    class Salaried : Employee
    {
        private string _firstName;
        private string _lastName;
        private string _SSN;
        private decimal _weeklyWage;
        private string _ledgerType;

        //public override string ledgerType => "Salaried";
        public override string ledgerType => _ledgerType;
        public override decimal PayableAmount => _weeklyWage;
        public Salaried(string firstname, string lastName, string SSN, decimal weeklyWage) : base(firstname, lastName, SSN)
        {
 
            _firstName = firstname;
            _lastName = lastName;
            _SSN = SSN;
            _weeklyWage = weeklyWage;
            _ledgerType= IPayable.LedgerType.Salaried.ToString();
        }
       
        public override string createInvoice()
        {
            return "\n"+" " + _ledgerType + " Employee: " + _firstName + " " + _lastName +
                "\n SSN: " + _SSN + "\n Weekly Salary: "+_weeklyWage.ToString("c")+"\n Earned: " + _weeklyWage.ToString("c");
        }
    }
}
