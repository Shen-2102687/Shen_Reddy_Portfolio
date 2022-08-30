using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static int randLayer;

    public GameObject[] platformPattern;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeGameEnvironment", 7f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeGameEnvironment()
    {
        randLayer = Random.Range(0, 4);


        //FindObjectOfType<changeEnvironment>().changePlatformEnvironment(randLayer);
        //environmentScript.changePlatformEnvironment(randLayer);
        /*for (int i = 0; i < platformPatterns.Length; i++)
        {
            platformPatterns[i].GetComponent<changeEnvironment>().changePlatformEnvironment(randLayer);
        }*/

        platformPattern = GameObject.FindGameObjectsWithTag("platforms");
        foreach (GameObject platform in platformPattern)
        {
            platform.GetComponent<changeEnvironment>().changePlatformEnvironment(randLayer);
        }
        Debug.Log("Environment change called");
        
    }

}
