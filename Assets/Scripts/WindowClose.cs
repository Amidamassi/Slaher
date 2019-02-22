using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WindowClose : MonoBehaviour
{
    [SerializeField] private Image window;
    public void Close()
    {
        window.gameObject.SetActive(false);    } 
}
