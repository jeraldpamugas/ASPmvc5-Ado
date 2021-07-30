# ASPmvc5-Ado
ASP.Net MVC5 using ADO

1. Create Web App ( c# )
    - Empty
    - check MVC
    
2. Add model ( EmpModel.cs )
  
  public class EmpModel  
  {  
      [Display(Name = "Id")]  
      public int Empid { get; set; }  
  
      [Required(ErrorMessage = "First name is required.")]  
      public string Name { get; set; }  
  
      [Required(ErrorMessage = "City is required.")]  
      public string City { get; set; }  
  
      [Required(ErrorMessage = "Address is required.")]  
      public string Address { get; set; }  
  
  } 
  
3. Add MVC Controller
  - MVC 5 Controller w/ read/write actions
  
4. Create Database and Table ( MSSQL )

  To Insert Records :
  Create procedure [dbo].[AddNewEmpDetails]  
  (  
     @Name varchar (50),  
     @City varchar (50),  
     @Address varchar (50)  
  )  
  as  
  begin  
     Insert into Employee values(@Name,@City,@Address)  
  End 
  
  To View Added Records :
  Create Procedure [dbo].[GetEmployees]  
  as  
  begin  
     select *from Employee  
  End 

  To Update Records :
  Create procedure [dbo].[UpdateEmpDetails]  
  (  
     @EmpId int,  
     @Name varchar (50),  
     @City varchar (50),  
     @Address varchar (50)  
  )  
  as  
  begin  
     Update Employee   
     set Name=@Name,  
     City=@City,  
     Address=@Address  
     where Id=@EmpId  
  End 
  
  To Delete Records :
  Create procedure [dbo].[DeleteEmpById]  
  (  
     @EmpId int  
  )  
  as   
  begin  
     Delete from Employee where Id=@EmpId  
  End 

5. Now create Repository folder and Add EmpRepository.cs class for database related operations.
  public class EmpRepository    
  {    

      private SqlConnection con;    
      //To Handle connection related activities    
      private void connection()    
      {    
          string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();    
          con = new SqlConnection(constr);    

      }    
      //To Add Employee details    
      public bool AddEmployee(EmpModel obj)    
      {    

          connection();    
          SqlCommand com = new SqlCommand("AddNewEmpDetails", con);    
          com.CommandType = CommandType.StoredProcedure;    
          com.Parameters.AddWithValue("@Name", obj.Name);    
          com.Parameters.AddWithValue("@City", obj.City);    
          com.Parameters.AddWithValue("@Address", obj.Address);    

          con.Open();    
          int i = com.ExecuteNonQuery();    
          con.Close();    
          if (i >= 1)    
          {    

              return true;    

          }    
          else    
          {    

              return false;    
          }    


      }    
      //To view employee details with generic list     
      public List<EmpModel> GetAllEmployees()    
      {    
          connection();    
          List<EmpModel> EmpList =new List<EmpModel>();    


          SqlCommand com = new SqlCommand("GetEmployees", con);    
          com.CommandType = CommandType.StoredProcedure;    
          SqlDataAdapter da = new SqlDataAdapter(com);    
          DataTable dt = new DataTable();    

          con.Open();    
          da.Fill(dt);    
          con.Close();    
          //Bind EmpModel generic list using dataRow     
          foreach (DataRow dr in dt.Rows)    
          {    

              EmpList.Add(    

                  new EmpModel {    

                      Empid = Convert.ToInt32(dr["Id"]),    
                      Name =Convert.ToString( dr["Name"]),    
                      City = Convert.ToString( dr["City"]),    
                      Address = Convert.ToString(dr["Address"])    

                  }   
                  );
          }    

          return EmpList;
      }    
      //To Update Employee details    
      public bool UpdateEmployee(EmpModel obj)    
      {    

          connection();    
          SqlCommand com = new SqlCommand("UpdateEmpDetails", con);    

          com.CommandType = CommandType.StoredProcedure;    
          com.Parameters.AddWithValue("@EmpId", obj.Empid);    
          com.Parameters.AddWithValue("@Name", obj.Name);    
          com.Parameters.AddWithValue("@City", obj.City);    
          com.Parameters.AddWithValue("@Address", obj.Address);    
          con.Open();    
          int i = com.ExecuteNonQuery();    
          con.Close();    
          if (i >= 1)    
          {    

              return true;
          }    
          else    
          {
              return false;    
          }
      }    
      //To delete Employee details    
      public bool DeleteEmployee(int Id)    
      {    

          connection();    
          SqlCommand com = new SqlCommand("DeleteEmpById", con);    

          com.CommandType = CommandType.StoredProcedure;    
          com.Parameters.AddWithValue("@EmpId", Id);    

          con.Open();    
          int i = com.ExecuteNonQuery();    
          con.Close();    
          if (i >= 1)    
          {
              return true;
          }    
          else    
          {    

              return false;    
          }
      }    
    }   
  
  6. Create the Partial view to Add the employees (right-click method in controller and slect [add view])
  
  7. Configure RouteConfig.cs to set default action as in the following code snippet:
    public class RouteConfig  
     {  
         public static void RegisterRoutes(RouteCollection routes)  
         {  
             routes.IgnoreRoute("{resource}.axd/{*pathInfo}");  

             routes.MapRoute(  
                 name: "Default",  
                 url: "{controller}/{action}/{id}",  
                 defaults: new { controller = "Employee", action = "AddEmployee", id = UrlParameter.Optional }  
             );  
         }  
     } 


-----------------------------------------------------------------------------------------------------------------------
AUTH Store Proc:

--LOGIN
USE [ASPMVCADO]
GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 7/30/2021 4:44:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ALTER proc [dbo].[login]
--as
--select 2

ALTER proc [dbo].[login]
(
@NameOrEmail varchar(50),
@Password varchar(50)
)
as
select count(*) from Users where Name = @NameOrEmail and Password = @Password or Email = @NameOrEmail and Password = @Password

--REGISTER
USE [ASPMVCADO]
GO
/****** Object:  StoredProcedure [dbo].[register]    Script Date: 7/30/2021 4:45:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[register]
(
@Name varchar(50),
@Email varchar(50),
@Password varchar(50)
)
as
insert into Users values (@Name, @Email, @Password)
