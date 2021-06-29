using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 0.5f;
    private LineRenderer lineRenderer;
    private Renderer Rend;
    AudioSource playerHit;
    bool isHit = false;
    bool mouseBeingHeld = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        Rend = GetComponent<Renderer>();
        lineRenderer.positionCount = 3;
      //  lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
      //  lineRenderer.SetColors(Color.black, Color.yellow);
        playerHit = GetComponent<AudioSource>();
    }

    Vector2 direction;
    void Update()
    {   if (!GameMaster.instance.paused && GameMaster.instance.whiteIn == false)
        {
            if (Input.GetMouseButtonDown(0) && !GameMaster.instance.areMoving)
                mouseBeingHeld = true;

            lineRenderer.SetPosition(0, -Camera.main.ScreenToWorldPoint(Input.mousePosition) + 2*transform.position);
            lineRenderer.SetPosition(1, transform.position);
            // set your Texture Wrap Mode to Repeat in case you want some texture to repeat over the line.
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction = -direction;
            if (Mathf.Abs(direction.x) < 3f && Mathf.Abs(direction.y) < 3f && rb.velocity.magnitude == 0 && mouseBeingHeld)
            {
                lineRenderer.SetWidth(0.05f, 0.05f);
                Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(2, cursorPosition);
                if (Input.GetMouseButtonUp(0))
                    lineRenderer.SetWidth(0f, 0f);
            }
            else
            {
                lineRenderer.SetWidth(0f, 0f);
            }
            if (Input.GetMouseButtonUp(0) && Mathf.Abs(direction.x) < 3f && Mathf.Abs(direction.y) < 3f && rb.velocity.magnitude == 0 && !GameMaster.instance.areMoving && mouseBeingHeld)
            {
                isHit = true;
                GameMaster.instance.whiteHit = true;
                GameMaster.instance.solidHit = false;
                GameMaster.instance.stripedHit = false;
                playerHit.Play();
                rb.AddForce(direction * speed, ForceMode2D.Impulse);
                mouseBeingHeld = false;
            }
        }
        
    }

    public void checkTurn()
    {
        if (GameMaster.instance.whiteIn)
        {
            changeTurn();
            GameMaster.instance.whiteIn = false;
        }

        else
        {
            if (!GameMaster.instance.solidHit && GameMaster.instance.solid) //Solid couldn't hit and its solid's turn
                changeTurn();

            else if (!GameMaster.instance.stripedHit && GameMaster.instance.stripe) //Striped couldn't hit and its striped's turn
                changeTurn();
        }        
    }

    public void changeTurn()
    {
        if (GameMaster.instance.solid == true)
        {
            GameMaster.instance.solid = false;
            GameMaster.instance.stripe = true;
        }

        else if (GameMaster.instance.stripe == true)
        {
            GameMaster.instance.solid = true;
            GameMaster.instance.stripe = false;
        }

        else
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("solidBall") || collision.gameObject.CompareTag("stripedBall"))
        {
            GameMaster.instance.areMoving = true;
            if (rb.velocity.magnitude > 0.5f)
                playerHit.Play();
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.15f)
        {
            rb.velocity = Vector2.zero;
            if (isHit == true && GameMaster.instance.areMoving==false)
            {
                checkTurn();
                isHit = false;
                GameMaster.instance.whiteHit = false;
            }
        }
    }
}
