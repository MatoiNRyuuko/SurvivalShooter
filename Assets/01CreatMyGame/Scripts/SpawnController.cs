using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    public Vector3 spawnVec;
    public GameObject bear;
    public GameObject bunny;
    public GameObject elephant;
    private float timer = 0;
    public float ToyCount = 0;
    private 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 0.5&&ToyCount<30)
        {
            float randomSpawn = Random.Range(1, 4);
            if(randomSpawn == 1)
            {
                SpawnToy(bear);
            }
            if (randomSpawn == 2)
            {
                SpawnToy(bunny);
            }
            if (randomSpawn == 3)
            {
                SpawnToy(elephant);
            }

            timer = 0;
        }
	}

    private void SpawnToy(GameObject randomToy)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnVec.x, spawnVec.x), spawnVec.z,Random.Range(-spawnVec.z, spawnVec.z));
        Instantiate(randomToy, spawnPosition, transform.rotation);
        ToyCount++;
    }
}
