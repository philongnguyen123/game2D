using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 500f;
    public float maxVelocity = 4f;

    private bool grounded;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyBoard();
    }

    void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                //forceX = moveForce;
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            scale.x = 2f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                //forceX = -moveForce;
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            scale.x = -2f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;

            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if(other.gameObject.tag == "WallBottom")
        {
            Destroy(other.gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().PlayerDied();
            Debug.Log("Game Over");
        }
    }
}
