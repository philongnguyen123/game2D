using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Door.instance != null)
        {
            Door.instance.collecTablesCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameController.sInstance.UpdateScore();

            if(Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
        }
    }
    void Update()
    {

    }
}
