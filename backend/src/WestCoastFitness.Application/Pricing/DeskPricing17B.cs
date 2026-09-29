namespace WestCoastFitness.Application;

public static class DeskPricing17B
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 289 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 290 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 291 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 292 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 293 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 294 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 295 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 296 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 297 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 298 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 299 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 300 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 301 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 302 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 303 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 304 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 305 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 306 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 307 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 308 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 309 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 310 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 311 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 312 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 313 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 314 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 315 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 316 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
