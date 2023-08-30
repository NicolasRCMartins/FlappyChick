using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreenScript : MonoBehaviour
{
    public GameObject textCheckButton;
    public int contador;

    private void Start()
    {
        LoadValues();
        CheckContador();
    }
    public void ChangeScreen()
    {
        contador += 1;
        CheckContador();
    }

    public void LoadValues()
    {
        int fullscreenValue = PlayerPrefs.GetInt("fullscreenValue");
        contador = fullscreenValue;
    }

    public void CheckContador()
    {
        if (contador % 2 != 0)
        {
            Screen.fullScreen = false;
            textCheckButton.SetActive(false);
        }
        else
        {
            Screen.fullScreen = true;
            textCheckButton.SetActive(true);
        }
    }
}
