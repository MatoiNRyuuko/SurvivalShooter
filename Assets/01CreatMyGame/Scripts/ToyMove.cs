using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToyMove : MonoBehaviour {
    private NavMeshAgent agent;
    private Transform playerPosition;
    private Vector3 distance;
    private float NavDistanece = 30;
    private Animator ToyAnim;
    private PlayerGetDMG playerGetDMG;
	// Use this for initialization
	void Start () {
       agent = GetComponent<NavMeshAgent>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        ToyAnim = GetComponent<Animator>();
        playerGetDMG = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGetDMG>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, playerPosition.position)> NavDistanece)
        {
            ToyAnim.SetBool("Move", false);
            return;
        }
        else
        {
            agent.SetDestination(playerPosition.position);
            ToyAnim.SetBool("Move", true);
            
        }
	}
}
