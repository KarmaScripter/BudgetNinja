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
        private protected readonly IProgramResultsCode _prc;

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
            _record = data;
            _prc = new ProgramResultsCode( data );
            _id = new Key( _record, PrimaryKey.PrcId );
            NpmCode = new Element( _record, Field.NpmCode );
            ProgramProjectCode = new Element( _record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( _record, Field.ProgramAreaCode );
            FocCode = new Element( _record, Field.FocCode );
            FocName = new Element( _record, Field.FocName );
            DocumentType = new Element( _record, Field.DocumentType );
            DocumentPrefix = new Element( _record, Field.DocumentPrefix );
            DCN = new Element( _record, Field.DocumentType );
            OriginalActionDate = new Time( _record, EventDate.OriginalActionDate );
            ObligatingDocumentNumber = new Element( _record, Field.ObligatingDocumentNumber );
            System = new Element( _record, Field.System );
            TransactionNumber = new Element( _record, Field.TransactionNumber );
            GrantNumber = new Element( _record, Field.GrantNumber );
            Commitments = new Amount( _record, Numeric.Commitments );
            OpenCommitments = new Amount( _record, Numeric.OpenCommitments );
            Obligations = new Amount( _record, Numeric.Obligations );
            Deobligations = new Amount( _record, Numeric.Deobligations );
            ULO = new Amount( _record, Numeric.ULO );
            Balance = new Amount( _record, Numeric.Balance );
            Data = _record?.ToDictionary();
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
                return Verify.Key( _id )
                    ? _id
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
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
                    : default( FinanceObjectClass );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IFinanceObjectClass );
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
                    : default( NationalProgram );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( INationalProgram );
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
                return _prc?.GetAmount()?.GetFunding() > 0.0
                    ? _prc
                    : default( IProgramResultsCode );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramResultsCode );
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
                    : default( ProgramProject );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramProject );
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
                    : default( ProgramArea );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramArea );
            }
        }
    }
}
