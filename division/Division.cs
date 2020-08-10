// // <copyright file = "Division.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

// ReSharper disable All

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

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
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.DivisionId );
            Title = new Element( Record, Field.Title );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            Caption = new Element( Record, Field.Caption );
            Args = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name?.GetValue() );
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
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.DivisionId );
            Title = new Element( Record, Field.Title );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            Caption = new Element( Record, Field.Caption );
            Args = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name?.GetValue() );
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
            Record = new DataBuilder( Source, GetArgs( rc ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.DivisionId );
            Title = new Element( Record, Field.Title );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            Caption = new Element( Record, Field.Caption );
            Args = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name?.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Division( DataRow data )
            : this()
        {
            Record = data;
            ID = new Key( Record, PrimaryKey.DivisionId );
            Title = new Element( Record, Field.Title );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            Caption = new Element( Record, Field.Caption );
            Args = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name?.GetValue() );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Division"/> class.
        /// </summary>
        /// <param name = "rccode" >
        /// The rccode.
        /// </param>
        public Division( string rccode )
            : this()
        {
            Record = new DataBuilder( Source, GetArgs( rccode ) )?.GetRecord();
            ID = new Key( Record, PrimaryKey.DivisionId );
            Title = new Element( Record, Field.Title );
            Code = new Element( Record, Field.Code );
            Name = new Element( Record, Field.Name );
            Caption = new Element( Record, Field.Caption );
            Args = Record?.ToDictionary();
            RC = (RC)Enum.Parse( typeof( RC ), Name?.GetValue() );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the rc.
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        public RC RC { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the responsibility center.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResponsibilityCenter GetResponsibilityCenter()
        {
            try
            {
                var dict = new Dictionary<string, object>
                {
                    [ $"{Field.Code}" ] = Code
                };

                var connectbuilder = new ConnectionBuilder( Source.ResponsibilityCenters, Provider.SQLite );
                var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                using var query = new Query( connectbuilder, sqlstatement );
                return new ResponsibilityCenter( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the control number data.
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
                    if( !Args?.ContainsKey( Field.BFY.ToString() ) == true )
                    {
                        Args?.Add( Field.BFY.ToString(), bfy?.GetFirstYear() );
                    }

                    var data = new Builder( Source.ControlNumbers, Args )?.GetData();

                    if( Verify.Rows( data ) )
                    {
                        var controlnumber = data?.Select( dr => new ControlNumber( dr ) );

                        return controlnumber?.Any() == true
                            ? controlnumber
                            : default;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the work code data.
        /// </summary>
        /// <param name = "bfy" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<IWorkCode> GetWorkCodes( IBudgetFiscalYear bfy )
        {
            if( bfy != null
                && Verify.Input( Code?.GetValue() )
                && Resource.DivisionSources?.Contains( Source ) == true )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.RcCode}" ] = Code,
                        [ $"{Field.BFY}" ] = bfy.GetFirstYear()
                    };

                    var workcodedata = new Builder( Source.WorkCodes, args )?.GetData();
                    var workcodes = workcodedata?.Select( r => new WorkCode( r ) );

                    return workcodes?.Any() == true
                        ? workcodes.ToList()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the hr org code data.
        /// </summary>
        /// <param name = "bfy" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<IHumanResourceOrganization> GetHumanResourceOrganizations( IBudgetFiscalYear bfy )
        {
            if( bfy != null
                && Verify.Input( Code?.GetValue() )
                && Resource.DivisionSources?.Contains( Source ) == true )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.RcCode}" ] = Code?.GetValue()
                    };

                    var data = new DataBuilder( Source.HumanResourceOrganizations, args )?.GetData();

                    var hrorg = data?.Select( r => new HumanResourceOrganization( r ) );

                    return hrorg?.Any() == true
                        ? hrorg
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
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
                    return default;
                }
            }

            return default;
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
            var code = rc?.GetCode()?.GetValue();

            if( Verify.Input( code )
                && code.StartsWith( "06", StringComparison.Ordinal ) == true )
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
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Input( Code.GetValue() ) )
            {
                try
                {
                    return Code.GetValue();
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
