// <copyright file = "EmploymentBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IEmploymentInfo"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class EmploymentBase : IEmploymentInfo
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        private protected IElement EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        private protected IElement FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        private protected IElement LastName { get; set; }

        /// <summary>
        /// Gets or sets the human resource organization code.
        /// </summary>
        /// <value>
        /// The human resource organization code.
        /// </value>
        private protected IElement HumanResourceOrganizationCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the human resource organization.
        /// </summary>
        /// <value>
        /// The name of the human resource organization.
        /// </value>
        private protected IElement HumanResourceOrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the appointment authority.
        /// </summary>
        /// <value>
        /// The appointment authority.
        /// </value>
        private protected IElement AppointmentAuthority { get; set; }

        /// <summary>
        /// Gets or sets the type of the appointment.
        /// </summary>
        /// <value>
        /// The type of the appointment.
        /// </value>
        private protected IElement AppointmentType { get; set; }

        /// <summary>
        /// Gets or sets the bargaining unit.
        /// </summary>
        /// <value>
        /// The bargaining unit.
        /// </value>
        private protected IElement BargainingUnit { get; set; }

        /// <summary>
        /// Gets or sets the retirement plan.
        /// </summary>
        /// <value>
        /// The retirement plan.
        /// </value>
        private protected IElement RetirementPlan { get; set; }

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        /// <value>
        /// The hire date.
        /// </value>
        private protected ITime HireDate { get; set; }

        /// <summary>
        /// Gets or sets the service date.
        /// </summary>
        /// <value>
        /// The service date.
        /// </value>
        private protected ITime ServiceDate { get; set; }

        /// <summary>
        /// Gets or sets the grade entry date.
        /// </summary>
        /// <value>
        /// The grade entry date.
        /// </value>
        private protected ITime GradeEntryDate { get; set; }

        /// <summary>
        /// Gets or sets the step entry date.
        /// </summary>
        /// <value>
        /// The step entry date.
        /// </value>
        private protected ITime StepEntryDate { get; set; }

        /// <summary>
        /// Gets or sets the wigi due date.
        /// </summary>
        /// <value>
        /// The wigi due date.
        /// </value>
        private protected ITime WigiDueDate { get; set; }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetEmployeeNumber()
        {
            try
            {
                return Verify.Input( EmployeeNumber.GetValue() )
                    ? EmployeeNumber
                    : default;
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
                return Verify.Input( FirstName.GetValue() )
                    ? FirstName
                    : default;
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
                return Verify.Input( LastName.GetValue() )
                    ? LastName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( HumanResourceOrganizationCode.GetValue() )
                    ? HumanResourceOrganizationCode
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( HumanResourceOrganizationName.GetValue() )
                    ? HumanResourceOrganizationName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( HireDate?.GetValue() )
                    ? HireDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( ServiceDate?.GetValue() )
                    ? ServiceDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( GradeEntryDate?.GetValue() )
                    ? GradeEntryDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( StepEntryDate?.GetValue() )
                    ? StepEntryDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( WigiDueDate?.GetValue() )
                    ? WigiDueDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( AppointmentAuthority.GetValue() )
                    ? AppointmentAuthority
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( AppointmentType.GetValue() )
                    ? AppointmentType
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( BargainingUnit.GetValue() )
                    ? BargainingUnit
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( RetirementPlan.GetValue() )
                    ? RetirementPlan
                    : default;
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
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
