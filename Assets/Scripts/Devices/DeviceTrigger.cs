using UnityEngine;
using System.Collections;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    public bool requireKey;
    private void OnTriggerEnter(Collider other)
    {
        
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
