// <copyright file = "ProgramResultsCode.cs" company = "Terry D. Eppler">
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
        private protected  new Source _source = Source.PRC;

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        private protected IAmount _amount;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> _data;

        /// <summary>
        /// Gets or sets the data elements.
        /// </summary>
        /// <value>
        /// The data elements.
        /// </value>
        private protected IEnumerable<IElement> _elements;

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
            : base( query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _amount = new Amount( _record, Numeric.Amount );
            _data = _record?.ToDictionary();
            _elements = GetElements();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public ProgramResultsCode( IBuilder builder )
            : base( builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _amount = new Amount( _record, Numeric.Amount );
            _data = _record?.ToDictionary();
            _elements = GetElements();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public ProgramResultsCode( DataRow dataRow )
            : base( dataRow )
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _amount = new Amount( _record, Numeric.Amount );
            _data = _record?.ToDictionary();
            _elements = GetElements();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ProgramResultsCode"/> class.
        /// </summary>
        /// <param name = "dict" >
        /// </param>
        public ProgramResultsCode( IDictionary<string, object> dict )
            : base( dict )
        {
            _record = new DataBuilder( _source, dict )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PrcId );
            _level = new Element( _record, Field.BudgetLevel );
            _bfy = new Element( _record, Field.BFY );
            _rpioCode = new Element( _record, Field.RpioCode );
            _ahCode = new Element( _record, Field.AhCode );
            _fundCode = new Element( _record, Field.FundCode );
            _orgCode = new Element( _record, Field.OrgCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bocCode = new Element( _record, Field.BocCode );
            _accountCode = new Element( _record, Field.AccountCode );
            _activityCode = new Element( _record, Field.ActivityCode );
            _amount = new Amount( _record, Numeric.Amount );
            _data = _record?.ToDictionary();
            _elements = GetElements();
        }
        
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
        /// Gets the name of the PRC.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetPrcName()
        {
            try
            {
                var name = ( (IProgramElement)this ).GetName();

                return Verify.Input( name.GetValue() )
                    ? name.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <returns>
        /// </returns>
        public IActivity GetActivity()
        {
            try
            {
                var account = GetAccount();
                return account?.GetActivity();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IActivity );
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
                return Verify.Input( _accountCode.GetValue() )
                    ? _accountCode.GetValue()
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
                    _level,
                    _bfy,
                    _rpioCode,
                    _fundCode,
                    _ahCode,
                    _orgCode,
                    _accountCode,
                    _bocCode,
                    _rcCode,
                    _activityCode
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
                return Verify.Map( _data )
                    ? _data
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
                return _amount?.GetFunding() > -1
                    ? _amount
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }
    }
}
