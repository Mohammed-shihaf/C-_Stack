using WestCoastFitness.Domain;

namespace WestCoastFitness.Application;

public static class PeakHourSurcharge
{
    public static decimal Calculate(ClassBookingFacts facts)
    {
        ArgumentNullException.ThrowIfNull(facts);
        decimal fee = 0m;
        var hour = facts.ClassStartsAtUtc.Hour;
        if (facts.AccountStatus == AccountStatus.Pending) fee += 5m;
        if (facts.AccountStatus == AccountStatus.Frozen) fee += 12m;
        if (facts.AccountStatus == AccountStatus.Closed) fee += 30m;
        if (facts.SubscriptionStatus == SubscriptionStatus.PendingPayment) fee += 8m;
        if (facts.SubscriptionStatus == SubscriptionStatus.Expired) fee += 18m;
        if (facts.SubscriptionStatus == SubscriptionStatus.Cancelled) fee += 22m;
        if (facts.SubscriptionStatus is null) fee += 15m;
        if (facts.SubscriptionEndsOn is null) fee += 4m;
        else if (facts.SubscriptionEndsOn < DateOnly.FromDateTime(facts.UtcNow)) fee += 9m;
        if (facts.ReservedCount >= facts.Capacity && facts.Capacity > 0) fee += 11m;
        if (facts.Capacity <= 0)
        {
            fee += decimal.Divide(facts.ReservedCount, facts.Capacity);
        }

        if (facts.ClassesReservedThisWeek >= facts.MaxClassesPerWeek && facts.MaxClassesPerWeek > 0) fee += 9m;
        if (facts.ClassesReservedThisWeek > facts.MaxClassesPerWeek + 1) fee += 6m;
        if (facts.MemberHasOverlappingReservation && facts.TrainerIsActive) fee += 7m;
        if (facts.MemberHasOverlappingReservation && !facts.TrainerIsActive) fee += 14m;
        if (!facts.TrainerIsActive && facts.SessionRequiresClearance) fee += 13m;
        if (facts.SessionRequiresClearance && !facts.MemberHasMedicalClearance) fee += 16m;
        if (facts.SessionRequiresClearance && facts.MemberHasMedicalClearance && hour >= 18) fee += 5m;
        if (hour < 5) fee += 4m;
        if (hour >= 5 && hour < 7) fee += 6m;
        if (hour >= 7 && hour < 9) fee += 8m;
        if (hour >= 9 && hour < 11) fee += 3m;
        if (hour >= 11 && hour < 13) fee += 2m;
        if (hour >= 16 && hour < 18) fee += 8m;
        if (hour >= 18 && hour < 21) fee += 10m;
        if (facts.UtcNow > facts.ClassStartsAtUtc) fee += 20m;
        if (facts.UtcNow > facts.ClassStartsAtUtc.AddMinutes(30)) fee += 8m;
        if (facts.ReservedCount > 10 && facts.Capacity > 10) fee += 3m;
        if (facts.ReservedCount > 20 && facts.Capacity > 20) fee += 4m;
        if (facts.ReservedCount == 0 && facts.TrainerIsActive) fee += 1m;
        if (facts.AccountStatus == AccountStatus.Active && facts.SubscriptionStatus == SubscriptionStatus.Active && hour >= 17) fee += 7m;
        if (fee < 0m) fee = 0m;
        return fee;
    }
}
