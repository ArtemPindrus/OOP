namespace Project;

public static class Combat {
    public static bool Attack(Entity a, Entity h) {
        if (!a.TryGet<Attacker>(out var attacker)) return false;
        if (!h.TryGet<Health>(out var health)) return false;

        health.TakeDamage(attacker.Damage);
        return true;
    }
}