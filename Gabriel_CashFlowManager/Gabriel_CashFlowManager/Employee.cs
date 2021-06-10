using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_CashFlowManager
{
    
    class Employee:IPayable
    {
        private string _firstName;
        private string _lastName;
        private string _SSN;
        private string _ledgerType;
        private decimal _PayableAmount;      

        public Employee(string firstname, string lastName, string SSN)
        {
            _firstName = firstname;
            _lastName = lastName;
            _SSN = SSN;
            _ledgerType = IPayable.LedgerType.Payroll.ToString();
        }


        public virtual string ledgerType => _ledgerType;
        public virtual decimal PayableAmount => _PayableAmount;
        public virtual string createInvoice()
        {
            return "\n"+_ledgerType+ " Employee: " + _firstName + " " + _lastName + 
                "\nSSN: " + _SSN + "\nEarned: " + _PayableAmount.ToString("c");
        }
    }
}
