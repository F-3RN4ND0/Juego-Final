using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    public void RegresarAlMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
