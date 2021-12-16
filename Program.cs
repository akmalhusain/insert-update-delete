using System;
using System.Data.SqlClient;



namespace sqlconntionAdo
{
    class program
    {
        static void Main(string[] args)
        {
            program.coneection();
            Console.ReadLine(); 
        }
       static void coneection()
        {
            
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=VMDESKTOP-X6232\\MSSQLSERVER01; database=empdata; integrated security=true");
   
                Console.WriteLine("enter nickname");
                string nickname=Console.ReadLine();
                Console.WriteLine("enter age");
                string age = Console.ReadLine();
                Console.WriteLine("enter mobileNo");
               string mobileNo = Console.ReadLine();





                //SqlCommand cm = new SqlCommand("insert into emp_data values(@nickname,@age,@mobileNo)",con);
                SqlCommand cm = new SqlCommand("update emp_data set nickname=@nickname, age=@age,mobileNo=@mobileNo where age=@age", con);
               // SqlCommand cm = new SqlCommand("delete from emp_data where age=@age", con);

                cm.Parameters.AddWithValue("@nickname", nickname);
                cm.Parameters.AddWithValue("@age", age);
               cm.Parameters.AddWithValue("@mobileNo", mobileNo);

                con.Open();
                cm.ExecuteNonQuery();
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                con.Close();
            }
            
        }
    }
}