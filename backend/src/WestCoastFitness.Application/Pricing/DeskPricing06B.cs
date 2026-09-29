namespace WestCoastFitness.Application;

public static class DeskPricing06B
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 102 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 103 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 104 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 105 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 106 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 107 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 108 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 109 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 110 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 111 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 112 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 113 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 114 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 115 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 116 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 117 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 118 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 119 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 120 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 121 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 122 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 123 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 124 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 125 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 126 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 127 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 128 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 129 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
