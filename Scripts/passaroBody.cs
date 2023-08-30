using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class passaroBody : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public PassaroScript passaroScript;
    public float rotacao;
    public float cooldownBody = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        transform.Rotate(Vector3.forward, rotacao);
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && passaroScript.birdIsAlive)
        {
            transform.Rotate(Vector3.forward, rotacao);
            StartCoroutine(delay());
        }
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(cooldownBody);
        transform.Rotate(-Vector3.forward, rotacao);
    }

}

