using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour,IGameManager
{
    public static int strenght = 10;
    public static int xp = 0;
    private static int lvl = 1;
    private static int xpforNextLvl = 10;
    private static int statsPoint;
    private static int abilityPoint;
    private int statsPointPerLvl;
    private int abilityPointPerLvl;
    [SerializeField] Image healthbar;
    [SerializeField] Image XPbar;
    public float MeleeDamage = 5;// { get; private set; }
    public ManagerStatus status { get; private set; }
    public int health { get;private set; }
    public int maxHealth { get;private set; }
    public BasePlayerStats baseClass { get; set; }
    public void Startup()
    {
        maxHealth = strenght * 2;
        health = maxHealth;
        health = 50;
        maxHealth = 100;
        status = ManagerStatus.Started;
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
    }
  
    
    void Update()
    {
        BarFill(healthbar, health, maxHealth);

    }
    void EarnXP(int xpgained)
    {
        xp += xpgained;
        if (xp < 0)
        {
            xp = 0;
        }
        if (xp > xpforNextLvl)
        {
            LeveluP();
            xp -= xpforNextLvl;
        }
        BarFill(XPbar, xp, xpforNextLvl);
    }
    void LeveluP()
    {
        GainStatsPoint(statsPointPerLvl);
        GainAbilityPoint(abilityPointPerLvl);
        lvl++;
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
