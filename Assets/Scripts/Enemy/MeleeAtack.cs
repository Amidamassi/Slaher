using UnityEngine;
using System.Collections;

public class MeleeAtack : MonoBehaviour
{
    [SerializeField] Transform player;
    private float cooldown=1.5f;
    private float endCooldown=0;
    private Vector3 distanceToPlayer;
    void Update()
    {
        distanceToPlayer = player.transform.position - this.transform.position;
        if ((distanceToPlayer.magnitude < 1) && (endCooldown < Time.realtimeSinceStartup)){
            //PlayerStats.currentHP--;
            endCooldown = Time.realtimeSinceStartup + cooldown;

        }
    }
}
