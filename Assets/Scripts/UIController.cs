using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
    {
    public float xpForNextLevel;
    public float currentXP;
    public float maxHP=10;
    public float currentHP;
    public Image Hp;
    public Image Xp;
    private UIBar uIBar;
    public Button inventory;

    void Update()
    {
        uIBar.BarFill(Hp, currentHP, maxHP);
        uIBar.BarFill(Xp, currentXP, maxHP);
    }
    
}
 