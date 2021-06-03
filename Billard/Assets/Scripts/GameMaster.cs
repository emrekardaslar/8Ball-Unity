using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Rigidbody2D[] balls;
    public bool whiteHit = false;
    public int solidScore =  0, stripeScore = 0;
    public bool solid = false, stripe = false;
    public bool solidHit = false, stripedHit = false;
    public bool solidCanHitBlack = false, stripesCanHitBlack=false;
    public bool areMoving = false;
    public bool whiteIn = false;
    public bool paused = false;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);  
    }
    private void Update()
    {     
        SetScores();
    }

    private void SetScores()
    {
        CheckBlack();
        CheckTurn();

    }

    private void CheckTurn()
    {
        Text turn = GameObject.Find("Canvas/Turn").GetComponent<Text>();
        if (solid)
            turn.text = "Solid's Turn";
        else if (stripe)
            turn.text = "Striped's Turn";
        else
            turn.text = "";
    }

    private static void CheckBlack()
    {
        Text solidText = GameObject.Find("Canvas/Solid").GetComponent<Text>();
        solidText.text = "Solid: " + instance.solidScore;
        if (instance.solidScore == 7)
        {
            instance.solidCanHitBlack = true;
        }

        Text stripedText = GameObject.Find("Canvas/Stripes").GetComponent<Text>();
        stripedText.text = "Stripes: " + instance.stripeScore;

        if (instance.stripeScore == 7)
        {
            instance.stripesCanHitBlack = true;
        }
    }

    private void LateUpdate()
    {
        if (whiteHit)
            checkBallMovement();
    }

    public void checkBallMovement()
    {
        int counter = 0;
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].GetComponent<Rigidbody2D>().velocity.magnitude == 0f)
            {
                counter++;
                if (counter==14)
                {
                    areMoving = false;
                }
            }
        }
    }
}
