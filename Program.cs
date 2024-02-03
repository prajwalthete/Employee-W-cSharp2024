using System;
namespace a;

//UC-5 Calcuilating Wages for a Month 
class Program
{
    public const int IS_PART_TIME = 1;
    public const int IS_FULL_TIME = 2;
    public const int EMP_RATE_PER_HOUR = 20;
    public const int NUM_OF_WORKING_DAYS = 2;

    static void Main(string[] args)
    {
      
        int empHrs = 0, empWage = 0, totalEmpWage = 0;

        // Computation for each working day
        for (int day = 0; day < NUM_OF_WORKING_DAYS; day++)
        {
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

            empWage = empHrs * EMP_RATE_PER_HOUR;
            totalEmpWage += empWage;

            Console.WriteLine($"Day#: {day + 1} Emp Hrs: {empHrs} Emp Wage: {empWage}");
        }

        // Output total employee wage
        Console.WriteLine($"Total Emp Wage: {totalEmpWage}");
    }
}
