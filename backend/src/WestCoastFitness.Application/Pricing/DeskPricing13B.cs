namespace WestCoastFitness.Application;

public static class DeskPricing13B
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 221 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 222 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 223 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 224 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 225 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 226 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 227 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 228 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 229 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 230 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 231 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 232 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 233 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 234 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 235 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 236 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 237 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 238 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 239 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 240 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 241 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 242 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 243 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 244 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 245 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 246 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 247 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 248 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
