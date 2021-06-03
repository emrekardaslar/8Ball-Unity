using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isScored = false;
    public bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isScored==true)
        {
            OnHole();
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0.15f)
        {
            isMoving = true;
        }
        if (rb.velocity.magnitude < 0.15f)
        {
            rb.velocity = Vector2.zero;
            isMoving = false;
        }
    }

    public virtual void OnHole()
    {
        gameObject.SetActive(false);
    }
}
