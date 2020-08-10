// // <copyright file = "Personnel.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "Employee"/>
    /// <seealso cref = "IEmployee"/>
    /// <seealso cref = "IDataBuilder"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PrivateFieldCanBeConvertedToLocalVariable" ) ]
    public class Personnel : Employee
    {
        // ***************************************************************************************************************************
        // *********************************************    FIELDS      **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The employee
        /// </summary>
        private readonly IEmployee Employee;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Personnel"/> class.
        /// </summary>
        public Personnel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Personnel"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Personnel( IQuery query )
            : base( query )
        {
            Employee = new Employee( query );
            ContactData = GetContactData( Employee );
            HumanResourceData = GetHumanResourceData( Employee );
            PayrollData = GetPayrollData( Employee );
            LeaveData = GetLeaveData( Employee );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Personnel"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Personnel( IBuilder builder )
            : base( builder )
        {
            Employee = new Employee( builder );
            ContactData = new ContactFactory( Employee );
            HumanResourceData = GetHumanResourceData( Employee );
            PayrollData = GetPayrollData( Employee );
            LeaveData = GetLeaveData( Employee );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.Employee"/>
        /// class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Personnel( DataRow data )
            : base( data )
        {
            Employee = new Employee( data );
            ContactData = new ContactFactory( Employee );
            HumanResourceData = GetHumanResourceData( Employee );
            PayrollData = GetPayrollData( Employee );
            LeaveData = GetLeaveData( Employee );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Personnel"/> class.
        /// </summary>
        /// <param name = "epanumber" >
        /// The epanumber.
        /// </param>
        public Personnel( string epanumber )
            : base( epanumber )
        {
            Employee = new Employee( epanumber );
            ContactData = new ContactFactory( Employee );
            HumanResourceData = GetHumanResourceData( Employee );
            PayrollData = GetPayrollData( Employee );
            LeaveData = GetLeaveData( Employee );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the personnel data.
        /// </summary>
        /// <value>
        /// The personnel data.
        /// </value>
        private protected IEmployee ContactData { get; set; }

        /// <summary>
        /// Gets or sets the workforce data.
        /// </summary>
        /// <value>
        /// The workforce data.
        /// </value>
        private protected IWorkforceData HumanResourceData { get; set; }

        /// <summary>
        /// Gets or sets the payroll data.
        /// </summary>
        /// <value>
        /// The payroll data.
        /// </value>
        private protected IPayrollBase PayrollData { get; set; }

        /// <summary>
        /// Gets the leave information.
        /// </summary>
        /// <value>
        /// The leave information.
        /// </value>
        private protected ILeave LeaveData { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:System.String"/> that represents this instance.
        /// </returns>
        /// <inheritdoc>
        /// <cref>
        /// </cref>
        /// </inheritdoc>
        public override string ToString()
        {
            if( Record != null )
            {
                try
                {
                    return $"{FirstName} {LastName}";
                }
                catch( Exception ex )
                {
                    Personnel.Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public new IDictionary<string, object> ToDictionary()
        {
            if( ID.GetIndex() > -1
                && Verify.Input( Section.GetValue() )
                && Verify.Input( FirstName.GetValue() )
                && Verify.Input( LastName.GetValue() )
                && Verify.Input( Office.GetValue() )
                && Verify.Input( PhoneNumber.GetValue() )
                && Verify.Input( CellNumber.GetValue() )
                && Verify.Input( Email.GetValue() ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ PrimaryKey.EmployeeId.ToString() ] = ID,
                        [ Field.Section.ToString() ] = Section.GetValue(),
                        [ Field.LastName.ToString() ] = LastName.GetValue(),
                        [ Field.FirstName.ToString() ] = FirstName.GetValue(),
                        [ Field.Office.ToString() ] = Office.GetValue(),
                        [ Field.PhoneNumber.ToString() ] = PhoneNumber.GetValue(),
                        [ Field.CellNumber.ToString() ] = CellNumber.GetValue(),
                        [ Field.Email.ToString() ] = Email.GetValue()
                    };
                }
                catch( Exception ex )
                {
                    Personnel.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name = "firstname" >
        /// The firstname.
        /// </param>
        /// <param name = "lastname" >
        /// The lastname.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs( string firstname, string lastname )
        {
            if( Verify.Input( firstname )
                && Verify.Input( lastname ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.FirstName.ToString() ] = firstname,
                        [ Field.LastName.ToString() ] = lastname
                    };
                }
                catch( Exception ex )
                {
                    Personnel.Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Sets the contact data.
        /// </summary>
        /// <param name = "person" >
        /// The person.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IEmployee GetContactData( IPerson person )
        {
            try
            {
                var firstname = person?.GetFirstName();
                var lastname = person?.GetLastName();
                var args = GetArgs( firstname?.GetValue(), lastname?.GetValue() );
                var connection = new ConnectionBuilder( Source.Employees, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Employee( query );
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the contact data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEmployee GetContactData()
        {
            try
            {
                return ContactData ?? default;
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the leave data.
        /// </summary>
        /// <param name = "person" >
        /// The person.
        /// </param>
        /// <returns>
        /// </returns>
        private protected ILeave GetLeaveData( IPerson person )
        {
            try
            {
                var firstname = person.GetFirstName();
                var lastname = person.GetLastName();
                var args = GetArgs( firstname?.GetValue(), lastname?.GetValue() );
                var connection = new ConnectionBuilder( Source.LeaveProjections, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Leave( query );
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the leave data.
        /// </summary>
        /// <returns>
        /// </returns>
        public ILeave GetLeaveData()
        {
            try
            {
                return LeaveData ?? default;
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );

                return default;
            }
        }

        /// <summary>
        /// Sets the human resource data.
        /// </summary>
        /// <param name = "person" >
        /// The person.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IWorkforceData GetHumanResourceData( IPerson person )
        {
            try
            {
                var firstname = person.GetFirstName();
                var lastname = person.GetLastName();
                var args = GetArgs( firstname?.GetValue(), lastname?.GetValue() );
                var connection = new ConnectionBuilder( Source.WorkforceData, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new WorkforceData( query );
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the workforce data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IWorkforceData GetHumanResourceData()
        {
            try
            {
                return HumanResourceData ?? default;
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the payroll data.
        /// </summary>
        /// <returns>
        /// </returns>
        public IPayrollBase GetPayrollData()
        {
            try
            {
                return PayrollData ?? default;
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Sets the payroll data.
        /// </summary>
        /// <param name = "person" >
        /// The person.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IPayrollBase GetPayrollData( IPerson person )
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.EmployeeNumber}" ] = person.GetEmployeeNumber()
                };

                var conection = new ConnectionBuilder( Source.PayrollHours, Provider.SQLite );
                var sqlstatement = new SqlStatement( conection, args, SQL.SELECT );
                using var query = new Query( conection, sqlstatement );
                return new PayrollFactory( query );
            }
            catch( Exception ex )
            {
                Personnel.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> GetArgs( string code )
        {
            if( Verify.Input( code )
                && Verify.Input( Record[ $"{Field.RcCode}" ].ToString() )
                && code.StartsWith( "06", StringComparison.Ordinal )
                && code.Length <= 3 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.RcCode.ToString() ] = code
                    };
                }
                catch( Exception ex )
                {
                    Personnel.Fail( ex );
                    return default;
                }
            }

            if( Verify.Input( code )
                && code.StartsWith( "6", StringComparison.Ordinal )
                && code.Length > 3 )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.Section.ToString() ] = code
                    };
                }
                catch( Exception ex )
                {
                    Personnel.Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}
