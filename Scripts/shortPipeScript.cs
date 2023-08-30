using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortPipeScript : MonoBehaviour
{
    public pipeSpawnScript pipeSpawn;
    public PassaroScript passaro;
    public LogicScript logic;
    private bool isPipeShortCoroutineOn = true;

    void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("passaro").GetComponent<PassaroScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawn = GameObject.FindGameObjectWithTag("pipe").GetComponent<pipeSpawnScript>();
    }

    void Update()
    {
        if (isPipeShortCoroutineOn && logic.isShortPipe)
        {
            StartCoroutine(shortPipe());
            isPipeShortCoroutineOn = false;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (passaro.birdIsAlive && !logic.isShortPipe)
        {
            pipeSpawn.isShortPipeEnabled = true;
            logic.isShortPipe = true;
        }
    }

    public IEnumerator shortPipe()
    {
        yield return new WaitForSeconds(logic.itemCooldown);
        pipeSpawn.isShortPipeEnabled = false;
        logic.isShortPipe = false;
        isPipeShortCoroutineOn = true;
    }
}
