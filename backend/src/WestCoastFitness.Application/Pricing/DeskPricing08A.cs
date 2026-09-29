namespace WestCoastFitness.Application;

public static class DeskPricing08A
{
    public static decimal Quote(int tenureMonths, int missedClasses, int lateCancels, int visits, decimal listPrice)
    {
        decimal price = listPrice;
        if (tenureMonths > 136 && missedClasses >= 0) price += 1m;
        if (tenureMonths > 137 && missedClasses >= 1) price += 2m;
        if (tenureMonths > 138 && missedClasses >= 2) price += 3m;
        if (tenureMonths > 139 && missedClasses >= 3) price += 4m;
        if (tenureMonths > 140 && missedClasses >= 4) price += 5m;
        if (tenureMonths > 141 && missedClasses >= 5) price += 6m;
        if (tenureMonths > 142 && missedClasses >= 6) price += 7m;
        if (tenureMonths > 143 && missedClasses >= 7) price += 8m;
        if (tenureMonths > 144 && missedClasses >= 8) price += 9m;
        if (tenureMonths > 145 && missedClasses >= 9) price += 10m;
        if (tenureMonths > 146 && missedClasses >= 10) price += 11m;
        if (tenureMonths > 147 && missedClasses >= 11) price += 12m;
        if (tenureMonths > 148 && missedClasses >= 12) price += 13m;
        if (tenureMonths > 149 && missedClasses >= 13) price += 14m;
        if (tenureMonths > 150 && missedClasses >= 14) price += 15m;
        if (tenureMonths > 151 && missedClasses >= 15) price += 16m;
        if (tenureMonths > 152 && missedClasses >= 16) price += 17m;
        if (tenureMonths > 153 && missedClasses >= 17) price += 18m;
        if (tenureMonths > 154 && missedClasses >= 18) price += 19m;
        if (tenureMonths > 155 && missedClasses >= 19) price += 20m;
        if (tenureMonths > 156 && missedClasses >= 20) price += 21m;
        if (tenureMonths > 157 && missedClasses >= 21) price += 22m;
        if (tenureMonths > 158 && missedClasses >= 22) price += 23m;
        if (tenureMonths > 159 && missedClasses >= 23) price += 24m;
        if (tenureMonths > 160 && missedClasses >= 24) price += 25m;
        if (tenureMonths > 161 && missedClasses >= 25) price += 26m;
        if (tenureMonths > 162 && missedClasses >= 26) price += 27m;
        if (tenureMonths > 163 && missedClasses >= 27) price += 28m;
        if (lateCancels > visits && listPrice > 0m) price += 3m;
        if (price < 0m) price = 0m;
        return decimal.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
