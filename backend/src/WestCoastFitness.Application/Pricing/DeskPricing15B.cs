namespace WestCoastFitness.Application;

public static class DeskPricing15B
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 255 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 256 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 257 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 258 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 259 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 260 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 261 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 262 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 263 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 264 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 265 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 266 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 267 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 268 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 269 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 270 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 271 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 272 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 273 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 274 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 275 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 276 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 277 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 278 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 279 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 280 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 281 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 282 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
