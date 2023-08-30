using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alternateGravityScript : MonoBehaviour
{
    public PassaroScript passaro;
    public LogicScript logic;
    public float inicialGravityScale;
    public float inicialFlapStrength;
    private bool startCourotineOn = true;

    // Start is called before the first frame update
    void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("passaro").GetComponent<PassaroScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        inicialGravityScale = passaro.myRigidBody.gravityScale;
        inicialFlapStrength = passaro.flapStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.isAlternateGravityActive && passaro.birdIsAlive && startCourotineOn)
        {
            StartCoroutine(alternateGravityActive());
            startCourotineOn = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && logic.isAlternateGravityActive && passaro.birdIsAlive)
        {
            passaro.myRigidBody.gravityScale *= -1;       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (passaro.birdIsAlive && !logic.isAlternateGravityActive)
        {
            logic.isAlternateGravityActive = true;
            passaro.flapStrength = 0;
            passaro.myRigidBody.gravityScale = 2.5f;
            passaro.myRigidBody.gravityScale *= -1;
        }

    }

    public IEnumerator alternateGravityActive()
    {
        yield return new WaitForSeconds(logic.itemCooldown);
        passaro.myRigidBody.gravityScale = inicialGravityScale;
        passaro.flapStrength = inicialFlapStrength;
        logic.isAlternateGravityActive = false;
        startCourotineOn = true;
    }
}
