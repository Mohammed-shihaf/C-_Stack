namespace WestCoastFitness.Application;

public static class DeskPricing18A
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 306 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 307 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 308 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 309 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 310 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 311 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 312 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 313 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 314 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 315 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 316 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 317 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 318 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 319 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 320 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 321 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 322 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 323 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 324 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 325 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 326 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 327 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 328 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 329 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 330 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 331 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 332 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 333 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
