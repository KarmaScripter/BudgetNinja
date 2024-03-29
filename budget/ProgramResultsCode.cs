﻿// <copyright file = "ProgramResultsCode.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Program Results Codes (PRCs) were established to account for and relate
    /// resources to the Agency's Strategic Plan goals and objectives, national program
    /// offices and responsibilities, and governmental functions. PRCs are created when
    /// the annual EPA Budget is submitted to Congress each February and then formally
    /// established in IFMS with the enactment of EPA's appropriation act. PRCs may be
    /// updated at any time.
    /// </summary>
    /// <seealso cref = "PrcConfig"/>
    /// <seealso cref = "IProgramResultsCode"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IProgramResultsCode"/>
    /// <seealso cref = "IFund"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class ProgramResultsCode : PrcConfig, IProgramResultsCode
    {
        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; } = Source.Allocations;

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public IAmount Amount { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets or sets the Data elements.
        /// </summary>
        /// <value>
        /// The Data elements.
        /// </value>
        public IEnumerable<IElement> Elements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        public ProgramResultsCode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public ProgramResultsCode( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PrcId );
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Elements = GetElements();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public ProgramResultsCode( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.PrcId );
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Elements = GetElements();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public ProgramResultsCode( DataRow dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.PrcId );
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Elements = GetElements();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "dict" >
        /// </param>
        public ProgramResultsCode( IDictionary<string, object> dict )
        {
            Record = new DataBuilder( Source, dict )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PrcId );
            BudgetLevel = new Element( Record, Field.BudgetLevel );
            BFY = new Element( Record, Field.BFY );
            RpioCode = new Element( Record, Field.RpioCode );
            AhCode = new Element( Record, Field.AhCode );
            FundCode = new Element( Record, Field.FundCode );
            OrgCode = new Element( Record, Field.OrgCode );
            RcCode = new Element( Record, Field.RcCode );
            BocCode = new Element( Record, Field.BocCode );
            AccountCode = new Element( Record, Field.AccountCode );
            ActivityCode = new Element( Record, Field.ActivityCode );
            Amount = new Amount( Record, Numeric.Amount );
            Data = Record?.ToDictionary();
            Elements = GetElements();
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
                var account = GetAccount();

                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = account?.GetProgramProject()?.GetCode()
                };

                var connectbuilder = new ConnectionBuilder( Source.ProgramProjects, Provider.SQLite );
                var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                using var query = new Query( connectbuilder, sqlstatement );
                return new ProgramProject( query ) ?? default( ProgramProject );
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
                return Verify.Input( GetAccount().ToString() )
                    ? GetAccount().GetProgramArea()
                    : default( IProgramArea );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramArea );
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
                return MemberwiseClone() as ProgramResultsCode;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramResultsCode );
            }
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
                return Verify.Input( AccountCode.GetValue() )
                    ? AccountCode.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<IElement> GetElements()
        {
            try
            {
                var elements = new List<IElement>
                {
                    BudgetLevel,
                    BFY,
                    RpioCode,
                    FundCode,
                    AhCode,
                    OrgCode,
                    AccountCode,
                    BocCode,
                    RcCode,
                    ActivityCode
                };

                return elements?.Any() == true
                    ? elements
                    : default( List<IElement> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<IElement> );
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IAmount GetAmount()
        {
            try
            {
                return Amount?.GetFunding() > -1
                    ? Amount
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( Source )
                    ? Source
                    : default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }
    }
}
