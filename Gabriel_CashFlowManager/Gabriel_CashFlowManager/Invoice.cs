using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_CashFlowManager
{
    class Invoice:IPayable
    {

        private string _partNember;
        private int _partQuantity;
        private string _partDescription;
        private decimal _partPrice;
        private decimal _PayableAmount;
        private string _ledgerType;
        //private string Parts;

        public Invoice(string partNember, int partQuantity, string partDescription, decimal partPrice)      
        {
            _partNember=partNember;
            _partQuantity = partQuantity;
            _partDescription = partDescription;
            _partPrice = partPrice;
            _ledgerType= IPayable.LedgerType.Invoice.ToString();
            generatePayableTotal();
        }
        private string generatePayableTotal()
        {
            _PayableAmount = _partQuantity * _partPrice;
            return _PayableAmount.ToString("c");
        }
        public string ledgerType => _ledgerType;
        
        decimal IPayable.PayableAmount => _PayableAmount;
       

        private string invoiceNumberGenerator()
        {
            Random invoiceNumber = new Random(DateTime.Now.Millisecond);
            int result = invoiceNumber.Next(100000, 999999);
            return result + "_" + _partNember;
        }
        public string createInvoice()
        {  
            return"\n "+ _ledgerType +" "+ invoiceNumberGenerator()+ "\n Quantity: " + _partQuantity + "\n Part Description: "+
            _partDescription + "\n Unit Price: "+ _partPrice.ToString("c") + "\n Extended Price: "+ generatePayableTotal();
        }
    }
    
}
