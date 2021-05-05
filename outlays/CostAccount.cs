// <copyright file = "CostAccount.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// </summary>
    /// <seealso cref = "Cost"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class CostAccount : Cost, ICostAccount
    {
        // ***************************************************************************************************************************
        // ****************************************************    FIELDS     ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The PRC
        /// </summary>
        private protected readonly IProgramResultsCode PRC;

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "CostAccount"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public CostAccount( DataRow data )
        {
            Record = data;
            PRC = new ProgramResultsCode( data );
            ID = new Key( Record, PrimaryKey.PrcId );
            NpmCode = new Element( Record, Field.NpmCode );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            FocCode = new Element( Record, Field.FocCode );
            FocName = new Element( Record, Field.FocName );
            DocumentType = new Element( Record, Field.DocumentType );
            DocumentPrefix = new Element( Record, Field.DocumentPrefix );
            DCN = new Element( Record, Field.DocumentType );
            OriginalActionDate = new Time( Record, EventDate.OriginalActionDate );
            ObligatingDocumentNumber = new Element( Record, Field.ObligatingDocumentNumber );
            System = new Element( Record, Field.System );
            TransactionNumber = new Element( Record, Field.TransactionNumber );
            GrantNumber = new Element( Record, Field.GrantNumber );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            ULO = new Amount( Record, Numeric.ULO );
            Balance = new Amount( Record, Numeric.Balance );
            Data = Record?.ToDictionary();
        }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the finance object class.
        /// </summary>
        /// <returns>
        /// </returns>
        public IFinanceObjectClass GetFinanceObjectClass()
        {
            try
            {
                var code = FocCode?.GetValue();

                return Verify.Input( code )
                    ? new FinanceObjectClass( code )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the national program.
        /// </summary>
        /// <returns>
        /// </returns>
        public INationalProgram GetNationalProgram()
        {
            try
            {
                return Verify.Input( NpmCode?.GetValue() )
                    ? new NationalProgram( NpmCode?.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the program results code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramResultsCode GetProgramResultsCode()
        {
            try
            {
                return PRC?.GetAmount()?.GetFunding() > 0.0
                    ? PRC
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the program project.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramProject GetProgramProject()
        {
            try
            {
                return Verify.Input( ProgramProjectCode?.GetValue() )
                    ? new ProgramProject( ProgramProjectCode?.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the program area.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramArea GetProgramArea()
        {
            try
            {
                return Verify.Input( ProgramAreaCode?.GetValue() )
                    ? new ProgramArea( ProgramAreaCode?.GetValue() )
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
