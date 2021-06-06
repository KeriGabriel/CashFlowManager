using System;

// Keri Gabriel
// IT112 
// NOTES: None
// BEHAVIORS NOT IMPLEMENTED AND WHY: none

namespace Gabriel_CashFlowManager
{
    class Program
    {     
        static void Main(string[] args)
        {
            decimal PartsWeeklyPayout = 0;
            decimal salariedWeeklyPayout = 0;
            decimal hourlyWeeklyPayout = 0;
            string totalWeeklyPayout;
            string choice;
            bool IsRunning = true;
            int index = 8;
            const int MAX_SIZE = 50;
            IPayable[] ledgers = new IPayable[MAX_SIZE];

            ledgers[0] = new Invoice("2536", 2, "flux Capacitor", 3655.66m);
            ledgers[1] = new Hourly("Karen", "Williams", "222-22-2222", 40, 16.75m);
            ledgers[2] = new Salaried("John", "Smith", "111-11-1111", 800.50m);
            ledgers[3] = new Invoice("5896", 3, "Plutonium", 8383.68m);
            ledgers[4] = new Invoice("5896", 1, "Onboard nuclear reactor", 10000.95m);
            ledgers[5] = new Salaried("Jennifer", "Parker", "555-11-5555", 900.20m);
            ledgers[6] = new Salaried("Martin", "Seamus", "444-11-4444", 700.50m);
            ledgers[7] = new Hourly("Emmett", "Brown", "777-22-7777", 35, 25.15m);
            ledgers[8] = new Hourly("Linda", "McFly", "888-22-8888", 20, 30.75m);

            //weeklyPayouts();
            while (IsRunning)
            {
                PrintMenu();
                switch (choice)
                {
                    case "1":
                        //hourly employee
                        addHourlyEmployeeMenu();
                        break;                    
                    case "2":
                        //Salaried employee
                        addSalariedEmployeeMenu();
                        break;
                    case "3":
                        //Add new invoice
                        addInvoiceMenu();
                        break;
                    case "4":
                        //Print Weekly Cash Flow Analysis
                        weeklyPayouts();
                        printInvoices();
                        generateTotals();
                        Console.WriteLine("Exit Press any key to Exit\n");
                        IsRunning = false;                       
                        break;
                    default:
                        Console.WriteLine(" Enter a number from the menu ");
                        break;
                }
            }
           
            void addHourlyEmployeeMenu()
            {
                Console.WriteLine("Add new hourly employee: \n");
                Console.WriteLine("Enter First Name: \n");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter Last Name: \n");
                string lastname = Console.ReadLine();
                Console.WriteLine("Enter SSN: \n");
                string SSN = Console.ReadLine();
                Console.WriteLine("Enter hours worked this week: \n");
                string hours = Console.ReadLine();
                int hoursWorked = Convert.ToInt32(hours);
                Console.WriteLine("Enter hourly wage: \n");
                string wage = Console.ReadLine();
                decimal hourlyWage = Convert.ToDecimal(wage);
                Console.WriteLine("\n***Added this employee*** ");
                Console.WriteLine("\n Name: " + firstname + " " + lastname + "\n SSN: " + SSN + "\n Hours this week: " + hoursWorked + "\n Wage " + hourlyWage + "\n");
                index++;
                ledgers[index]= new Hourly(firstname, lastname, SSN, hoursWorked, hourlyWage);
            }

            void addSalariedEmployeeMenu()
            {
                Console.WriteLine("Add new Salaried employee: \n");
                Console.WriteLine("Enter First Name: \n");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter Last Name: \n");
                string lastname = Console.ReadLine();
                Console.WriteLine("Enter SSN: \n");
                string SSN = Console.ReadLine();                
                Console.WriteLine("Enter weekly wage: \n");
                string wage = Console.ReadLine();
                decimal weeklyWage = Convert.ToDecimal(wage);
                Console.WriteLine("\n***Added this employee*** ");
                Console.WriteLine("\n Name: " + firstname + " " + lastname + "\n SSN: " + SSN + "\n Weekly wage: " + weeklyWage +"\n");
                index++;
                ledgers[index] = new Salaried(firstname, lastname, SSN, weeklyWage);
            }

            void addInvoiceMenu()
            {            
                Console.WriteLine("Add a new invoice: \n");
                Console.WriteLine("Enter Part number: \n");
                string partNember = Console.ReadLine();
                Console.WriteLine("Enter  Quantity: \n");
                string p = Console.ReadLine();
                int partQuantity = Convert.ToInt32(p);
                Console.WriteLine("Enter part Description: \n");
                string partDescription = Console.ReadLine();
                Console.WriteLine("Enter part price: \n");
                string price = Console.ReadLine();
                decimal partPrice = Convert.ToDecimal(price);               
                Console.WriteLine("\n***Added invoice*** ");
                Console.WriteLine("\n Part Number: " + partNember + "\n Part Quantity " + partQuantity + "\n Part Description " + partDescription + 
                    "\n Price " + partPrice + "\n");
                index++;
                ledgers[index] = new Invoice( partNember, partQuantity, partDescription,partPrice);
            }

            void PrintMenu()
            {

                Console.WriteLine("Please make a selection \n");
                Console.WriteLine("1: Add new hourly employee \n");
                Console.WriteLine("2: Add new Salaried employee \n");
                Console.WriteLine("3: Add new invoice \n");
                Console.WriteLine("4: Print Weekly Cash Flow Analysis and exit application \n");                              
                 choice= Console.ReadLine();
                
            }

            
            void weeklyPayouts() 
            { 
            for (int i = 0; i < ledgers.Length; i++)
            {
                if (ledgers[i] == null)
                    break;
                if (ledgers[i].ledgerType == "Parts")
                {
                   PartsWeeklyPayout = PartsWeeklyPayout + ledgers[i].PayableAmount;   
                }
                if (ledgers[i].ledgerType == "Salaried")
                {   
                    salariedWeeklyPayout = salariedWeeklyPayout + ledgers[i].PayableAmount;
                }
                if (ledgers[i].ledgerType == "Hourly")
                {
                    hourlyWeeklyPayout = hourlyWeeklyPayout + ledgers[i].PayableAmount;
                }
            }
            }

            string TotalWeeklyPayout(decimal PartsWeeklyPayout, decimal salariedWeeklyPayout, decimal hourlyWeeklyPayout)
            {             
                totalWeeklyPayout = (PartsWeeklyPayout + salariedWeeklyPayout + hourlyWeeklyPayout).ToString("c");
                return totalWeeklyPayout;
            }

            void generateTotals()
            {
                TotalWeeklyPayout(PartsWeeklyPayout, salariedWeeklyPayout, hourlyWeeklyPayout);
                Console.WriteLine("\n ****Totals for the week****");
                Console.WriteLine("\n Total Weekly Payout:" + totalWeeklyPayout);
                Console.WriteLine(" Invoices: " + PartsWeeklyPayout.ToString("c"));
                Console.WriteLine(" Salaried Payroll: " + salariedWeeklyPayout.ToString("c"));
                Console.WriteLine(" Hourly Payroll: " + hourlyWeeklyPayout.ToString("c")+"\n");              
            }
            void printInvoices()
            {
                Console.WriteLine("Weekly Cash Flow Analysis is as follows: ");
                for (int i = 0; i < ledgers.Length; i++)
                {
                    if (ledgers[i] == null)
                        break;
                    if (ledgers[i] != null)
                    {
                        Console.WriteLine(ledgers[i].createInvoice());
                      
                    }
                }
            }
        }      
    }
}
