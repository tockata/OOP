﻿using CompanyHierarchy.Enumerations;
namespace CompanyHierarchy
{
    public abstract class RegularEmployee : Employee
    {
        protected RegularEmployee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName, salary, department)
        {
            
        }
    }
}
