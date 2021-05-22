using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public static Door instance;

    private Animator anim;
    private BoxCollider2D box;


    [HideInInspector] public int collecTablesCount;
    void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DecrementCollectables()
    {
        collecTablesCount--;

        if(collecTablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor(){
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Application.LoadLevel("LevelMenu");

            Debug.Log("Finish");
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
