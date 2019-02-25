using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    class MovementToPlayer:MonoBehaviour
    {
    [SerializeField] Transform player;
    private bool nearPlayer;
    NavMeshAgent agent;
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
       

    }
    void Update()
    {
        
        agent.destination=player.position ;
        agent.transform.LookAt(agent.nextPosition);

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

