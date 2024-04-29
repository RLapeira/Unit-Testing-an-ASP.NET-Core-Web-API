﻿using EmployeeManagement.Business;
using EmployeeManagement.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTestsWithAspNetCoreDI
        : IClassFixture<EmployeeServiceWithAspNetCoreDIFixture>
    {
        private readonly EmployeeServiceWithAspNetCoreDIFixture _employeeServiceFixture;

        public EmployeeServiceTestsWithAspNetCoreDI(
            EmployeeServiceWithAspNetCoreDIFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            // Arrange
            var obligatoryCourse = _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var internalEmployee = _employeeServiceFixture
                .EmployeeService
                .CreateInternalEmployee("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
        }
    }
}
