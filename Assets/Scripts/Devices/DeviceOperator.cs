using UnityEngine;
using System.Collections;

public class DeviceOperator : MonoBehaviour
{
    private float radius = 1.5f;

    void Update()
    {
        if (Input.GetKey("e"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider hitCollider in hitColliders)
            {
                hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
