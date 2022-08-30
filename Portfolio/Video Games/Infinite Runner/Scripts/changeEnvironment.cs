using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeEnvironment : MonoBehaviour
{
    public GameObject[] platformObjects;

    public PhysicsMaterial2D slippery;
    public PhysicsMaterial2D none;
    public PhysicsMaterial2D bounce;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("changePlatformEnvironment", 10f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Y))  //working code starts here
        {
            int randPlatform1 = Random.Range(0, platformObjects.Length);
            int randPlatform2 = Random.Range(0, platformObjects.Length);
            int layerChangeIce = LayerMask.NameToLayer("Ice");
            int layerChangeGround = LayerMask.NameToLayer("Ground");
            int layerChangeStuck = LayerMask.NameToLayer("Stuck");

            //ignore these 2 lines if uncommenting
            /*platformObjects[rand1].layer = layerChange1;
            Debug.Log("Changed Layer to Ice");*/

            /*int randLayer = Random.Range(0, 3);

            if (randLayer == 0)
            {
                if (platformObjects[randPlatform1] == null)
                {
                    return;
                }
                else
                {
                    platformObjects[randPlatform1].layer = layerChangeGround;
                    platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.white;
                    platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                    Debug.Log("Changed platform1 Layer to ground");
                }

                if (platformObjects[randPlatform2] == null)
                {
                    return;
                }
                else
                {
                    platformObjects[randPlatform2].layer = layerChangeGround;
                    platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.white;
                    platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                    Debug.Log("Changed platform2 Layer to ground");
                }
            }

            if (randLayer == 1)
            {
                if (platformObjects[randPlatform1] == null)
                {
                    return;
                }
                else
                {
                    platformObjects[randPlatform1].layer = layerChangeIce;
                    platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.cyan;
                    platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = slippery;
                    Debug.Log("Changed platform1 Layer to ice");
                }

                if (platformObjects[randPlatform2] == null)
                {
                    return;
                }
                else
                {
                    platformObjects[randPlatform2].layer = layerChangeGround;
                    platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.cyan;
                    platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = slippery;
                    Debug.Log("Changed platform2 Layer to ice");
                }
            }

            if (randLayer == 2)
            {
                if (platformObjects[randPlatform1] == null)
                {
                    return;
                }
                else
                {
                    platformObjects[randPlatform1].layer = layerChangeStuck;
                    platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.black;
                    platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                    Debug.Log("Changed platform1 Layer to stuck");
                }

                if (platformObjects[randPlatform2] == null)
                {
                    return;
                }
                else
                {
                    platformObjects[randPlatform2].layer = layerChangeStuck;
                    platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.black;
                    platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                    Debug.Log("Changed platform2 Layer to stuck");
                }
            }*/ //working code ends here

            /*if (platformObjects[rand1] == null)
            {
                return;
            }
            else
            {
                platformObjects[rand1].layer = layerChange1;
                platformObjects[rand1].GetComponent<SpriteRenderer>().color = Color.cyan;
                platformObjects[rand1].GetComponent<CapsuleCollider2D>().sharedMaterial = slippery;
                Debug.Log("Changed Layer to Ice");
            }*/
        //}
    }

     public void changePlatformEnvironment(int randLayer)
     {
        int randPlatform1 = Random.Range(0, platformObjects.Length);
        int randPlatform2 = Random.Range(0, platformObjects.Length);
        int layerChangeIce = LayerMask.NameToLayer("Ice");
        int layerChangeGround = LayerMask.NameToLayer("Ground");
        int layerChangeStuck = LayerMask.NameToLayer("Stuck");
        

        /*int randLayer = Random.Range(0, 3);*/

        if (randLayer == 0)
        {
            if (platformObjects[randPlatform1] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform1].layer = layerChangeGround;
                platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.white;
                platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                //Debug.Log("Changed platform1 Layer to ground");
            }

            if (platformObjects[randPlatform2] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform2].layer = layerChangeGround;
                platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.white;
                platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                //Debug.Log("Changed platform2 Layer to ground");
            }
            Debug.Log("Change-Ground");
        }

        if (randLayer == 1)
        {
            if (platformObjects[randPlatform1] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform1].layer = layerChangeIce;
                platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.cyan;
                platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = slippery;
                //Debug.Log("Changed platform1 Layer to ice");
            }

            if (platformObjects[randPlatform2] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform2].layer = layerChangeGround;
                platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.cyan;
                platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = slippery;
                //Debug.Log("Changed platform2 Layer to ice");
            }
            Debug.Log("Change-Ice");
        }

        if (randLayer == 2)
        {
            if (platformObjects[randPlatform1] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform1].layer = layerChangeStuck;
                platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.black;
                platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                //Debug.Log("Changed platform1 Layer to stuck");
            }

            if (platformObjects[randPlatform2] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform2].layer = layerChangeStuck;
                platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.black;
                platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                //Debug.Log("Changed platform2 Layer to stuck");
            }
            Debug.Log("Change-Stuck");
        }

        if (randLayer == 3)
        {
            if (platformObjects[randPlatform1] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform1].layer = layerChangeGround;
                platformObjects[randPlatform1].GetComponent<SpriteRenderer>().color = Color.red;
                platformObjects[randPlatform1].GetComponent<CapsuleCollider2D>().sharedMaterial = bounce;
                //Debug.Log("Changed platform1 Layer to stuck");
            }

            if (platformObjects[randPlatform2] == null)
            {
                return;
            }
            else
            {
                platformObjects[randPlatform2].layer = layerChangeGround;
                platformObjects[randPlatform2].GetComponent<SpriteRenderer>().color = Color.red;
                platformObjects[randPlatform2].GetComponent<CapsuleCollider2D>().sharedMaterial = bounce;
                //Debug.Log("Changed platform2 Layer to stuck");
            }
            Debug.Log("Change-Fire");
        }
    }

    public void InitialisePlatforms()
    {
        int layerChangeGround = LayerMask.NameToLayer("Ground");
        for (int i = 0; i < platformObjects.Length; i++)
        {
            if (platformObjects[i] == null)
            {
                return;
            }
            else
            {
                platformObjects[i].layer = layerChangeGround;
                platformObjects[i].GetComponent<SpriteRenderer>().color = Color.white;
                platformObjects[i].GetComponent<CapsuleCollider2D>().sharedMaterial = none;
                Debug.Log("initialised platform");
            }
        }
    }


}
