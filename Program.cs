using System;

namespace a;
public class CompanyEmpWage
{
    public string Company;
    public int EmpRatePerHour;
    public int NumOfWorkingDays;
    public int MaxHoursPerMonth;
    public int TotalEmpWage;

    public CompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
    {
        this.Company = company;
        this.EmpRatePerHour = empRatePerHour;
        this.NumOfWorkingDays = numOfWorkingDays;
        this.MaxHoursPerMonth = maxHoursPerMonth;
    }

    public void SetTotalEmpWage(int totalEmpWage)
    {
        this.TotalEmpWage = totalEmpWage;
    }

    public override string ToString()
    {
        return $"Total Emp Wage for company {Company} is: {TotalEmpWage}";
    }
}

public class EmpWageBuilderArray
{
    private int numOfCompanies = 0;
    private CompanyEmpWage[] companyEmpWages;

    public EmpWageBuilderArray()
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

    static void Main(string[] args)
    {
        EmpWageBuilderArray empWageBuilder = new EmpWageBuilderArray();
        empWageBuilder.AddCompanyEmpWage("DMart", 20, 2, 10);
        empWageBuilder.AddCompanyEmpWage("Reliance", 10, 4, 20);
        empWageBuilder.ComputeEmpWage();
    }
}
