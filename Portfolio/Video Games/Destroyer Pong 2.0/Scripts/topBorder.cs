using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topBorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("lazer"))
        {
            Destroy(other.gameObject);
            Debug.Log("lazer destroyed");
        }
    }
}
