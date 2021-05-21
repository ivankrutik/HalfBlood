namespace Halfblood.AlgorithmsOfCalculation
{
    using System;

    public class CreditSlipDomainAlgorithmsOfCalculation
    {
        public static decimal SumWithNDS(decimal quantity, decimal price, decimal tax)
        {
            return Math.Round(quantity * price + (quantity * price / 100 * tax), 2);
        }

        public static decimal Price(decimal quantity, decimal tax, decimal sumWithNDS)
        {
            return Math.Round((sumWithNDS * 100 / (100 + tax)) / quantity, 2);
        }

        public static decimal SumWithoutNDS(decimal quantity, decimal price)
        {
            return Math.Round(quantity * price, 2);
        }
        public static decimal SumNDS(decimal quantity, decimal price, decimal tax)
        {
            return Math.Round(quantity * price / 100 * tax, 2);
        }
    }
}
