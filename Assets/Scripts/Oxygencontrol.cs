using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygencontrol : MonoBehaviour
{
    public float playerYPosition;
    public float Oxygen = 100;
    public float OxygenTank = 20;

    [SerializeField]
    public Animator meter;

    [SerializeField]
    public Animator playerAnim;

    [SerializeField]
    GameObject player;

    private bool isUnderwater = false;

    // Start is called before the first frame update
    void Start()
    {
        //playerYPosition = transform.position.y - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        if(isUnderwater){
            Oxygen -= Time.deltaTime * 5;
        }

        if(Oxygen <= 0)
        {
            Oxygen = 0;
        }

        //player.get

        playerAnim.SetFloat("HP", Oxygen);
        meter.SetFloat("HP", Oxygen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Oxygentank")
        {
            Oxygen = Oxygen + OxygenTank;
            if(Oxygen > 100){
                Oxygen = 100;
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Underwater")
        {
            isUnderwater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Underwater")
        {
            isUnderwater = false;
            Oxygen = 100;
        }
    }
}
