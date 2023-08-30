using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
    public PassaroScript passaro;
    public LogicScript logic;
    public pipeSpawnScript pipeSpawn;
    private float movementAnimation = 1;
    public float timerItem = 0;
    public float itemSpeed = 10;
    private float deadzone = -15000f;

    void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("passaro").GetComponent<PassaroScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawn = GameObject.FindGameObjectWithTag("pipe").GetComponent<pipeSpawnScript>();
    }

    void Update()
    {
        timerItem += Time.deltaTime;

        if (pipeSpawn.isSecondRound)
        {
            itemSpeed = 12;
        }
        else if (pipeSpawn.isThirdRound)
        {
            itemSpeed = 14;
        }
        else if (pipeSpawn.isFourthRound)
        {
            itemSpeed = 16;
        }
        else if (pipeSpawn.isFifthRound)
        {
            itemSpeed = 20;
        }
        else
        {
            itemSpeed = 10;
        }

        transform.position = transform.position + (Vector3.left * itemSpeed) * Time.deltaTime;

        if (timerItem < 1f)
        {
            transform.position = transform.position + (Vector3.up * movementAnimation) * Time.deltaTime;
        }
        else if (timerItem >= 1f &&  timerItem < 2f)
        {
            transform.position = transform.position - (Vector3.up * movementAnimation) * Time.deltaTime;
        }
        else {
            timerItem = 0;
        }

        if(transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (passaro.birdIsAlive)
        {
            Destroy(gameObject);
        }
    }
}
