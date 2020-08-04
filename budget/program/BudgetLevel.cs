// <copyright file="BudgetLevel.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // **************************************************   ASSEMBLIES   ********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class BudgetLevel : IBudgetLevel
    {
        // **********************************************************************************************************************
        // ***********************************************  CONSTRUCTORS  *******************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetLevel"/> class.
        /// </summary>
        public BudgetLevel()
        {
            Level = Level.Region;
            Code = ( (int)Level ).ToString();
            Name = Level.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetLevel"/> class.
        /// </summary>
        /// <param name = "budgetlevel" >
        /// The budgetlevel.
        /// </param>
        public BudgetLevel( string budgetlevel )
        {
            Level = GetLevel( budgetlevel );
            Code = ( (int)Level ).ToString();
            Name = Level.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetLevel"/> class.
        /// </summary>
        /// <param name = "level" >
        /// The level.
        /// </param>
        private BudgetLevel( Level level )
        {
            Level = level;
            Code = ( (int)Level ).ToString();
            Name = Level.ToString();
        }

        // **********************************************************************************************************************
        // **************************************************   PROPERTIES   ****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        private Level Level { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private string Code { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private string Name { get; }

        // **********************************************************************************************************************
        // **************************************************  METHODS   ********************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the level number.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetNumber()
        {
            try
            {
                return Enum.IsDefined( typeof( Level ), Level.ToString() )
                    ? (int)Enum.Parse( typeof( Level ), Level.ToString() )
                    : (int)Level.Region;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the level.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetName()
        {
            try
            {
                return Verify.Input( Name )
                    ? Name
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns>
        /// </returns>
        public Level GetLevel()
        {
            try
            {
                return Enum.IsDefined( typeof( Level ), Level )
                    ? Level
                    : Level.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <param name = "budgetlevel" >
        /// The budgetlevel.
        /// </param>
        /// <returns>
        /// </returns>
        private Level GetLevel( string budgetlevel )
        {
            try
            {
                return Verify.Input( budgetlevel )
                    && int.Parse( budgetlevel ) < 9
                    && int.Parse( budgetlevel ) > 6
                    && !Enum.IsDefined( typeof( Level ), int.Parse( budgetlevel ) )
                        ? (Level)Enum.Parse( typeof( Level ), budgetlevel )
                        : Level.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Input( Code )
                    ? Code
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
        {
            if( Enum.IsDefined( typeof( Level ), Level )
                && Verify.Input( Code )
                && Verify.Input( Name ) )
            {
                try
                {
                    return new Dictionary<string, object>()
                    {
                        [ $"{Level}" ] = Level.ToString(),
                        [ $"{Code}" ] = Code,
                        [ $"{Name}" ] = Name
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
        /// Gets the budget level.
        /// </summary>
        /// <returns>
        /// </returns>
        public BudgetLevel GetBudgetLevel()
        {
            try
            {
                return MemberwiseClone() as BudgetLevel;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}