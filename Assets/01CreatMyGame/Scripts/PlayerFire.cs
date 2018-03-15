using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private Light light;
    private ParticleSystem particlesystem;
    private LineRenderer lineRenderer;
    private AudioSource As;
    private float Attack = 5;
    private float AttackTime = 0.1f;
    private float timer = 1;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        particlesystem = GetComponentInChildren<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0)|| Input.GetMouseButtonDown(1))
        {
            if (timer > AttackTime)
            {
                timer = 0;
                shoot();
            }
            
        }
    }
    void shoot()
    {
        As.Play();
        light.enabled = true;
        particlesystem.Play();
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0,transform.position);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;
        //如果碰到东西，在raycastHit这个点上结束
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.tag == "Toy")
            {
                raycastHit.collider.GetComponent<ToyHealth>().Takedamage(Attack);
            }
            lineRenderer.SetPosition(1, raycastHit.point);
            
        }
        else {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }


        Invoke("ClearEffect",0.05f);
    }
    void ClearEffect()
    {
        light.enabled = false;
        lineRenderer.enabled = false; 
    }
}
