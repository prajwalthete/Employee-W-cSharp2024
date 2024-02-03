

// UC -10 -B BUT  DEC AS UC-11 Support Employee Wage for Multiple Company using Interface approach

using System;

// Define an interface for calculating employee wage
public interface IComputeEmpWage
{
    void AddCompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth);
    void ComputeEmpWage();
}

// Implement the interface in a class
public class EmpWageBuilder : IComputeEmpWage
{
    private int numOfCompanies = 0;
    private CompanyEmpWage[] companyEmpWages;

    public EmpWageBuilder()
    {
        companyEmpWages = new CompanyEmpWage[5];
    }

    public void AddCompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
    {
        companyEmpWages[numOfCompanies] = new CompanyEmpWage(company, empRatePerHour, numOfWorkingDays, maxHoursPerMonth);
        numOfCompanies++;
    }

    public void ComputeEmpWage()
    {
        for (int i = 0; i < numOfCompanies; i++)
        {
            ComputeEmpWage(companyEmpWages[i]);
            Console.WriteLine(companyEmpWages[i].ToString());
        }
    }

    private void ComputeEmpWage(CompanyEmpWage companyEmpWage)
    {
        int empHrs = 0, totalEmpHrs = 0, totalWorkingDays = 0;

        while (totalEmpHrs <= companyEmpWage.MaxHoursPerMonth && totalWorkingDays < companyEmpWage.NumOfWorkingDays)
        {
            totalWorkingDays++;
            Random random = new Random();
            int empCheck = random.Next(0, 3);

            switch (empCheck)
            {
                case 1: // IS_PART_TIME
                    empHrs = 4;
                    break;
                case 2: // IS_FULL_TIME
                    empHrs = 8;
                    break;
                default:
                    empHrs = 0;
                    break;
            }

            totalEmpHrs += empHrs;
        }

        int totalEmpWage = totalEmpHrs * companyEmpWage.EmpRatePerHour;
        companyEmpWage.SetTotalEmpWage(totalEmpWage);
    }
}

// Define a class to encapsulate company details
public class CompanyEmpWage
{
    public string Company { get; }
    public int EmpRatePerHour { get; }
    public int NumOfWorkingDays { get; }
    public int MaxHoursPerMonth { get; }
    public int TotalEmpWage { get; private set; }

    public CompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
    {
        Company = company;
        EmpRatePerHour = empRatePerHour;
        NumOfWorkingDays = numOfWorkingDays;
        MaxHoursPerMonth = maxHoursPerMonth;
    }

    public void SetTotalEmpWage(int totalEmpWage)
    {
        TotalEmpWage = totalEmpWage;
    }

    public override string ToString()
    {
        return $"Total Emp Wage for company {Company} is: {TotalEmpWage}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        IComputeEmpWage empWageBuilder = new EmpWageBuilder();
        empWageBuilder.AddCompanyEmpWage("DMart", 20, 2, 10);
        empWageBuilder.AddCompanyEmpWage("Reliance", 10, 4, 20);
        empWageBuilder.ComputeEmpWage();
    }
}
