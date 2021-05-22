using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Destroy(other.gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().PlayerDied();
            Debug.Log("Game Over");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
