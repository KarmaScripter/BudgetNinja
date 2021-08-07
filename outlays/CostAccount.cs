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
        /// <summary>
        /// The PRC
        /// </summary>
        private protected readonly IProgramResultsCode _prc;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "CostAccount"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public CostAccount( DataRow data )
        {
            _records = data;
            _prc = new ProgramResultsCode( data );
            _id = new Key( _records, PrimaryKey.PrcId );
            _npmCode = new Element( _records, Field.NpmCode );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _programAreaCode = new Element( _records, Field.ProgramAreaCode );
            _focCode = new Element( _records, Field.FocCode );
            _focName = new Element( _records, Field.FocName );
            _documentType = new Element( _records, Field.DocumentType );
            _documentPrefix = new Element( _records, Field.DocumentPrefix );
            _dcn = new Element( _records, Field.DocumentType );
            OriginalActionDate = new Time( _records, EventDate.OriginalActionDate );
            _obligatingDocumentNumber = new Element( _records, Field.ObligatingDocumentNumber );
            _system = new Element( _records, Field.System );
            _transactionNumber = new Element( _records, Field.TransactionNumber );
            _grantNumber = new Element( _records, Field.GrantNumber );
            Commitments = new Amount( _records, Numeric.Commitments );
            OpenCommitments = new Amount( _records, Numeric.OpenCommitments );
            Obligations = new Amount( _records, Numeric.Obligations );
            Deobligations = new Amount( _records, Numeric.Deobligations );
            ULO = new Amount( _records, Numeric.ULO );
            Balance = new Amount( _records, Numeric.Balance );
            _data = _records?.ToDictionary();
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
                var code = _focCode?.GetValue();

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
                return Verify.Input( _npmCode?.GetValue() )
                    ? new NationalProgram( _npmCode?.GetValue() )
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
                return Verify.Input( _programProjectCode?.GetValue() )
                    ? new ProgramProject( _programProjectCode?.GetValue() )
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
                return Verify.Input( _programAreaCode?.GetValue() )
                    ? new ProgramArea( _programAreaCode?.GetValue() )
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
