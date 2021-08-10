// <copyright file = "ContactFactory.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IEmployee"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class ContactFactory : IEmployee
    {
        /// <summary>
        /// The employee
        /// </summary>
        private readonly IEmployee _employee;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "employee" >
        /// The employee.
        /// </param>
        public ContactFactory( IEmployee employee )
        {
            _employee = employee;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public ContactFactory( IQuery query )
        {
            _employee = new Employee( query );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public ContactFactory( IBuilder builder )
        {
            _employee = new Employee( builder );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ContactFactory"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public ContactFactory( DataRow dataRow )
        {
            _employee = new Employee( dataRow );
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
                var _id = _employee?.GetId();

                return _id?.GetIndex() > 0
                    ? _id
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
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
                var _lastname = _employee?.GetFirstName();

                return Verify.Input( _lastname?.GetValue() )
                    ? _lastname
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _lastname = _employee?.GetLastName();

                return Verify.Input( _lastname?.GetValue() )
                    ? _lastname
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return _employee?.GetSection();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _eid = _employee?.GetEmployeeNumber();

                return Verify.Input( _eid?.GetValue() )
                    ? _eid
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _office = _employee?.GetOffice();

                return Verify.Input( _office?.GetValue() )
                    ? _office
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _number = _employee?.GetPhoneNumber();

                return Verify.Input( _number?.GetValue() )
                    ? _number
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var cell = _employee?.GetCellNumber();

                return Verify.Input( cell?.GetValue() )
                    ? cell
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _email = _employee?.GetEmail();

                return Verify.Input( _email?.GetValue() )
                    ? _email
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _status = _employee?.GetEmployementStatus();

                return Verify.Input( _status?.GetValue() )
                    ? _status
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
