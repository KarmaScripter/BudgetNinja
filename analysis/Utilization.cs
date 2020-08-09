// <copyright file="Utilization.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Utilization
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        public Utilization()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Utilization( IQuery query )
        {
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.UtilizationId );
            RPIO = Record[ $"{Field.RpioCode}" ].ToString();
            BFY = Record[ $"{Field.BFY}" ].ToString();
            FundCode = Record[ $"{Field.FundCode}" ].ToString();
            AhCode = Record[ $"{Field.AhCode}" ].ToString();
            OrgCode = Record[ $"{Field.OrgCode}" ].ToString();
            AccountCode = Record[ $"{Field.AccountCode}" ].ToString();
            RcCode = Record[ $"{Field.RcCode}" ].ToString();
            BocCode = Record[ $"{Field.BocCode}" ].ToString();
            Authority = new Amount( Record, Numeric.Authority );
            Budgeted = new Amount( Record, Numeric.Budgeted );
            Posted = new Amount( Record, Numeric.Posted );
            CarryIn = new Amount( Record, Numeric.CarryIn );
            CarryOut = new Amount( Record, Numeric.CarryOut );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Rate = new Amount( Record, Numeric.Rate );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        /// <param name = "databuilder" >
        /// The databuilder.
        /// </param>
        public Utilization( IDataAccess databuilder )
            : this()
        {
            Record = databuilder?.GetRecord();
            ID = new Key( Record, PrimaryKey.UtilizationId );
            RPIO = Record?[ $"{Field.RpioCode}" ].ToString();
            BFY = Record?[ $"{Field.BFY}" ].ToString();
            FundCode = Record?[ $"{Field.FundCode}" ].ToString();
            AhCode = Record?[ $"{Field.AhCode}" ].ToString();
            OrgCode = Record?[ $"{Field.OrgCode}" ].ToString();
            AccountCode = Record?[ $"{Field.AccountCode}" ].ToString();
            RcCode = Record?[ $"{Field.RcCode}" ].ToString();
            BocCode = Record?[ $"{Field.BocCode}" ].ToString();
            Authority = new Amount( Record, Numeric.Authority );
            Budgeted = new Amount( Record, Numeric.Budgeted );
            Posted = new Amount( Record, Numeric.Posted );
            CarryIn = new Amount( Record, Numeric.CarryIn );
            CarryOut = new Amount( Record, Numeric.CarryOut );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Rate = new Amount( Record, Numeric.Rate );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Utilization( DataRow data )
            : this()
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.UtilizationId );
            RPIO = Record[ $"{Field.RpioCode}" ].ToString();
            BFY = Record[ $"{Field.BFY}" ].ToString();
            FundCode = Record[ $"{Field.FundCode}" ].ToString();
            AhCode = Record[ $"{Field.AhCode}" ].ToString();
            OrgCode = Record[ $"{Field.OrgCode}" ].ToString();
            AccountCode = Record[ $"{Field.AccountCode}" ].ToString();
            RcCode = Record[ $"{Field.RcCode}" ].ToString();
            BocCode = Record[ $"{Field.BocCode}" ].ToString();
            Authority = new Amount( Record, Numeric.Authority );
            Budgeted = new Amount( Record, Numeric.Budgeted );
            Posted = new Amount( Record, Numeric.Posted );
            CarryIn = new Amount( Record, Numeric.CarryIn );
            CarryOut = new Amount( Record, Numeric.CarryOut );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Rate = new Amount( Record, Numeric.Rate );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected virtual Source Source { get; set; } = Source.Utilization;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> Args { get; }

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        public string RcCode { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private DataRow Record { get; }

        /// <summary>
        /// Gets or sets the outlays.
        /// </summary>
        /// <value>
        /// The outlays.
        /// </value>
        private IEnumerable<T> Outlays { get; set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        private protected IKey ID { get; }

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private string RPIO { get; }

        /// <summary>
        /// Gets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        private string AhCode { get; }

        /// <summary>
        /// Gets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        private string OrgCode { get; }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private string AccountCode { get; }

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private string BFY { get; }

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private string FundCode { get; }

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        private string ProgramProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private string ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        private string BocCode { get; }

        /// <summary>
        /// Gets or sets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        private string FocCode { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        private IAmount Balance { get; set; }

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        private IAmount Authority { get; }

        /// <summary>
        /// Gets the budgeted.
        /// </summary>
        /// <value>
        /// The budgeted.
        /// </value>
        private IAmount Budgeted { get; }

        /// <summary>
        /// Gets the posted.
        /// </summary>
        /// <value>
        /// The posted.
        /// </value>
        private IAmount Posted { get; }

        /// <summary>
        /// Gets the carry in.
        /// </summary>
        /// <value>
        /// The carry in.
        /// </value>
        private IAmount CarryIn { get; }

        /// <summary>
        /// Gets the carry out.
        /// </summary>
        /// <value>
        /// The carry out.
        /// </value>
        private IAmount CarryOut { get; }

        /// <summary>
        /// Gets the commitments.
        /// </summary>
        /// <value>
        /// The commitments.
        /// </value>
        private IAmount Commitments { get; }

        /// <summary>
        /// Gets the open commitments.
        /// </summary>
        /// <value>
        /// The open commitments.
        /// </value>
        private IAmount OpenCommitments { get; }

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <value>
        /// The obligations.
        /// </value>
        private IAmount Obligations { get; }

        /// <summary>
        /// Gets the ulo.
        /// </summary>
        /// <value>
        /// The ulo.
        /// </value>
        private IAmount ULO { get; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        private IAmount Rate { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Rate.GetFunding() > -1.0
                    ? Rate.GetFunding().ToString( "P" )
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs()
        {
            if( Record != null )
            {
                try
                {
                    return Record.ToDictionary().Any()
                        ? Record.ToDictionary()
                        : default;
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
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
