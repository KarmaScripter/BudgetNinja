// <copyright file = "Personnel.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "_employee"/>
    /// <seealso cref = "IEmployee"/>
    /// <seealso cref = "IDataBuilder"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Local" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "PrivateFieldCanBeConvertedToLocalVariable" ) ]
    public class Personnel : Employee
    {
        /// <summary>
        /// The employee
        /// </summary>
        private protected readonly IEmployee _employee;
        
        /// <summary>
        /// Gets the personnel dataRow.
        /// </summary>
        /// <value>
        /// The personnel dataRow.
        /// </value>
        private protected readonly IEmployee _contactData;

        /// <summary>
        /// Gets or sets the workforce dataRow.
        /// </summary>
        /// <value>
        /// The workforce dataRow.
        /// </value>
        private protected readonly IHumanResourceData _humanResourceData;

        /// <summary>
        /// Gets or sets the payroll dataRow.
        /// </summary>
        /// <value>
        /// The payroll dataRow.
        /// </value>
        private protected readonly IPayrollBase _payrollData;

        /// <summary>
        /// Gets the leave information.
        /// </summary>
        /// <value>
        /// The leave information.
        /// </value>
        private protected readonly ILeave _leaveData;

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
            _employee = new Employee( query );
            _contactData = GetContactData( _employee );
            _humanResourceData = GetHumanResourceData( _employee );
            _payrollData = GetPayrollData( _employee );
            _leaveData = GetLeaveData( _employee );
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
            _employee = new Employee( builder );
            _contactData = new ContactFactory( _employee );
            _humanResourceData = GetHumanResourceData( _employee );
            _payrollData = GetPayrollData( _employee );
            _leaveData = GetLeaveData( _employee );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetExecution.Employee"/>
        /// class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Personnel( DataRow dataRow )
            : base( dataRow )
        {
            _employee = new Employee( dataRow );
            _contactData = new ContactFactory( _employee );
            _humanResourceData = GetHumanResourceData( _employee );
            _payrollData = GetPayrollData( _employee );
            _leaveData = GetLeaveData( _employee );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Personnel"/> class.
        /// </summary>
        /// <param name = "epaNumber" >
        /// The epaNumber.
        /// </param>
        public Personnel( string epaNumber )
            : base( epaNumber )
        {
            _employee = new Employee( epaNumber );
            _contactData = new ContactFactory( _employee );
            _humanResourceData = GetHumanResourceData( _employee );
            _payrollData = GetPayrollData( _employee );
            _leaveData = GetLeaveData( _employee );
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:_system.String"/> that represents this instance.
        /// </returns>
        /// <inheritdoc>
        /// <cref>
        /// </cref>
        /// </inheritdoc>
        public override string ToString()
        {
            if( _records != null )
            {
                try
                {
                    return $"{_firstName} {_lastName}";
                }
                catch( Exception ex )
                {
                    Fail( ex );
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
            if( _id.GetIndex() > -1
                && Verify.Input( _section.GetValue() )
                && Verify.Input( _firstName.GetValue() )
                && Verify.Input( _lastName.GetValue() )
                && Verify.Input( _office.GetValue() )
                && Verify.Input( _phoneNumber.GetValue() )
                && Verify.Input( _cellNumber.GetValue() )
                && Verify.Input( _email.GetValue() ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ PrimaryKey.EmployeeId.ToString() ] = _id,
                        [ Field.Section.ToString() ] = _section.GetValue(),
                        [ Field.LastName.ToString() ] = _lastName.GetValue(),
                        [ Field.FirstName.ToString() ] = _firstName.GetValue(),
                        [ Field.Office.ToString() ] = _office.GetValue(),
                        [ Field.PhoneNumber.ToString() ] = _phoneNumber.GetValue(),
                        [ Field.CellNumber.ToString() ] = _cellNumber.GetValue(),
                        [ Field.Email.ToString() ] = _email.GetValue()
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name = "firstName" >
        /// The firstName.
        /// </param>
        /// <param name = "lastName" >
        /// The lastName.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs( string firstName, string lastName )
        {
            if( Verify.Input( firstName )
                && Verify.Input( lastName ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.FirstName.ToString() ] = firstName,
                        [ Field.LastName.ToString() ] = lastName
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Sets the contact dataRow.
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
                var _firstname = person?.GetFirstName();
                var _lastname = person?.GetLastName();
                var _dictionary = GetArgs( _firstname?.GetValue(), _lastname?.GetValue() );
                var _connection = new ConnectionBuilder( Source.Employees, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new Employee( _query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEmployee );
            }
        }

        /// <summary>
        /// Gets the contact dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEmployee GetContactData()
        {
            try
            {
                return _contactData ?? default( IEmployee );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEmployee );
            }
        }

        /// <summary>
        /// Sets the leave dataRow.
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
                var _firstname = person.GetFirstName();
                var _lastname = person.GetLastName();
                var _dictionary = GetArgs( _firstname?.GetValue(), _lastname?.GetValue() );
                var _connection = new ConnectionBuilder( Source.LeaveProjections, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new Leave( _query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ILeave );
            }
        }

        /// <summary>
        /// Gets the leave dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public ILeave GetLeaveData()
        {
            try
            {
                return _leaveData ?? default( ILeave );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ILeave );
            }
        }

        /// <summary>
        /// Sets the human resource dataRow.
        /// </summary>
        /// <param name = "person" >
        /// The person.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IHumanResourceData GetHumanResourceData( IPerson person )
        {
            try
            {
                var _firstname = person.GetFirstName();
                var _lastname = person.GetLastName();
                var _dictionary = GetArgs( _firstname?.GetValue(), _lastname?.GetValue() );
                var _connection = new ConnectionBuilder( Source.WorkforceData, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new HumanResourceData( _query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IHumanResourceData );
            }
        }

        /// <summary>
        /// Gets the workforce dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IHumanResourceData GetHumanResourceData()
        {
            try
            {
                return _humanResourceData ?? default( IHumanResourceData );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IHumanResourceData );
            }
        }

        /// <summary>
        /// Gets the payroll dataRow.
        /// </summary>
        /// <returns>
        /// </returns>
        public IPayrollBase GetPayrollData()
        {
            try
            {
                return _payrollData ?? default( IPayrollBase );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IPayrollBase );
            }
        }

        /// <summary>
        /// Sets the payroll dataRow.
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

                var _conection = new ConnectionBuilder( Source.PayrollHours, Provider.SQLite );
                var _statement = new SqlStatement( _conection, args, SQL.SELECT );
                using var _query = new Query( _conection, _statement );
                return new PayrollFactory( _query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IPayrollBase );
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
                && Verify.Input( _records[ $"{Field.RcCode}" ].ToString() )
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
                    Fail( ex );
                    return default( IDictionary<string, object> );
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
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}
