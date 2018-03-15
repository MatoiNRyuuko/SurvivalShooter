using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDMG : MonoBehaviour {
    private float playerHp = 100;
    private Animator anim;
    private PlayerMove pm;
    private SkinnedMeshRenderer bodyRenderer;
    private float smoothTran = 5;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMove>();
        bodyRenderer = transform.Find("Player").GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            GetDMG(10);
        }*/
        bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothTran * Time.deltaTime);
    }

    public void GetDMG(float damage)
    {
        playerHp -= damage;
        Debug.Log(playerHp);
        bodyRenderer.material.color = Color.red;
        
        if (this.playerHp <= 0)
        {
            anim.SetBool("Death", true);

            pm.enabled = false;
        }
    }
}
