// <copyright file = "HolidayFactory.cs" company = "Terry D. Eppler">
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
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class HolidayFactory : IFederalHoliday
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected readonly DataRow _record;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected readonly IDictionary<string, object> _args;

        /// <summary>
        /// Creates new years.
        /// </summary>
        /// <value>
        /// The new years.
        /// </value>
        private protected readonly IElement _newYears;

        /// <summary>
        /// Gets the martin luther king.
        /// </summary>
        /// <value>
        /// The martin luther king.
        /// </value>
        private protected readonly IElement _martinLutherKing;

        /// <summary>
        /// Gets the presidents.
        /// </summary>
        /// <value>
        /// The presidents.
        /// </value>
        private protected readonly IElement _presidents;

        /// <summary>
        /// Gets the memorial.
        /// </summary>
        /// <value>
        /// The memorial.
        /// </value>
        private protected readonly IElement _memorial;

        /// <summary>
        /// Gets the veterans.
        /// </summary>
        /// <value>
        /// The veterans.
        /// </value>
        private protected readonly IElement _veterans;

        /// <summary>
        /// Gets the labor.
        /// </summary>
        /// <value>
        /// The labor.
        /// </value>
        private protected readonly IElement _labor;

        /// <summary>
        /// Gets the independence.
        /// </summary>
        /// <value>
        /// The independence.
        /// </value>
        private protected readonly IElement _independence;

        /// <summary>
        /// Gets the columbus.
        /// </summary>
        /// <value>
        /// The columbus.
        /// </value>
        private protected readonly IElement _columbus;

        /// <summary>
        /// Gets the thanksgiving.
        /// </summary>
        /// <value>
        /// The thanksgiving.
        /// </value>
        private protected readonly IElement _thanksgiving;

        /// <summary>
        /// Gets the christmas.
        /// </summary>
        /// <value>
        /// The christmas.
        /// </value>
        private protected readonly IElement _christmas;
        
        /// <summary>
        /// 
        /// </summary>
        public HolidayFactory()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRow"></param>
        public HolidayFactory( DataRow dataRow )
        {
            _record = dataRow;
            _newYears = new Element( _record, Field.NewYears );
            _martinLutherKing = new Element( _record, Field.MartinLutherKing );
            _presidents = new Element( _record, Field.Presidents );
            _memorial = new Element( _record, Field.Memorial );
            _veterans = new Element( _record, Field.Veterans );
            _labor = new Element( _record, Field.Labor );
            _independence = new Element( _record, Field.Independence );
            _columbus = new Element( _record, Field.Columbus );
            _thanksgiving = new Element( _record, Field.Thanksgiving );
            _christmas = new Element( _record, Field.Christmas );
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Gets the new years day.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetNewYearsDay()
        {
            try
            {
                return Verify.Element( _newYears )
                    ? _newYears
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _martinLutherKing )
                    ? _martinLutherKing
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _presidents )
                    ? _presidents
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _memorial )
                    ? _memorial
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _veterans )
                    ? _veterans
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _labor )
                    ? _labor
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _independence )
                    ? _independence
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _columbus )
                    ? _columbus
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _thanksgiving )
                    ? _thanksgiving
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return Verify.Element( _christmas )
                    ? _christmas
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                var _holiday = new Dictionary<string, DateTime>();

                foreach( var kvp in dict )
                {
                    _holiday.Add( kvp.Key, DateTime.Parse( kvp.Value ) );
                }

                return _holiday.Any()
                    ? _holiday
                    : default( Dictionary<string, DateTime> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, DateTime> );
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
                var _holiday = new Dictionary<string, DateTime>();

                foreach( var kvp in dict )
                {
                    _holiday.Add( kvp.Key, DateTime.Parse( kvp.Value ) );
                }

                return _holiday.Any()
                    ? _holiday
                    : default( Dictionary<string, DateTime> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, DateTime> );
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
                return Verify.Map( _args )
                    ? _args
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
