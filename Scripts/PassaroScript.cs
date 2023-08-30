using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PassaroScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 20f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidBody.velocity = Vector2.up * flapStrength;
        FindObjectOfType<AudioManager>().Play("flapWings");
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            FindObjectOfType<AudioManager>().Play("flapWings");
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        if (myRigidBody.position.y >= 20 || myRigidBody.position.y <= -28)
        {
            logic.highScore = PlayerPrefs.GetInt("highScore");
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("crashHit");
        logic.gameOver();
        birdIsAlive = false;
    }
}
