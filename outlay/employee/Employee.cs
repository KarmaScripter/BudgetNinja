// // <copyright file = "Employee.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "IEmployee"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class Employee : EmployeeBase, IEmployee, ISource
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected virtual Source Source { get; set; } = Source.Employees;

        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

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
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public Employee( DataRow datarow )
        {
            Record = datarow;
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
        /// <param name = "epanumber" >
        /// The epanumber.
        /// </param>
        public Employee( string epanumber )
        {
            Record = new DataBuilder( Source, SetArgs( epanumber ) )?.GetRecord();
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

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

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
                    return default;
                }
            }

            return default;
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
                return Verify.Element( FirstName )
                    ? FirstName
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
                return Verify.Element( LastName )
                    ? LastName
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
                return Verify.Key( ID )
                    ? ID
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
                return Verify.Element( Section )
                    ? Section
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
                return Verify.Element( EmployeeNumber )
                    ? EmployeeNumber
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
                return Verify.Element( Office )
                    ? Office
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
                return Verify.Element( PhoneNumber )
                    ? PhoneNumber
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
                return Verify.Element( CellNumber )
                    ? CellNumber
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
                return Verify.Element( Email )
                    ? Email
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
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        // ***************************************************************************************************************************
        // ******************************************* INTERFACE IMPLIMENTATIONS *****************************************************
        // ***************************************************************************************************************************
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Verify.Source( Source )
                    ? Source
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
