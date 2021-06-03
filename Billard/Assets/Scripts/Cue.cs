using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    // Start is called before the first frame update

    public float distance = 1.0f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 mousePosition;
    private float moveSpeed = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update() { 
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        /*
        if (Input.GetMouseButton(1))
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position.normalized;
            //  transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

            //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = Input.mousePosition;
            mousePosition.x = distance;
            //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * 1f / direction.magnitude * Time.deltaTime);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        */
        

    }


}
