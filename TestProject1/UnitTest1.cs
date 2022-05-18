using Employeemanagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Salary sal = new Salary();

            salaryUpdateModel salary1 = new salaryUpdateModel()
            {
                salaryId = 1,
                Month = "Jan",
                EmployeeSalary = 12000,
                Emplyeeid = 1

            };

            int EmpSalary = sal.UpdateEmplyeeSalary(salary1);

            Assert.AreEqual(salary1.EmployeeSalary, EmpSalary);



        }
    }
}