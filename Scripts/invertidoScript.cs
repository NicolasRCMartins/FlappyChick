using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invertidoScript : MonoBehaviour
{
    public pipeSpawnScript pipeSpawn;
    public PassaroScript passaro;
    public LogicScript logic;
    public Matrix4x4 mat;

    // Start is called before the first frame update
    void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("passaro").GetComponent<PassaroScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawn = GameObject.FindGameObjectWithTag("pipe").GetComponent<pipeSpawnScript>();
        mat = Camera.main.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isInvertedActive && passaro.birdIsAlive)
        {
            mat *= Matrix4x4.Scale(new Vector3(1, -1, 1));
            Camera.main.projectionMatrix = mat;
            logic.isInvertedActive = false;
            StartCoroutine(invertedActive());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (passaro.birdIsAlive && !logic.isInvertedActive)
        {
            logic.isInvertedActive = true;
        }

    }

    public IEnumerator invertedActive()
    {
        yield return new WaitForSeconds(logic.itemCooldown);
        mat *= Matrix4x4.Scale(new Vector3(1, -1, 1));
        Camera.main.projectionMatrix = mat;
    }
}
