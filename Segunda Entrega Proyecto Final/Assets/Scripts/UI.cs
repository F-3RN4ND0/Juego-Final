using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text textoKills;
    public Text textoMunicion;
    public GameObject jugador;
    public GameObject camara2;

    public bool pauseActive;
    public GameObject pauseMenu;

    public AudioSource _audSource;

    public bool finJuego = false;
    void Awake()
    {
        _audSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        textoKills.text = $"Kills: {Arma.kills} de 20";
        textoMunicion.text =  $"Åá|{Arma.municion}";
        
        TogglePause();
        ToggleEscape();

        if (Arma.kills == 20)
        
        {
            jugador.gameObject.SetActive(false);
            camara2.SetActive(true);
            WinManager.winManager.CallWin();
            finJuego = true;
            Arma.kills = 0;
        }
    }
    public void ToggleEscape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
    public void TogglePause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (pauseActive)
            {
                ResumeGame();
            }
            else
                PauseGame();
        }
    }

    

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        pauseActive = true;
    }

    
}
