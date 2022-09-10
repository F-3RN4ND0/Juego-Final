using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVida : MonoBehaviour
{
    public static float vida =100f;
    public float vidaActual = 100f;
    public float maxVida = 100f;
    public Image barraVida;
    public GameObject jugador;
    public GameObject camara2;
    public float tiempoDeEspera = 5;
    public bool recibioDano = false;

    private void Awake()
    {
        vidaActual = 100f;
    }
    void Start()
    {
        camara2.SetActive(false);
    }

    void Update()
    {
        ActualizarVida();
        RecuperarVida();

    }

    void ActualizarVida()
    {
        barraVida.fillAmount = vidaActual / maxVida;
        //barraVida.color = new Color(255, 255, 255, vidaActual/maxVida);
        vida = vidaActual;
    }

    void RecuperarVida()
    {
        if (!recibioDano && vidaActual < 100)
        {
            Invoke("Curacion", 6);
        }
    }

    public void RecibirDano(float dano)
    {
        recibioDano = true;
        vidaActual -= dano;
        Invoke("EsperarCuracion", 6);
        if (vidaActual < 0)
        {
            vidaActual = 0;
        }

        if (vidaActual <= 0)
        {
            Enemigo.playerisDead = true;
            GameOverManager.gameOverManager.CallGameOver();
            jugador.gameObject.SetActive(false);
            camara2.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Curacion()
    {
        if (vidaActual < 100)
        {
            vidaActual++;
        }
    }

    void EsperarCuracion()
    {
        recibioDano = false;
    }
}
