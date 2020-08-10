// // <copyright file = "BenefitFactory.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "LeaveBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class BenefitFactory : LeaveBase
    {
        // ***************************************************************************************************************************
        // *********************************************    FIELDS      **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The vacation
        /// </summary>
        private readonly ILeave Vacation;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "BenefitFactory"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public BenefitFactory( IQuery query )
        {
            Vacation = new Leave( query );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BenefitFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public BenefitFactory( IBuilder builder )
        {
            Vacation = new Leave( builder );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BenefitFactory"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public BenefitFactory( DataRow datarow )
        {
            Vacation = new Leave( datarow );
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The GetProjectedPayPeriod.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetProjectedPayPeriod()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetProjectedPayPeriod()
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// The GetProjectedAnnual.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetProjectedAnnual()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetProjectedAnnual()
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// The GetAnnualHours.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetAnnualHours()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetAnnualHours()
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// The GetHumanResourceOrganization.
        /// </summary>
        /// <returns>
        /// The <see cref = "IHumanResourceOrganization"/> .
        /// </returns>
        public IHumanResourceOrganization GetHumanResourceOrganization()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetHumanResourceOrganization()
                    : default( HumanResourceOrganization );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( HumanResourceOrganization );
            }
        }

        /// <summary>
        /// The GetWorkCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "IWorkCode"/> .
        /// </returns>
        public IWorkCode GetWorkCode()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetWorkCode()
                    : default( WorkCode );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( WorkCode );
            }
        }

        /// <summary>
        /// The GetResourcePlanningOfficeCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "string"/> .
        /// </returns>
        public IElement GetRpioCode()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetRpioCode()
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// The GetResourcePlanningOffice.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IResourcePlanningOffice GetResourcePlanningOffice()
        {
            try
            {
                return Verify.Ref( Vacation )
                    ? Vacation.GetResourcePlanningOffice()
                    : default( ResourcePlanningOffice );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ResourcePlanningOffice );
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public new IDictionary<string, object> ToDictionary()
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
    }
}
