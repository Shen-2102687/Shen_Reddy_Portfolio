using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawn : MonoBehaviour
{
    public GameObject[] platformPatterns;

    public float timeBetweenSpawn = 2f;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        //timeBetweenSpawn = 4f;
        //startTime = 1f;

        InvokeRepeating("spawnPlatform", 1f, timeBetweenSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (timeBetweenSpawn <= 0)
        {
            int rand = Random.Range(0, platformPatterns.Length);
            Instantiate(platformPatterns[rand], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTime;

            /*if (StartTime > MinTime)
            {
                StartTime = StartTime - decrease;
            }*/

        /*}
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }*/
    }

    void spawnPlatform()
    {
        int rand = Random.Range(0, platformPatterns.Length);
        Instantiate(platformPatterns[rand], transform.position, Quaternion.identity);
        //platformPatterns[rand].GetComponent<changeEnvironment>().changePlatformEnvironment(0);
        platformPatterns[rand].GetComponent<changeEnvironment>().InitialisePlatforms();
    }
}
