#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPmvc5_Ado.Repository
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ASPMVCADO")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ASPMVCADOConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.register")]
		public int register([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="VarChar(50)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="VarChar(50)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="VarChar(50)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, email, password);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.login")]
		public ISingleResult<loginResult> login()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<loginResult>)(result.ReturnValue));
		}
	}
	
	public partial class loginResult
	{
		
		private int _Column1;
		
		public loginResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int NOT NULL")]
		public int Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
