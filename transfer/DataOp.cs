// // <copyright file = "DataOp.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    public class DataOp : DataAccess
    {
        // ***************************************************************************************************************************
        // ******************************************************  CONSTRUCTORS  *****************************************************
        // ***************************************************************************************************************************

        public DataOp()
        {
        }

        public DataOp( Source source, Provider provider, SQL commandtype,
            IDictionary<string, object> dict )
        {
            ConnectionBuilder = new ConnectionBuilder( source, provider );
            SqlStatement = new SqlStatement( ConnectionBuilder, dict, commandtype );
        }

        public DataOp( IConnectionBuilder connectionmanager, ISqlStatement sqlstatement )
        {
            ConnectionBuilder = connectionmanager;
            SqlStatement = sqlstatement;
        }

        // ***************************************************************************************************************************
        // *******************************************************      METHODS        ***********************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Sets the type of the command.
        /// </summary>
        /// <returns>
        /// </returns>
        public SQL GetCommandType()
        {
            try
            {
                var commandtype = SqlStatement.GetCommandType();

                return Enum.IsDefined( typeof( SQL ), commandtype )
                    ? commandtype
                    : default;
            }
            catch( Exception ex )
            {
                DataOp.Fail( ex );

                return default;
            }
        }

        // ***************************************************************************************************************************
        // ****************************************************   EVENTS/DELEGATES  **************************************************
        // ***************************************************************************************************************************
    }
}
