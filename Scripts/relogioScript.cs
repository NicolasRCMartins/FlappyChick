using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relogioScript : MonoBehaviour
{
    [Range(0.1f, 2)]
    private float modifiedScale = 1;
    public PassaroScript passaro;
    public LogicScript logic;
    public pipeSpawnScript pipeSpawn;
    public passaroBody pBody;
    public passaroWing pWing;
    private float inicialPassaroGravity;
    private float inicialFlapStrength;
    private float inicialCooldownBody;
    private float inicialCooldownWing;

    private void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("passaro").GetComponent<PassaroScript>();
        pBody = GameObject.FindGameObjectWithTag("passaroBody").GetComponent<passaroBody>();
        pWing = GameObject.FindGameObjectWithTag("passaroWing").GetComponent<passaroWing>();
        pipeSpawn = GameObject.FindGameObjectWithTag("pipe").GetComponent<pipeSpawnScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        inicialPassaroGravity = passaro.myRigidBody.gravityScale;
        inicialFlapStrength = passaro.flapStrength;
        inicialCooldownBody = pBody.cooldownBody;
        inicialCooldownWing = pWing.cooldownWing;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = modifiedScale;

        if (logic.isTimeActive && passaro.birdIsAlive)
        {
            modifiedScale = 0.5f;
            passaro.myRigidBody.gravityScale = 12;
            passaro.flapStrength = 36;
            pBody.cooldownBody = 0.2f;
            pWing.cooldownWing = 0.2f;
            StartCoroutine(timeActive());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (passaro.birdIsAlive)
        {
            logic.isTimeActive = true;
        }
    }

    public IEnumerator timeActive()
    {
        yield return new WaitForSeconds(logic.itemCooldown/2);
        modifiedScale = 1;
        passaro.myRigidBody.gravityScale = inicialPassaroGravity;
        passaro.flapStrength = inicialFlapStrength;
        pBody.cooldownBody = inicialCooldownBody;
        pWing.cooldownWing = inicialCooldownWing;
        logic.isTimeActive = false;
    }
}
