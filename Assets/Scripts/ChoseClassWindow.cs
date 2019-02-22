using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseClassWindow : MonoBehaviour
{
    [SerializeField] ClassList classList;
    [SerializeField] Dropdown classes;
    [SerializeField] Image symbol;
    [SerializeField] Text description;
    [SerializeField] Text stats;

    private int chosenedClass;
    

    private void Awake()
    {
        for(int i = 0; i < classList.baseClasses.Count; i++)
        {
            classes.options.Add(new Dropdown.OptionData(classList.baseClasses[i].className));
        }
    }
    public void OnValueChanged()
    {
        chosenedClass = classes.value;
        symbol.sprite = classList.baseClasses[chosenedClass].symbol;
        description.text = classList.baseClasses[chosenedClass].description;
        stats.text = "Характеристики \n";
        stats.text += "Сила:" + classList.baseClasses[chosenedClass].strenght+"\n";
        stats.text += "Ловкость" + classList.baseClasses[chosenedClass].dextrity;

    }
    public void ChoseClass() {
        Managers.Player.baseClass = classList.baseClasses[chosenedClass];
        this.gameObject.SetActive(false);
    }
}
