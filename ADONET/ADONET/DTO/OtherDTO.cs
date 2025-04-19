namespace ADONET.DTO
{
    public class EmployeeAndAppUserDTO
    {
        public List<EmployeeDTO> Employees { get; set; }
        public List<AppUserDTO> AppUsers { get; set; }
    }

    public class EmployeesProductsDTO
    {
        public List<EmployeeDTO>? Employees { get; set; }
        public List<ProductDTO>? Products { get; set; }
    }
}
