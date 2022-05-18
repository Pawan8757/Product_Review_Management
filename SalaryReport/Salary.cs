using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeemanagement
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayRoll_Service_Pwn;Integrated Security=True");
        }

        public int UpdateEmplyeeSalary(salaryUpdateModel salaryUpdateModel)
        {
            SqlConnection sqlConnection = ConnectionSetup();

            int Salary = 0;

            try
            {
                using (sqlConnection)
                {
                    SalaryModel salaryModel = new SalaryModel();


                    SqlCommand command = new SqlCommand("spUpdateEmlpyeeSalary1", sqlConnection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.salaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@Emplyeeid", salaryUpdateModel.Emplyeeid);

                    sqlConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            salaryModel.Emplyeeid = Convert.ToInt32(dr[0]);
                            salaryModel.EmployeeName = dr[1].ToString();
                            salaryModel.Employeeslary = Convert.ToInt32(dr[2]);
                            salaryModel.month = dr[3].ToString();
                            salaryModel.salaryid = Convert.ToInt32(dr[4]);

                        }

                        Console.WriteLine("[0],[1],[2]", salaryModel.EmployeeName, salaryModel.Employeeslary, salaryModel.month);
                        Salary = salaryModel.Employeeslary;
                    }
                    else
                    {
                        Console.WriteLine("NO data found");
                    }


                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                sqlConnection.Close();
            }
            return Salary;


        }

    }
}
