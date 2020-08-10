// // <copyright file = "IFederalHoliday.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    using System;
    using System.Threading;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    public interface IFederalHoliday
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        IElement GetNewYearsDay();

        IElement GetMartinLutherKingDay();

        IElement GetPresidentsDay();

        IElement GetMemorialDay();

        IElement GetVeteransDay();

        IElement GetLaborDay();

        IElement GetColumbusDay();

        IElement GetThanksgivingDay();

        IElement GetChristmasDay();
    }
}
