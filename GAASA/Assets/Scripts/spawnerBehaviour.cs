using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBehaviour : MonoBehaviour
{
    public GameObject[] obstacles;

    //Tiempo transcurrido desde el ultimo spawn
    private float timeUntilSpawn;
    //Cada cuanto tiempo se spawnea un objeto
    [SerializeField]
    private float timer;
    public float timeReduc = 0.25f;
    public float minimo = 1.5f;

    public float spawnerMin = -5f;
    public float spawnerMax = 5f;

    // Update is called once per frame
    void Update()
    {
        if (timeUntilSpawn <= 0)
        {
            int randomObstacle = Random.Range(0, obstacles.Length);
            float randOffset = Random.Range(spawnerMin, spawnerMax);

            Instantiate(obstacles[randomObstacle], 
                new Vector3(transform.position.x,transform.position.y+randOffset, 0f),
                Quaternion.identity);

            if (timer > minimo)
            {
                timer -= timeReduc;
            }

            timeUntilSpawn = timer;

        }

        else { timeUntilSpawn -= Time.deltaTime; }
    }
}
