using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class passaroWing : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public Sprite newSprite;
    public Sprite oldSprite;
    public PassaroScript passaroScript;
    public float cooldownWing = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
        changeSprite();
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && passaroScript.birdIsAlive)
        {
            changeSprite();
            StartCoroutine(delay());
        }
    }

    public void changeSprite()
    {
        Sprite.sprite = newSprite;
    }

    public void returnSprite()
    {
        Sprite.sprite = oldSprite;
    }

    public IEnumerator delay()
    {
        yield return new WaitForSeconds(cooldownWing);
        returnSprite();
    }
}
