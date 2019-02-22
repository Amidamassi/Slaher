using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAtack : MonoBehaviour
{
    private bool alreadyAtack;
    private Vector3 atackMove;
    private Vector3 atackRotate;
    private Animator animator;
    private float atackFullTime=1f;
    private float atackReverseTime = 0;
    private float atackStopTime = 0;
    private float atackRadius=1;
    private PlayerManager playerManager;
    private void Start()

    {
        playerManager = Managers.Player;
        animator = GetComponent<Animator>();
        atackRotate = new Vector3(0, -8f, 0);
        atackMove = new Vector3(0, 0, 0.05f);
    }
    
    void FixedUpdate() {
        if (!alreadyAtack)
        {
            if (Input.GetKey("f"))
            {
                animator.SetBool("Atack", true);
                alreadyAtack = true;
                atackStopTime = Time.realtimeSinceStartup + atackFullTime;
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, atackRadius = 1);
                foreach (Collider hitCollider in hitColliders)
                {
                    hitCollider.SendMessage("RecieveDamage",playerManager.MeleeDamage,SendMessageOptions.DontRequireReceiver);
                }

            }
        }
        if (alreadyAtack)
        {
                if (Time.realtimeSinceStartup > atackStopTime)
                {
                alreadyAtack = false;
                animator.SetBool("Atack", false);
            }
            }

        }
    
}
