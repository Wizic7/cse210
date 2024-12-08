class DamageCalculator
{
    public static int calculateDamage(int attack, int defense)
    {
        if(attack - defense < 0)
        {
            return 0;
        }
        return attack - defense;
    }

    public static int calculateSkillDamage(int skill, Character attacker, Character defender)
    {
        //Ignores Armor
        if(skill == 1)
        {
            return attacker.getAttack() * 2;
        }
        //Does Max-health Damage & ignores armor
        else if(skill == 2)
        {
            return defender.GetLifeBarData()._total_health/2;
        }
        return 0;
    }

    

}