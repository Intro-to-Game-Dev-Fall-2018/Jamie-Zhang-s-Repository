using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Vector3 startingPosOne;
    Vector3 startingPosTwo;
    Rigidbody2D rb2D;
    public float maxSpeed;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        startingPosOne = PlayerOne.S.transform.position;
        startingPosTwo = PlayerTwo.S.transform.position;
    }

    void FixedUpdate()
    {
        if (rb2D.velocity.magnitude > maxSpeed)
        {
            rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
        }
    }

    void Update()
    {
        Debug.Log(rb2D.velocity.magnitude);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "floor" && (transform.position.x < 0))
        {
            ScoreKeeper.S.blueScore++;
            ScoreKeeper.S.IncrementVisualScoreBlue();

            PlayerOne.S.transform.position = startingPosOne;
            transform.position = PlayerOne.S.transform.position + Vector3.up * 3.56f;

            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        if (col.gameObject.tag == "floor" && (transform.position.x > 0))
        {
            ScoreKeeper.S.redScore++;
            ScoreKeeper.S.IncrementVisualScoreRed();

            PlayerTwo.S.transform.position = startingPosTwo;
            transform.position = PlayerTwo.S.transform.position + Vector3.up * 3.56f;

            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

}
