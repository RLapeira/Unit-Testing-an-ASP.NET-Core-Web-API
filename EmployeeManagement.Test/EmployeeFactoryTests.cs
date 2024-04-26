﻿using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500,
                "Salary not in acceptable range");
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.True(employee.Salary >= 2500);
            Assert.True(employee.Salary <= 3500);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");

            // Assert
            Assert.InRange(employee.Salary, 2500, 3500);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
            // Arrange
            var employeeFactory = new EmployeeFactory();

            // Act
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
            employee.Salary = 2500.123m;

            // Assert
            Assert.Equal(2500, employee.Salary, 0);
            // 0 indicates the number of decimals that the assert has in mind
        }

        [Fact]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            // Arrange
            var factory = new EmployeeFactory();

            // Act
            var employee = factory.CreateEmployee("Kevin", "Dockx", "Marvin", true);

            // Assert
            Assert.IsType<ExternalEmployee>(employee);
            //Assert.IsAssignableFrom<Employee>(employee);
            // True if employee is an object of Employee or a subclass
        }
    }
}
