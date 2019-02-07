using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static int strenght = 10;
    public static int currentHP;
    public static int xp=0;
    private static int maxHP;
    private static int xpforNextLvl=10;
    private static int statsPoint;
    private static int abilityPoint;
    private int statsPointPerLvl;
    private int abilityPointPerLvl;
    [SerializeField] Image health;
    [SerializeField] Image XP;

    private void Start()
    {
        maxHP = strenght * 2;
        currentHP = maxHP;
    }
    void Update()
    {
        BarFill(health, currentHP, maxHP);
       
    }
    void EarnXP(int xpgained)
    {
        xp += xpgained;
        if (xp > xpforNextLvl)
        {
            LeveluP();
            xp -= xpforNextLvl;
        }
        BarFill(health, currentHP, maxHP);
    }
    void LeveluP()
    {
        GainStatsPoint(statsPointPerLvl);
        GainAbilityPoint(abilityPointPerLvl);

    }
    public void BarFill(Image image, float current, float max)
    {
        image.fillAmount = current / max;
    }
    public static void GainStatsPoint(int pointGainValue)
    {
        statsPoint += pointGainValue;
    }
    public static void GainAbilityPoint(int pointGainValue)
    {
        abilityPoint += pointGainValue;
    }
}

