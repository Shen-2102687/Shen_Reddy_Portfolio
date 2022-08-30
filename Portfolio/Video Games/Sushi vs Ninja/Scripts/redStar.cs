using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redStar : MonoBehaviour
{
    public Rigidbody2D starRB;

    private float forceMultiplier; // target force
    public float setForce; // standard force

    private Vector3 totalForce;
    private Vector3 direction;

    Vector3 mousePos;
    Vector3 startPos;

    private bool starThrown = false;
    private bool pulled = false;

    private float minX = 0;
    private float maxX = 0;
    private float minY = 0;
    private float maxY = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!pulled)
        {
            startPos = transform.position;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        forceMultiplier = (startPos - mousePos).sqrMagnitude;
        direction = (startPos - mousePos).normalized;

      
    }

    private void OnMouseDrag()
    {
        if (!pulled)
        {
            minX = mousePos.x - 5;
            maxX = transform.position.x;

            minY = mousePos.y - 5;
            maxY = mousePos.y + 5;

            pulled = true;
        }

        float xPos = transform.position.x;
        xPos = Mathf.Clamp(mousePos.x, minX, maxX);

        float yPos = transform.position.y;
        yPos = Mathf.Clamp(mousePos.y, minY, maxY);

        transform.position = new Vector3(xPos, xPos);
    }

    private void OnMouseUp()
    {
        if (!starThrown)
        {
            totalForce = direction * forceMultiplier * setForce;
            totalForce = Vector3.ClampMagnitude(totalForce, 80);
            starRB.AddForce(totalForce, ForceMode2D.Impulse);
            starThrown = true;
        }
    }
}
