using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    public pipeSpawnScript pipeSpawn;
    public LogicScript logic;
    public float moveSpeed;
    public float deadZone = -45;

    // Start is called before the first frame update
    void Start()
    {
        pipeSpawn = GameObject.FindGameObjectWithTag("pipe").GetComponent<pipeSpawnScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pipeSpawn.isSecondRound) 
        {
            moveSpeed = 12;
        }
        else if (pipeSpawn.isThirdRound) 
        {
            moveSpeed = 14;
        }
        else if (pipeSpawn.isFourthRound)
        {
            moveSpeed = 16;
        }
        else if (pipeSpawn.isFifthRound)
        {
            moveSpeed = 20;
        }
        else
        {
            moveSpeed = 10;
        }

        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
