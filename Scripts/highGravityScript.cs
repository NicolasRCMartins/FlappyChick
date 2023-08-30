using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highGravityScript : MonoBehaviour
{
    public PassaroScript passaro;
    public LogicScript logic;
    public float highGravity = 2;

    // Start is called before the first frame update
    void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("passaro").GetComponent<PassaroScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isHighGravityActive && passaro.birdIsAlive)
        {
            passaro.myRigidBody.gravityScale *= highGravity;
            logic.isHighGravityActive = false;
            StartCoroutine(highGravityActive());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (passaro.birdIsAlive && !logic.isInvertedActive)
        {
            logic.isHighGravityActive = true;
        }
    }

    public IEnumerator highGravityActive()
    {
        yield return new WaitForSeconds(logic.itemCooldown);
        passaro.myRigidBody.gravityScale /= highGravity;
    }
}
