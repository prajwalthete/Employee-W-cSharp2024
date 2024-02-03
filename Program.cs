using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating instances for companies using EmphageBuilderObject
        EmphageBuilderObject dart = new EmphageBuilderObject("DMart", 20, 2, 10);
        EmphageBuilderObject reliance = new EmphageBuilderObject("Reliance", 10, 4, 28);

        // Computing and displaying employee wages
        dart.ComputeEmpWage();
        Console.WriteLine(dart.ToString());

        reliance.ComputeEmpWage();
        Console.WriteLine(reliance.ToString());
    }
}

public class EmphageBuilderObject
{
    // Constants for employee types
    public const int IS_PART_TIME = 1;
    public const int IS_FULL_TIME = 2;

    // Private fields
    private string company;
    private int empRatePerHour;
    private int numOfWorkingDays;
    private int maxHoursPerMonth;
    private int totalEmpWage;

    // Constructor
    public EmphageBuilderObject(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
    {
        this.company = company;
        this.empRatePerHour = empRatePerHour;
        this.numOfWorkingDays = numOfWorkingDays;
        this.maxHoursPerMonth = maxHoursPerMonth;
    }

    // Method to compute employee wage
    public void ComputeEmpWage()
    {
        // Variables
        int empHrs = 0, totalEmpHrs = 0, totalWorkingDays = 0;

        // Computation
        while (totalEmpHrs <= maxHoursPerMonth && totalWorkingDays < numOfWorkingDays)
        {
            totalWorkingDays++;
            Random random = new Random();
            int empCheck = random.Next(0, 3);

            switch (empCheck)
            {
                case IS_PART_TIME:
                    empHrs = 4;
                    break;
                case IS_FULL_TIME:
                    empHrs = 8;
                    break;
                default:
                    empHrs = 0;
                    break;
            }

            totalEmpHrs += empHrs;
            Console.WriteLine($"Day#: {totalWorkingDays} Emp Hrs: {empHrs}");
        }

        totalEmpWage = totalEmpHrs * empRatePerHour;
    }

    // Override ToString method for custom display
    public override string ToString()
    {
        return $"Total Emp Wage for company {company} is: {totalEmpWage}";
    }
}
