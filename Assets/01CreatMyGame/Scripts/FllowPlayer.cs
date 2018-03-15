using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowPlayer : MonoBehaviour {
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void FixedUpdate () {
        Vector3 playerPosition = player.position + new Vector3(0.45f, 9, -11);
        transform.position = Vector3.Lerp(transform.position, playerPosition, 0.1f);

    }
}
