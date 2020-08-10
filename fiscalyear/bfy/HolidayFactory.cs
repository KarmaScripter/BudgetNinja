// // <copyright file = "HolidayFactory.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

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

    public class HolidayFactory : IFederalHoliday
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        public HolidayFactory()
        {
        }

        public HolidayFactory( DataRow datarow )
        {
            Record = datarow;
            NewYears = new Element( Record, Field.NewYears );
            MartinLutherKing = new Element( Record, Field.MartinLutherKing );
            Presidents = new Element( Record, Field.Presidents );
            Memorial = new Element( Record, Field.Memorial );
            Veterans = new Element( Record, Field.Veterans );
            Labor = new Element( Record, Field.Labor );
            Independence = new Element( Record, Field.Independence );
            Columbus = new Element( Record, Field.Columbus );
            Thanksgiving = new Element( Record, Field.Thanksgiving );
            Christmas = new Element( Record, Field.Christmas );
            Args = Record?.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private DataRow Record { get; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private IDictionary<string, object> Args { get; }

        /// <summary>
        /// Creates new years.
        /// </summary>
        /// <value>
        /// The new years.
        /// </value>
        private protected IElement NewYears { get; }

        /// <summary>
        /// Gets the martin luther king.
        /// </summary>
        /// <value>
        /// The martin luther king.
        /// </value>
        private protected IElement MartinLutherKing { get; }

        /// <summary>
        /// Gets the presidents.
        /// </summary>
        /// <value>
        /// The presidents.
        /// </value>
        private protected IElement Presidents { get; }

        /// <summary>
        /// Gets the memorial.
        /// </summary>
        /// <value>
        /// The memorial.
        /// </value>
        private protected IElement Memorial { get; }

        /// <summary>
        /// Gets the veterans.
        /// </summary>
        /// <value>
        /// The veterans.
        /// </value>
        private protected IElement Veterans { get; }

        /// <summary>
        /// Gets the labor.
        /// </summary>
        /// <value>
        /// The labor.
        /// </value>
        private protected IElement Labor { get; }

        /// <summary>
        /// Gets the independence.
        /// </summary>
        /// <value>
        /// The independence.
        /// </value>
        private protected IElement Independence { get; }

        /// <summary>
        /// Gets the columbus.
        /// </summary>
        /// <value>
        /// The columbus.
        /// </value>
        private protected IElement Columbus { get; }

        /// <summary>
        /// Gets the thanksgiving.
        /// </summary>
        /// <value>
        /// The thanksgiving.
        /// </value>
        private protected IElement Thanksgiving { get; }

        /// <summary>
        /// Gets the christmas.
        /// </summary>
        /// <value>
        /// The christmas.
        /// </value>
        private protected IElement Christmas { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the new years day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetNewYearsDay()
        {
            try
            {
                return NewYears;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the martin luther king day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetMartinLutherKingDay()
        {
            try
            {
                return MartinLutherKing;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the presidents day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetPresidentsDay()
        {
            try
            {
                return Presidents;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the memorial day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetMemorialDay()
        {
            try
            {
                return Memorial;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the veterans day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetVeteransDay()
        {
            try
            {
                return Veterans;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the labor day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetLaborDay()
        {
            try
            {
                return Labor;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the independence day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetIndependenceDay()
        {
            try
            {
                return Independence;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the columbus day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetColumbusDay()
        {
            try
            {
                return Columbus;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the thanksgiving day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetThanksgivingDay()
        {
            try
            {
                return Thanksgiving;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the christmas day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetChristmasDay()
        {
            try
            {
                return Christmas;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the federal holidays.
        /// </summary>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, DateTime> GetFederalHolidays( IDictionary<string, string> dict )
        {
            try
            {
                var holiday = new Dictionary<string, DateTime>();

                foreach( var kvp in dict )
                {
                    holiday.Add( kvp.Key, DateTime.Parse( kvp.Value ) );
                }

                return holiday.Any()
                    ? holiday
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the national holidays.
        /// </summary>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        /// <returns>
        /// </returns>
        public IDictionary<string, DateTime> GetNationalHolidays( IDictionary<string, string> dict )
        {
            try
            {
                var holiday = new Dictionary<string, DateTime>();

                foreach( var kvp in dict )
                {
                    holiday.Add( kvp.Key, DateTime.Parse( kvp.Value ) );
                }

                return holiday.Any()
                    ? holiday
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return Verify.Map( Args )
                    ? Args
                    : default;
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
