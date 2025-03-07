using SalaryPackaging.Models;

namespace SalaryPackaging.Services
{
    public interface ISalaryPackagingService
    {
        decimal CalculatePackageLimit(Employee employee);
    }
}