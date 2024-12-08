class DamageCalculator
{
    public static int calculateDamage(int attack, int defense)
    {
        return attack - defense;
    }

    public static int calculateSkillDamage(int skill, Character attacker, Character defender)
    {
        if(skill == 1)
        {
            return attacker.getAttack() * 2;
        }
        else if(skill == 2)
        {
            return defender.GetLifeBarData()._total_health/2;
        }
        return 0;
    }

    

}