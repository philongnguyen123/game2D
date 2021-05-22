using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float forceX = 300f;
    public float Speed = 1f;
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

    
    // Update is called once per frame
    void FixedUpdate()
    {
        //move();
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        forceX = Random.Range(-1f, 1f);
        myBody.AddForce(new Vector2(forceX, 0));
        StartCoroutine(Attack());

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().PlayerDied();
            Debug.Log("Game Over");
        }
    }

    void move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * Speed;
    }
}
