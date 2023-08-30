using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public string screenName;
    public GameObject menuConfiguracoes;
    public volumeManagerScript volManager;
    public fullscreenScript fullscreen;

    private void Start()
    {
        volManager = GameObject.FindGameObjectWithTag("volume").GetComponent<volumeManagerScript>();
        fullscreen = GameObject.FindGameObjectWithTag("fullscreen").GetComponent <fullscreenScript>();
    }
    public void playGame()
    {
        screenName = "ScreenTutorial";
        FindObjectOfType<AudioManager>().Play("clickButton");
        StartCoroutine (delayGame(screenName));
    }

    public void returnGame()
    {
        screenName = "ScreenInicial";
        FindObjectOfType<AudioManager>().Play("clickButton");
        StartCoroutine (delayGame(screenName));
    }

    public void configSettings()
    {
        FindObjectOfType<AudioManager>().Play("clickButton");
        menuConfiguracoes.SetActive(true);
    }

    public void configCloseButton()
    {
        float volumeValue = volManager.volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        volManager.LoadValues();

        int fullscreenValue = fullscreen.contador;
        PlayerPrefs.SetInt("fullscreenValue", fullscreenValue);
        fullscreen.LoadValues();

        FindObjectOfType<AudioManager>().Play("clickButton");
        menuConfiguracoes.SetActive(false);
    }

    public void buttonQuit()
    {
        FindObjectOfType<AudioManager>().Play("clickButton");
        StartCoroutine (delayQuit());
    }

    public IEnumerator delayGame(string screenName)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(screenName);
    }

    public IEnumerator delayQuit()
    {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }
}
