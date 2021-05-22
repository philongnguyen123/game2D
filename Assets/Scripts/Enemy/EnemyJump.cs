using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float forceY = 300f;
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
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        forceY = Random.Range(250f, 400f);
        myBody.AddForce(new Vector2(0, forceY));

        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Attack());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().PlayerDied();
            Debug.Log("Game Over");
        }

        if(collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
