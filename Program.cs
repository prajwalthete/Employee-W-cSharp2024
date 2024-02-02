namespace a
{
    
    // UC1- Check If Employee is Present Or Not 
    class Program
    {
        // Constants
        const int IS_FULL_TIME = 1;

        static void Main(string[] args)
        {

            Random random = new Random();
            int empCheck = random.Next(0, 2);

            if (empCheck == IS_FULL_TIME)
            {
                Console.WriteLine("Employee is Present");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }
        }
    }


}
