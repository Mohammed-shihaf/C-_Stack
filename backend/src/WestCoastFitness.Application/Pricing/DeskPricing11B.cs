namespace WestCoastFitness.Application;

public static class DeskPricing11B
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 187 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 188 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 189 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 190 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 191 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 192 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 193 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 194 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 195 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 196 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 197 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 198 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 199 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 200 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 201 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 202 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 203 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 204 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 205 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 206 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 207 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 208 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 209 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 210 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 211 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 212 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 213 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 214 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
