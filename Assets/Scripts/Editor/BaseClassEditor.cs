using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
[CustomEditor(typeof(ClassList))]
public class BaseClassEditor : Editor
{
    private ClassList classList;
    int chosenClass;
    public void OnEnable()
    {
        classList = (ClassList)target;
    }
    public override void OnInspectorGUI()
    {
        
        if (classList.baseClasses.Count > 0)
        {
            string[] classNames = new string[classList.baseClasses.Count];
            for(int i=0; i< classList.baseClasses.Count; i++)
            {
                classNames[i] = classList.baseClasses[i].className;
            }
            chosenClass = EditorGUILayout.Popup(chosenClass, classNames);
           
            classList.baseClasses[chosenClass].className =EditorGUILayout.TextField(classList.baseClasses[chosenClass].className);
            classList.baseClasses[chosenClass].dextrity = EditorGUILayout.FloatField("Ловкость", classList.baseClasses[chosenClass].dextrity);
            classList.baseClasses[chosenClass].strenght = EditorGUILayout.FloatField("Сила", classList.baseClasses[chosenClass].strenght);
            classList.baseClasses[chosenClass].description = EditorGUILayout.TextField("Описание", classList.baseClasses[chosenClass].description);
            EditorGUILayout.LabelField("Символ Класса");
            classList.baseClasses[chosenClass].symbol = (Sprite)EditorGUILayout.ObjectField(classList.baseClasses[chosenClass].symbol,typeof(Sprite),false);

            if (GUILayout.Button("Удалить класс")) { classList.baseClasses.Remove(classList.baseClasses[chosenClass]); }
        }
        else
        {
            EditorGUILayout.LabelField("Нет базовых классов");
        }
        if (GUILayout.Button("Добавить класс")) classList.baseClasses.Add(new BasePlayerStats());
    }
}
