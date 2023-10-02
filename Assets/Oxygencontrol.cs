using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygencontrol : MonoBehaviour
{
    public float playerYPosition;
    public float Oxygen = 100;
    public float OxygenTank = 20;
    // Start is called before the first frame update
    void Start()
    {
        playerYPosition = transform.position.y - 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerYPosition > transform.position.y){
            Oxygen -= Time.deltaTime;
        }
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
    }
}
