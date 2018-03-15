using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyActtack : MonoBehaviour
{
    private float attckTime = 2;
    private float timer;
    public float toyActtack;
    private PlayerGetDMG playerGetDMG;
    private ToyHealth toyhealth;
    // Use this for initialization
    void Start()
    {
        timer = attckTime;
        playerGetDMG = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGetDMG>();
        toyhealth = GetComponent<ToyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&&toyhealth.isDead == false)
        {
            timer += Time.deltaTime;
            if (timer > attckTime)
            {
                playerGetDMG.GetDMG(toyActtack);
                timer = 0;
            }
        }
    }
}
