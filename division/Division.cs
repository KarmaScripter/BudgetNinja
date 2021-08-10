// <copyright file = "Division.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

// ReSharper disable All

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "DivisionBase"/>
    /// <seealso cref = "IDivision"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "ISource"/>
    public class Division : DivisionBase, IDivision, ISource
    {
        /// <summary>
        /// Gets or sets the rc.
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        public RC RC;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        public Division()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Division( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.DivisionId );
            _title = new Element( _record, Field.Title );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _caption = new Element( _record, Field.Caption );
            _args = _record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), _name?.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Division( IBuilder builder )
            : this()
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.DivisionId );
            _title = new Element( _record, Field.Title );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _caption = new Element( _record, Field.Caption );
            _args = _record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), _name?.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "rc" >
        /// The rc.
        /// </param>
        public Division( IResponsibilityCenter rc )
            : this()
        {
            _record = new DataBuilder( _source, GetArgs( rc ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.DivisionId );
            _title = new Element( _record, Field.Title );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _caption = new Element( _record, Field.Caption );
            _args = _record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), _name?.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public Division( DataRow dataRow )
            : this()
        {
            _record = dataRow;
            _id = new Key( _record, PrimaryKey.DivisionId );
            _title = new Element( _record, Field.Title );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _caption = new Element( _record, Field.Caption );
            _args = _record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), _name?.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "rcCode" >
        /// The rcCode.
        /// </param>
        public Division( string rcCode )
            : this()
        {
            _record = new DataBuilder( _source, GetArgs( rcCode ) )?.GetRecord();
            _id = new Key( _record, PrimaryKey.DivisionId );
            _title = new Element( _record, Field.Title );
            _code = new Element( _record, Field.Code );
            _name = new Element( _record, Field.Name );
            _caption = new Element( _record, Field.Caption );
            _args = _record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), _name?.GetValue() );
        }

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResponsibilityCenter GetResponsibilityCenter()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = _code
                };

                var _connectionBuilder = new ConnectionBuilder( Source.ResponsibilityCenters, Provider.SQLite );
                var _sqlStatement = new SqlStatement( _connectionBuilder, _dictionary, SQL.SELECT );
                using var _query = new Query( _connectionBuilder, _sqlStatement );
                return new ResponsibilityCenter( _query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IResponsibilityCenter );
            }
        }

        /// <summary>
        /// Gets the control number dataRow.
        /// </summary>
        /// <param name = "bfy" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<IControlNumber> GetBudgetControlNumbers( IBudgetFiscalYear bfy )
        {
            if( bfy != null )
            {
                try
                {
                    if( !_args?.ContainsKey( Field.BFY.ToString() ) == true )
                    {
                        _args?.Add( Field.BFY.ToString(), bfy?.GetFirstYear() );
                    }

                    var _enumerable = new Builder( Source.ControlNumbers, _args )
                        ?.GetData();

                    if( Verify.Rows( _enumerable ) )
                    {
                        var _select = _enumerable
                            ?.Select( dr => new ControlNumber( dr ) );

                        return _select?.Any() == true
                            ? _select
                            : default( IEnumerable<ControlNumber> );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<IControlNumber> );
                }
            }

            return default( IEnumerable<IControlNumber> );
        }

        /// <summary>
        /// Gets the work code dataRow.
        /// </summary>
        /// <param name = "bfy" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<IWorkCode> GetWorkCodes( IBudgetFiscalYear bfy )
        {
            if( bfy != null
                && Verify.Input( _code?.GetValue() )
                && Resource.DivisionSources?.Contains( _source ) == true )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.RcCode}" ] = _code,
                        [ $"{Field.BFY}" ] = bfy.GetFirstYear()
                    };

                    var _enumerable = new Builder( Source.WorkCodes, _dictionary )
                        ?.GetData();

                    var _select = _enumerable
                        ?.Select( r => new WorkCode( r ) );

                    return _select?.Any() == true
                        ? _select.ToList()
                        : default( List<WorkCode> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<IWorkCode> );
                }
            }

            return default( IEnumerable<IWorkCode> );
        }

        /// <summary>
        /// Gets the hr org code dataRow.
        /// </summary>
        /// <param name = "bfy" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<IHumanResourceOrganization> GetHumanResourceOrganizations( IBudgetFiscalYear bfy )
        {
            if( bfy != null
                && Verify.Input( _code?.GetValue() )
                && Resource.DivisionSources?.Contains( _source ) == true )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.RcCode}" ] = _code?.GetValue()
                    };

                    var _enumerable = new DataBuilder( Source.HumanResourceOrganizations, _dictionary )
                        ?.GetData();

                    var _select = _enumerable
                        ?.Select( r => new HumanResourceOrganization( r ) );

                    return _select?.Any() == true
                        ? _select
                        : default( IEnumerable<HumanResourceOrganization> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<IHumanResourceOrganization> );
                }
            }

            return default( IEnumerable<IHumanResourceOrganization> );
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( string code )
        {
            if( Verify.Input( code ) )
            {
                try
                {
                    if( code.StartsWith( "06" ) )
                    {
                        return new Dictionary<string, object>
                        {
                            [ $"{Field.Code}" ] = code
                        };
                    }
                    else if( code.StartsWith( "6" ) )
                    {
                        return new Dictionary<string, object>
                        {
                            [ $"{Field.Caption}" ] = code
                        };
                    }
                    else if( !code.StartsWith( "6" )
                        && !code.StartsWith( "06" ) )
                    {
                        return new Dictionary<string, object>
                        {
                            [ $"{Field.Name}" ] = code
                        };
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "rc" >
        /// The rc.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( IResponsibilityCenter rc )
        {
            var _value = rc?.GetCode()?.GetValue();

            if( Verify.Input( _value )
                && _value.StartsWith( "06", StringComparison.Ordinal ) == true )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ $"{Field.Code}" ] = rc?.GetCode()
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Input( _code.GetValue() ) )
            {
                try
                {
                    return _code.GetValue();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }
    }
}
