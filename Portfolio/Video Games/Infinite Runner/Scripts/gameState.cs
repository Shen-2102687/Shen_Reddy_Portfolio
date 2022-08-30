using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour
{
    public GameObject playerObject;
    //public GameObject respawnPlatform;

    //Vector2 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //respawnPlatform.transform.rotation = new Vector2()
        if (playerObject.transform.position.y <= -4)
        {
            /*Vector2 platformSpawnPoint = new Vector2(-2f, 3f);
            Instantiate(respawnPlatform, transform.position = platformSpawnPoint, Quaternion.identity);
            playerObject.transform.position = new Vector2(-2f, 4f);*/
            scoreManager.scoreCounter = 0;
        }
    }
}
