using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject VictoryManager;
    public static WinManager winManager;
    public GameObject HUD;
    public AudioSource _audSource;
    public AudioClip cancionFinal;
    public Transform Camara2;
    void Awake()
    {
        winManager = this;
    }

    public void CallWin()
    {
        VictoryManager.SetActive(true);
        HUD.SetActive(false);
        AudioSource.PlayClipAtPoint(cancionFinal, Camara2.transform.position);
        Time.timeScale = 0;
        Invoke("Esperar4", 3.5f);
    }
    void Esperar4()
    {
        Time.timeScale = 0;
    }
}
