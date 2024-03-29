﻿// <copyright file = "Expenditure.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The United States federal budget consists of mandatory expenditures (which
    /// includes Medicare and Social Security), discretionary spending for defense,
    /// Cabinet departments (e.g., Justice Department) and agencies (e.g., Securities &
    /// Exchange Commission), and interest payments on debt. This is currently over
    /// half of U.S. government spending, the remainder coming from state and local
    /// governments.
    /// </summary>
    public class Expenditure : Obligation
    {
        /// <summary>
        /// Gets or sets the Source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public new Source Source { get; } =  Source.Expenditures;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Expenditure"/> class.
        /// </summary>
        public Expenditure()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Expenditure"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query<see cref = "IQuery"/>.
        /// </param>
        public Expenditure( IQuery query )
            : base( query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ExpenditureId );
            OriginalActionDate = GetOriginalActionDate();
            Expenditures = GetExpenditures();
            Data = Record?.ToDictionary();
            Type = OutlayType.Expenditure;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Expenditure"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Expenditure( IBuilder builder )
            : base( builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.ExpenditureId );
            OriginalActionDate = GetOriginalActionDate();
            Expenditures = GetExpenditures();
            Data = Record?.ToDictionary();
            Type = OutlayType.Expenditure;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Expenditure"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow<see cref = "DataRow"/>.
        /// </param>
        public Expenditure( DataRow dataRow )
            : base( dataRow )
        {
            Record = dataRow;
            ID = new Key( Record, PrimaryKey.ExpenditureId );
            OriginalActionDate = GetOriginalActionDate();
            Expenditures = GetExpenditures();
            Data = Record?.ToDictionary();
            Type = OutlayType.Expenditure;
        }
        
        /// <summary>
        /// Gets the outlay identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// The GetExpenditureAmount.
        /// </summary>
        /// <returns>
        /// The <see cref = "double"/>.
        /// </returns>
        public override IAmount GetAmount()
        {
            try
            {
                return Expenditures?.GetFunding() > -1
                    ? Expenditures
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Data )
                    ?  Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}
