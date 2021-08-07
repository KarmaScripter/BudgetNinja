// <copyright file = "Employee.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "IEmployee"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public class Employee : EmployeeBase, IEmployee, ISource
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly Source _source = Source.Employees;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        public Employee()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Employee( IQuery query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.EmployeeId );
            _section = new Element( _records, Field.Section );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _office = new Element( _records, Field.Office );
            _phoneNumber = new Element( _records, Field.PhoneNumber );
            _cellNumber = new Element( _records, Field.CellNumber );
            _email = new Element( _records, Field.Email );
            _status = new Element( _records, Field.Status );
            _args = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Employee( IBuilder builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.EmployeeId );
            _section = new Element( _records, Field.Section );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _office = new Element( _records, Field.Office );
            _phoneNumber = new Element( _records, Field.PhoneNumber );
            _cellNumber = new Element( _records, Field.CellNumber );
            _email = new Element( _records, Field.Email );
            _status = new Element( _records, Field.Status );
            _args = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public Employee( DataRow datarow )
        {
            _records = datarow;
            _id = new Key( _records, PrimaryKey.EmployeeId );
            _section = new Element( _records, Field.Section );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _office = new Element( _records, Field.Office );
            _phoneNumber = new Element( _records, Field.PhoneNumber );
            _cellNumber = new Element( _records, Field.CellNumber );
            _email = new Element( _records, Field.Email );
            _status = new Element( _records, Field.Status );
            _args = _records?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "epanumber" >
        /// The epanumber.
        /// </param>
        public Employee( string epanumber )
        {
            _records = new DataBuilder( _source, SetArgs( epanumber ) )?.GetRecord();
            _id = new Key( _records, PrimaryKey.EmployeeId );
            _section = new Element( _records, Field.Section );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _office = new Element( _records, Field.Office );
            _phoneNumber = new Element( _records, Field.PhoneNumber );
            _cellNumber = new Element( _records, Field.CellNumber );
            _email = new Element( _records, Field.Email );
            _status = new Element( _records, Field.Status );
            _args = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> SetArgs( string code )
        {
            if( Verify.Input( code ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.EmployeeNumber}" ] = code
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
        /// Gets the first name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetFirstName()
        {
            try
            {
                return Verify.Element( _firstName )
                    ? _firstName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetLastName()
        {
            try
            {
                return Verify.Element( _lastName )
                    ? _lastName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the employee identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
            }
        }

        /// <summary>
        /// Gets the section.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetSection()
        {
            try
            {
                return Verify.Element( _section )
                    ? _section
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmployeeNumber()
        {
            try
            {
                return Verify.Element( _employeeNumber )
                    ? _employeeNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the office.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetOffice()
        {
            try
            {
                return Verify.Element( _office )
                    ? _office
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the phone.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetPhoneNumber()
        {
            try
            {
                return Verify.Element( _phoneNumber )
                    ? _phoneNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetCellNumber()
        {
            try
            {
                return Verify.Element( _cellNumber )
                    ? _cellNumber
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmail()
        {
            try
            {
                return Verify.Element( _email )
                    ? _email
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the employement status.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmployementStatus()
        {
            try
            {
                return Verify.Element( _status )
                    ? _status
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( _args )
                    ? _args
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }
    }
}
