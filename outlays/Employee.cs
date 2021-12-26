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
    public class Employee : IEmployee, ISource
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; } = Source.Employees;

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Args { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        public IElement EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public IElement Section { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public IElement Status { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public IElement FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public IElement LastName { get; set; }

        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        /// <value>
        /// The office.
        /// </value>
        public IElement Office { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public IElement PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the cell number.
        /// </summary>
        /// <value>
        /// The cell number.
        /// </value>
        public IElement CellNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public IElement Email { get; set; }

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.EmployeeId );
            Section = new Element( Record, Field.Section );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            Office = new Element( Record, Field.Office );
            PhoneNumber = new Element( Record, Field.PhoneNumber );
            CellNumber = new Element( Record, Field.CellNumber );
            Email = new Element( Record, Field.Email );
            Status = new Element( Record, Field.Status );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Employee( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.EmployeeId );
            Section = new Element( Record, Field.Section );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            Office = new Element( Record, Field.Office );
            PhoneNumber = new Element( Record, Field.PhoneNumber );
            CellNumber = new Element( Record, Field.CellNumber );
            Email = new Element( Record, Field.Email );
            Status = new Element( Record, Field.Status );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Employee( DataRow dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.EmployeeId );
            Section = new Element( Record, Field.Section );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            Office = new Element( Record, Field.Office );
            PhoneNumber = new Element( Record, Field.PhoneNumber );
            CellNumber = new Element( Record, Field.CellNumber );
            Email = new Element( Record, Field.Email );
            Status = new Element( Record, Field.Status );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Employee"/> class.
        /// </summary>
        /// <param name = "epaNumber" >
        /// The epaNumber.
        /// </param>
        public Employee( string epaNumber )
        {
            Record = new DataBuilder( Source, SetArgs( epaNumber ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.EmployeeId );
            Section = new Element( Record, Field.Section );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            Office = new Element( Record, Field.Office );
            PhoneNumber = new Element( Record, Field.PhoneNumber );
            CellNumber = new Element( Record, Field.CellNumber );
            Email = new Element( Record, Field.Email );
            Status = new Element( Record, Field.Status );
            Args = Record?.ToDictionary();
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
        /// Gets the employement status.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmployementStatus()
        {
            try
            {
                return Verify.Element( Status )
                    ? Status
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
                return Verify.Map( Args )
                    ? Args
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
                return Validate.Source( Source )
                    ? Source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }
        
        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
