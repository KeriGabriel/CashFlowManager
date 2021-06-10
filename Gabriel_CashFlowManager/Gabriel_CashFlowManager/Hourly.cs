using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_CashFlowManager
{
   
    class Hourly : Employee
    {
        private string _firstName;
        private string _lastName;
        private string _SSN;
        private int _hoursWorked;
        private decimal _hourlyWage;
        private decimal _PayableAmount;
        private string _ledgerType;

        //public override string ledgerType => "Hourly";
        public override string ledgerType => _ledgerType;
        public override decimal PayableAmount => _PayableAmount;
        public Hourly(string firstname, string lastName, string SSN, int hoursWorked,decimal hourlyWage) : base(firstname, lastName, SSN)
        {
            _firstName = firstname;
            _lastName = lastName;
            _SSN = SSN;
            _hourlyWage = hourlyWage;
            _hoursWorked = hoursWorked;
            _ledgerType = IPayable.LedgerType.Hourly.ToString();
            generate_PayableAmount();
        }
        
        private string generate_PayableAmount()
        {
            if (_hoursWorked > 40)
                _PayableAmount = _hoursWorked * (_hourlyWage * 1.5m);
            else
                _PayableAmount = _hoursWorked * _hourlyWage;
            return _PayableAmount.ToString("c");
        }
        public override string createInvoice()
        {
            return "\n" +" "+ _ledgerType + " Employee: " + _firstName + " " + _lastName +
                "\n SSN: " + _SSN + "\n Hourly wage Salary: " + _hourlyWage.ToString("c")
                + "\n Hours Worked: " + _hoursWorked + "\n Earned: " + generate_PayableAmount();
        }

    
    }
        
        
}
