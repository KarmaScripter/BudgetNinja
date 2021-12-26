// <copyright file = "Utilization.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Utilization
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; } = Source.Utilization;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Args { get;  }

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        public string RcCode { get;  }

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get;  }

        /// <summary>
        /// Gets or sets the outlays.
        /// </summary>
        /// <value>
        /// The outlays.
        /// </value>
        public IEnumerable<T> Obligations { get; set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public IKey ID { get;  }

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private string RpioCode { get;  }

        /// <summary>
        /// Gets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        public string AhCode { get;  }

        /// <summary>
        /// Gets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        public string OrgCode { get;  }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public string AccoutCode { get;  }

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public string BFY { get;  }

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        public string FundCode { get;  }

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        public string ProgramProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        public string ProgramAreaCode { get; set; }

        /// <summary>
        /// Gets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        public string BocCode { get;  }

        /// <summary>
        /// Gets or sets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        public string FocCode { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public IAmount Balance { get; set; }

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        public IAmount Authority { get; set; }

        /// <summary>
        /// Gets the budgeted.
        /// </summary>
        /// <value>
        /// The budgeted.
        /// </value>
        public IAmount Budgeted { get; set; }

        /// <summary>
        /// Gets the posted.
        /// </summary>
        /// <value>
        /// The posted.
        /// </value>
        public IAmount Posted { get; set; }

        /// <summary>
        /// Gets the carry in.
        /// </summary>
        /// <value>
        /// The carry in.
        /// </value>
        public IAmount CarryIn { get; set; }

        /// <summary>
        /// Gets the carry out.
        /// </summary>
        /// <value>
        /// The carry out.
        /// </value>
        public IAmount CarryOut { get; set; }

        /// <summary>
        /// Gets the commitments.
        /// </summary>
        /// <value>
        /// The commitments.
        /// </value>
        public IAmount Commitments { get; set; }

        /// <summary>
        /// Gets the open commitments.
        /// </summary>
        /// <value>
        /// The open commitments.
        /// </value>
        public IAmount OpenCommitments { get; set; }

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <value>
        /// The obligations.
        /// </value>
        public IAmount Deobligations { get; set; }

        /// <summary>
        /// Gets the ulo.
        /// </summary>
        /// <value>
        /// The ulo.
        /// </value>
        public IAmount ULO { get; set; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public IAmount Rate { get; set; }
        
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
            RpioCode = Record[ $"{Field.RpioCode}" ].ToString();
            BFY = Record[ $"{Field.BFY}" ].ToString();
            FundCode = Record[ $"{Field.FundCode}" ].ToString();
            AhCode = Record[ $"{Field.AhCode}" ].ToString();
            OrgCode = Record[ $"{Field.OrgCode}" ].ToString();
            AccoutCode = Record[ $"{Field.AccountCode}" ].ToString();
            RcCode = Record[ $"{Field.RcCode}" ].ToString();
            BocCode = Record[ $"{Field.BocCode}" ].ToString();
            Authority = new Amount( Record, Numeric.Authority );
            Budgeted = new Amount( Record, Numeric.Budgeted );
            Posted = new Amount( Record, Numeric.Posted );
            CarryIn = new Amount( Record, Numeric.CarryIn );
            CarryOut = new Amount( Record, Numeric.CarryOut );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Deobligations = new Amount( Record, Numeric.Obligations );
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
            RpioCode = Record?[ $"{Field.RpioCode}" ].ToString();
            BFY = Record?[ $"{Field.BFY}" ].ToString();
            FundCode = Record?[ $"{Field.FundCode}" ].ToString();
            AhCode = Record?[ $"{Field.AhCode}" ].ToString();
            OrgCode = Record?[ $"{Field.OrgCode}" ].ToString();
            AccoutCode = Record?[ $"{Field.AccountCode}" ].ToString();
            RcCode = Record?[ $"{Field.RcCode}" ].ToString();
            BocCode = Record?[ $"{Field.BocCode}" ].ToString();
            Authority = new Amount( Record, Numeric.Authority );
            Budgeted = new Amount( Record, Numeric.Budgeted );
            Posted = new Amount( Record, Numeric.Posted );
            CarryIn = new Amount( Record, Numeric.CarryIn );
            CarryOut = new Amount( Record, Numeric.CarryOut );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Deobligations = new Amount( Record, Numeric.Obligations );
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
            RpioCode = Record[ $"{Field.RpioCode}" ].ToString();
            BFY = Record[ $"{Field.BFY}" ].ToString();
            FundCode = Record[ $"{Field.FundCode}" ].ToString();
            AhCode = Record[ $"{Field.AhCode}" ].ToString();
            OrgCode = Record[ $"{Field.OrgCode}" ].ToString();
            AccoutCode = Record[ $"{Field.AccountCode}" ].ToString();
            RcCode = Record[ $"{Field.RcCode}" ].ToString();
            BocCode = Record[ $"{Field.BocCode}" ].ToString();
            Authority = new Amount( Record, Numeric.Authority );
            Budgeted = new Amount( Record, Numeric.Budgeted );
            Posted = new Amount( Record, Numeric.Posted );
            CarryIn = new Amount( Record, Numeric.CarryIn );
            CarryOut = new Amount( Record, Numeric.CarryOut );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Deobligations = new Amount( Record, Numeric.Obligations );
            ULO = new Amount( Record, Numeric.ULO );
            Rate = new Amount( Record, Numeric.Rate );
        }
        
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
                        : default( IDictionary<string, object> );
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
