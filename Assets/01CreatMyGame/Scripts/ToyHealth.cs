using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToyHealth : MonoBehaviour {
    public float ToyHp;
    private Animator toyAnim;
    private ToyMove toymove;
    private SpawnController spawncontroller;
    private NavMeshAgent agent;
    public bool isDead = false;
    void Awake () {
        spawncontroller = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        toyAnim = GetComponent<Animator>();
        toymove = GetComponent<ToyMove>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Takedamage(float damage)
    {
        ToyHp -= damage;
        if (ToyHp <= 0)
        {
            toymove.enabled = false;
            toyAnim.SetBool("Death", true);
            agent.enabled = false;
            isDead = true;
            Invoke("BodyGoaway", 4);
        }
    }
    private void BodyGoaway()
    {
        Destroy(this.gameObject);
        if(spawncontroller.ToyCount >= 1)
        {
            spawncontroller.ToyCount--;
        }
    }
}
