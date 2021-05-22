using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public float minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.y = player.position.y;
            if(temp.y > minY)
            {
                temp.y = minY;
            }

            if(temp.y < maxY)
            {
                temp.y = maxY;
            }
            transform.position = temp;
        }
    }
}
