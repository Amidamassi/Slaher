using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    class DisableTrigger:MonoBehaviour,IDeviceTrigger
    {
    [SerializeField] GameObject target;

    public void Activate()
    {
        target.gameObject.SetActive(false);
    }
    public void Deactivate()
    {
        target.gameObject.SetActive(true);
    }
    }

