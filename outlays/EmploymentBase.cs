// <copyright file = "EmploymentBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IEmploymentInfo"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class EmploymentBase : IEmploymentInfo
    {
        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        private protected IElement _employeeNumber;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        private protected IElement _firstName;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        private protected IElement _lastName;

        /// <summary>
        /// Gets or sets the human resource organization code.
        /// </summary>
        /// <value>
        /// The human resource organization code.
        /// </value>
        private protected IElement _humanResourceOrganizationCode;

        /// <summary>
        /// Gets or sets the name of the human resource organization.
        /// </summary>
        /// <value>
        /// The name of the human resource organization.
        /// </value>
        private protected IElement _humanResourceOrganizationName;

        /// <summary>
        /// Gets or sets the appointment authority.
        /// </summary>
        /// <value>
        /// The appointment authority.
        /// </value>
        private protected IElement _appointmentAuthority;

        /// <summary>
        /// Gets or sets the type of the appointment.
        /// </summary>
        /// <value>
        /// The type of the appointment.
        /// </value>
        private protected IElement _appointmentType;

        /// <summary>
        /// Gets or sets the bargaining unit.
        /// </summary>
        /// <value>
        /// The bargaining unit.
        /// </value>
        private protected IElement _bargainingUnit;

        /// <summary>
        /// Gets or sets the retirement plan.
        /// </summary>
        /// <value>
        /// The retirement plan.
        /// </value>
        private protected IElement _retirementPlan;

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        /// <value>
        /// The hire date.
        /// </value>
        private protected ITime _hireDate;

        /// <summary>
        /// Gets or sets the service date.
        /// </summary>
        /// <value>
        /// The service date.
        /// </value>
        private protected ITime _serviceDate;

        /// <summary>
        /// Gets or sets the grade entry date.
        /// </summary>
        /// <value>
        /// The grade entry date.
        /// </value>
        private protected ITime _gradeEntryDate;

        /// <summary>
        /// Gets or sets the step entry date.
        /// </summary>
        /// <value>
        /// The step entry date.
        /// </value>
        private protected ITime _stepEntryDate;

        /// <summary>
        /// Gets or sets the wigi due date.
        /// </summary>
        /// <value>
        /// The wigi due date.
        /// </value>
        private protected ITime _wigiDueDate;
        
        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmployeeNumber()
        {
            try
            {
                return Verify.Input( _employeeNumber.GetValue() )
                    ? _employeeNumber
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Input( _firstName.GetValue() )
                    ? _firstName
                    : default( IElement );
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
                return Verify.Input( _lastName.GetValue() )
                    ? _lastName
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the human resource organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetHrOrgCode()
        {
            try
            {
                return Verify.Input( _humanResourceOrganizationCode.GetValue() )
                    ? _humanResourceOrganizationCode
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the name of the human resource organization.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetHrOrgName()
        {
            try
            {
                return Verify.Input( _humanResourceOrganizationName.GetValue() )
                    ? _humanResourceOrganizationName
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the hire date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetHireDate()
        {
            try
            {
                return Verify.Input( _hireDate?.GetValue() )
                    ? _hireDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the service date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetServiceDate()
        {
            try
            {
                return Verify.Input( _serviceDate?.GetValue() )
                    ? _serviceDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the grade entry date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetGradeEntryDate()
        {
            try
            {
                return Verify.Input( _gradeEntryDate?.GetValue() )
                    ? _gradeEntryDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the step entry date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetStepEntryDate()
        {
            try
            {
                return Verify.Input( _stepEntryDate?.GetValue() )
                    ? _stepEntryDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the wigi due date.
        /// </summary>
        /// <returns>
        /// </returns>
        public ITime GetWigiDueDate()
        {
            try
            {
                return Verify.Input( _wigiDueDate?.GetValue() )
                    ? _wigiDueDate
                    : default( ITime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the appointment authority.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetAppointmentAuthority()
        {
            try
            {
                return Verify.Input( _appointmentAuthority.GetValue() )
                    ? _appointmentAuthority
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the type of the appointment.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetAppointmentType()
        {
            try
            {
                return Verify.Input( _appointmentType.GetValue() )
                    ? _appointmentType
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the bargaining unit.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetBargainingUnit()
        {
            try
            {
                return Verify.Input( _bargainingUnit.GetValue() )
                    ? _bargainingUnit
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the retirement plan.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetRetirementPlan()
        {
            try
            {
                return Verify.Input( _retirementPlan.GetValue() )
                    ? _retirementPlan
                    : default( IElement );
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
