using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour,IDeviceOperate,IDeviceTrigger
{
    [SerializeField] private Vector3 doorPos;
    private bool open;
    public void Operate()
    {
        if (open)
        {
            Vector3 pos = transform.position - doorPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + doorPos;
            transform.position = pos;
        }
        open = !open;
    }
    public void Activate()
    {
        if (!open)
        {
            Vector3 pos = transform.position - doorPos;
            transform.position = pos;
            open = true;
        }
    }
    public void Deactivate()
    {
        if (!open)
        {
            Vector3 pos = transform.position + doorPos;
            transform.position = pos;
            open = false;
        }
    }
}

