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

    // Update is called once per frame
    void Update()
    {
        if (timeUntilSpawn <= 0)
        {
            int randomObstacle = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomObstacle], transform.position, Quaternion.identity);
            timeUntilSpawn = timer;
        }

        else { timeUntilSpawn -= Time.deltaTime; }
    }
}
