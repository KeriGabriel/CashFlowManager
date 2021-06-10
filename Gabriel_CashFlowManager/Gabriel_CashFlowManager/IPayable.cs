using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_CashFlowManager
{
    interface IPayable
    {
        decimal PayableAmount { get; }
        string ledgerType { get; }
        public string createInvoice();
        public enum LedgerType
        {
            Salaried,
            Hourly,
            Invoice,
            Payroll
        }
    }
   
}
