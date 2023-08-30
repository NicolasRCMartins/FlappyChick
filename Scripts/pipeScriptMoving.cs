using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScriptMoving : MonoBehaviour
{
    public pipeSpawnScript pipeSpawn;
    private float ceil = 20;
    private float floor = 10;
    private float velocityUpPipe = 2;
    private bool secondRoundBool = true;
    private bool thirdRoundBool = true;
    private bool fourthRoundBool = true;
    private bool fifthRoundBool = true;

    // Start is called before the first frame update
    void Start()
    {
        pipeSpawn = GameObject.FindGameObjectWithTag("pipe").GetComponent<pipeSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * velocityUpPipe) * Time.deltaTime;

        if (pipeSpawn.isSecondRound && secondRoundBool)
        {
            velocityUpPipe = 4;
            secondRoundBool = false;
        }
        else if (pipeSpawn.isThirdRound && thirdRoundBool)
        {
            velocityUpPipe = 6;
            thirdRoundBool = false;
        }
        else if (pipeSpawn.isFourthRound && fourthRoundBool)
        {
            velocityUpPipe = 8;
            fourthRoundBool = false;
        }
        else if (pipeSpawn.isFifthRound && fifthRoundBool)
        {
            velocityUpPipe = 10;
            fifthRoundBool = false;
        }

        if (transform.position.y >= ceil || transform.position.y <= floor)
        {
            velocityUpPipe *= -1;
        }
    }
}
