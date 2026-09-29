namespace WestCoastFitness.Application;

public static class DeskPricing01B
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 17 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 18 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 19 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 20 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 21 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 22 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 23 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 24 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 25 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 26 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 27 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 28 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 29 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 30 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 31 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 32 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 33 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 34 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 35 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 36 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 37 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 38 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 39 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 40 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 41 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 42 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 43 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 44 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
