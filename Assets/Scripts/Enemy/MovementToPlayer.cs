using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    class MovementToPlayer:MonoBehaviour
    {
    [SerializeField] Transform player;
    private bool nearPlayer;
    NavMeshAgent agent;
    /* private Vector3 moveDirection;
     private float moveSpeed=3;
     private bool nearPlayer;*/
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
       

    }
    void Update()
    {
        
        agent.destination=player.position ;
        agent.transform.LookAt(agent.nextPosition);

        /*    if (!nearPlayer)
            {
                moveDirection = player.transform.position - this.transform.position;
                moveDirection.Normalize();
                this.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }*/
    }
    void OnTriggerEnter()
    {
        nearPlayer = true;
        Debug.Log("enter");
    }
    void OnTriggerExit()
    {
        nearPlayer = false;
        Debug.Log("Exit");
    }
}

