namespace a
{

    // UC6- Calculating Wages till Number of Working Days or
    // Total Working Hours per month is Reached
    class Program
    {

        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        public const int EMP_RATE_PER_HOUR = 20;
        public const int NUM_OF_WORKING_DAYS = 2;
        public const int MAX_HRS_IN_MONTH = 10;

        static void Main(string[] args)
        {

            int empHrs = 0, totalEmpHrs = 0, totalWorkingDays = 0;

            // Loop until either the maximum working hours or working days are reached
            while (totalEmpHrs <= MAX_HRS_IN_MONTH && totalWorkingDays < NUM_OF_WORKING_DAYS)
            {
                // Increment the working day
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

                // Print the daily employee hours
                Console.WriteLine($"Day#: {totalWorkingDays} Emp Hrs: {empHrs}");
            }

            // Calculate  total employee wage
            int totalEmpWage = totalEmpHrs * EMP_RATE_PER_HOUR;
            Console.WriteLine($"Total Emp Wage: {totalEmpWage}");
        }
    }


}

