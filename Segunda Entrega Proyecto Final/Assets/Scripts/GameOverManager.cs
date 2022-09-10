using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject HUD;
    public GameObject BarraVida;
    public AudioSource _audSource;
    public AudioClip cancionFinal;
    public Transform Camara2;
    public static GameOverManager gameOverManager;
    void Awake()
    {
        gameOverManager = this;
        _audSource = GetComponent<AudioSource>();
    }

    public void CallGameOver()
    {
        GameOver.SetActive(true);
        HUD.SetActive(false);
        BarraVida.SetActive(false);
        AudioSource.PlayClipAtPoint(cancionFinal, Camara2.transform.position);
        Time.timeScale = 0;
    }
}
