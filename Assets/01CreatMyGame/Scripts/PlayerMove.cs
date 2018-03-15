using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;
    private Rigidbody rigidbody;
    private Animator playerAction;
    private int Groundindex = -1;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerAction = GetComponent<Animator>();
        Groundindex = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        //角色的移动触发
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(H, 0, V) * speed) ;
        rigidbody.velocity = new Vector3(H, 0, V) * speed;

        //角色的面向触发

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100, Groundindex)){
            Vector3 target = raycastHit.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }





        //角色的动画触发
        if (H != 0 || V != 0)
        {
            playerAction.SetBool("Move", true);
        }
        else
        {
            playerAction.SetBool("Move", false);
        }
    }
}
