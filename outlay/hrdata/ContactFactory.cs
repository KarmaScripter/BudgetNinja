// <copyright file="ContactFactory.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IEmployee"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class ContactFactory : IEmployee
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
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "employee" >
        /// The employee.
        /// </param>
        public ContactFactory( IEmployee employee )
        {
            Employee = employee;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public ContactFactory( IQuery query )
        {
            Employee = new Employee( query );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public ContactFactory( IBuilder builder )
        {
            Employee = new Employee( builder );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public ContactFactory( DataRow datarow )
        {
            Employee = new Employee( datarow );
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the employee identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                var id = Employee?.GetId();

                return id?.GetIndex() > 0
                    ? id
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
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
                var lastname = Employee?.GetFirstName();

                return Verify.Input( lastname?.GetValue() )
                    ? lastname
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var lastname = Employee?.GetLastName();

                return Verify.Input( lastname?.GetValue() )
                    ? lastname
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Employee?.GetSection();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var eid = Employee?.GetEmployeeNumber();

                return Verify.Input( eid?.GetValue() )
                    ? eid
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var office = Employee?.GetOffice();

                return Verify.Input( office?.GetValue() )
                    ? office
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var number = Employee?.GetPhoneNumber();

                return Verify.Input( number?.GetValue() )
                    ? number
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var cell = Employee?.GetCellNumber();

                return Verify.Input( cell?.GetValue() )
                    ? cell
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var email = Employee?.GetEmail();

                return Verify.Input( email?.GetValue() )
                    ? email
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                var status = Employee?.GetEmployementStatus();

                return Verify.Input( status?.GetValue() )
                    ? status
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new StaticError( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}