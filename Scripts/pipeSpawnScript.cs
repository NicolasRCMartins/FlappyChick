using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour 
{
    public GameObject shortPipe;
    public GameObject shortPipeMoving;
    public GameObject pipe;
    public GameObject pipeMoving;
    public GameObject relogio;
    public GameObject inverted;
    public GameObject highGravity;
    public GameObject alternated;
    public GameObject shortPipeItemAsset;
    public pipeScript pipeScript;
    public LogicScript logic;
    public float spawnRate = 1.5f;
    public float timer = 0;
    public float lowestPoint;
    public float highestPoint;
    public float randomPoint;
    private float heightOffSet = 5;
    public bool isSecondRound;
    public bool isThirdRound;
    public bool isFourthRound;
    public bool isFifthRound;
    public int randomChanceOfTypeOfPipe;
    public int randomChanceOfTypeOfItem;
    public int movingPipe = 1;
    public int relogioItem = 1;
    public int invertedItem = 2;
    public int highGravityItem = 3;
    public int alternatedItem = 4;
    public int shortPipeItem = 5;
    public bool isInvertedSpawnable = true;
    public bool isRelogioSpawnable = true;
    public bool isHighGravitySpawnable = true;
    public bool isAlternatedSpawnable = true;
    public bool isShortPipeSpawnable = true;
    private float timerInverted = 0f;
    private float timerRelogio = 0f;
    private float timerHighGravity = 0f;
    private float timerAlternated = 0f;
    private float timerShortPipe = 0f;
    public bool isShortPipeEnabled = false;
    public bool isPipeSpawnable = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if(isPipeSpawnable) 
        {
            if(logic.playerScore >= 10 && logic.playerScore < 25)
            {
                secondRound();
                timer = 0;
                spawnPipe();
            }
            else if(logic.playerScore >= 25 && logic.playerScore < 50)
            {
                thirdRound();
                timer = 0;
                spawnPipe();
            }
            else if(logic.playerScore >= 50 && logic.playerScore < 100)
            {
                fourthRound();
                timer = 0;
                spawnPipe();
            }
            else if(logic.playerScore >= 100)
            {
                fifthRound();
                timer = 0;
                spawnPipe();
            }
            else
            {
                timer = 0;
                spawnPipe();
            }
        }

        relogioFunction();
        invertedFunction();
        highGravityFunction();
        alternatedFunction();
        shortPipeFunction();
    }

    public void spawnPipe()
    {
        if (!isShortPipeEnabled)
        {
            lowestPoint = transform.position.y - heightOffSet;
            highestPoint = transform.position.y + heightOffSet;
            randomPoint = Random.Range(lowestPoint, highestPoint);
            randomChanceOfTypeOfPipe = Random.Range(1, 4);
            randomChanceOfTypeOfItem = Random.Range(1, 11);

            if (randomChanceOfTypeOfPipe == movingPipe)
            {
                Instantiate(pipeMoving, new Vector3(transform.position.x, randomPoint, 0), transform.rotation);
            }
            else 
            {
                Instantiate(pipe, new Vector3(transform.position.x, randomPoint, 0), transform.rotation);

                if(randomChanceOfTypeOfItem == relogioItem && isRelogioSpawnable)
                {
                    Instantiate(relogio, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isRelogioSpawnable = false;
                }
                else if(randomChanceOfTypeOfItem == invertedItem && isInvertedSpawnable)
                {
                    Instantiate(inverted, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isInvertedSpawnable = false;
                }
                else if(randomChanceOfTypeOfItem == highGravityItem && isHighGravitySpawnable)
                {
                    Instantiate(highGravity, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isHighGravitySpawnable = false;
                }
                else if(randomChanceOfTypeOfItem == alternatedItem && isAlternatedSpawnable)
                {
                    Instantiate(alternated, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isAlternatedSpawnable = false;
                }
                else if(randomChanceOfTypeOfItem == shortPipeItem && isShortPipeSpawnable)
                {
                    Instantiate(shortPipeItemAsset, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isShortPipeSpawnable = false;
                }
            }
        }

        else
        {
            heightOffSet = 2;
            lowestPoint = transform.position.y - heightOffSet;
            highestPoint = transform.position.y + heightOffSet;
            randomPoint = Random.Range(lowestPoint, highestPoint);
            randomChanceOfTypeOfPipe = Random.Range(1, 4);
            randomChanceOfTypeOfItem = Random.Range(1, 11);

            if (randomChanceOfTypeOfPipe == movingPipe)
            {
                Instantiate(shortPipeMoving, new Vector3(transform.position.x, randomPoint, 0), transform.rotation);
            }
            else
            {
                Instantiate(shortPipe, new Vector3(transform.position.x, randomPoint, 0), transform.rotation);

                if (randomChanceOfTypeOfItem == relogioItem && isRelogioSpawnable)
                {
                    Instantiate(relogio, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isRelogioSpawnable = false;
                }
                else if (randomChanceOfTypeOfItem == invertedItem && isInvertedSpawnable)
                {
                    Instantiate(inverted, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isInvertedSpawnable = false;
                }
                else if (randomChanceOfTypeOfItem == highGravityItem && isHighGravitySpawnable)
                {
                    Instantiate(highGravity, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isHighGravitySpawnable = false;
                }
                else if (randomChanceOfTypeOfItem == shortPipeItem && isShortPipeSpawnable)
                {
                    Instantiate(shortPipeItemAsset, new Vector3(transform.position.x, randomPoint - 19, 0), transform.rotation);
                    isShortPipeSpawnable = false;
                }
            }
        }
    }

    void secondRound()
    {
        spawnRate = 1.25f;
        isSecondRound = true;
    }

    void thirdRound()
    {
        spawnRate = 1.07f;
        isThirdRound = true;
        isSecondRound = false;
    }

    void fourthRound()
    {
        spawnRate = 0.94f;
        isFourthRound = true;
        isThirdRound= false;
    }

    void fifthRound()
    {
        spawnRate = 0.75f;
        isFifthRound = true;
        isFourthRound = false;
    }

    void invertedFunction()
    {
        if (!isInvertedSpawnable)
        {
            timerInverted += Time.deltaTime;
        }

        if (timerInverted >= logic.itemCooldown + 2f)
        {
            isInvertedSpawnable = true;
            timerInverted = 0f;
        }
    }

    void relogioFunction()
    {
        if (!isRelogioSpawnable)
        {
            timerRelogio += Time.deltaTime;
        }

        if (timerRelogio >= logic.itemCooldown + 2f)
        {
            isRelogioSpawnable = true;
            timerRelogio = 0f;
        }
    }

    void highGravityFunction()
    {
        if (!isHighGravitySpawnable)
        {
            timerHighGravity += Time.deltaTime;
        }

        if (timerHighGravity >= logic.itemCooldown + 2f)
        {
            isHighGravitySpawnable = true;
            timerHighGravity = 0f;
        }
    }

    void alternatedFunction()
    {
        if (!isAlternatedSpawnable)
        {
            timerAlternated += Time.deltaTime;
        }

        if (timerAlternated >= logic.itemCooldown + 2f)
        {
            isAlternatedSpawnable = true;
            timerAlternated = 0f;
        }
    }

    void shortPipeFunction()
    {
        if (!isShortPipeSpawnable)
        {
            timerShortPipe += Time.deltaTime;
        }

        if (timerShortPipe >= logic.itemCooldown + 2f)
        {
            isShortPipeSpawnable = true;
            timerShortPipe = 0f;
        }
    }
}
