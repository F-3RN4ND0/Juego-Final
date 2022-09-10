using UnityEngine;
public class ManagerSonido : MonoBehaviour
{
    public static ManagerSonido unicaInstancia;
    public AudioSource _audSource;
    public AudioClip cancionFinal;
    void Awake()
    {
        if (ManagerSonido.unicaInstancia == null)
        {
            ManagerSonido.unicaInstancia = this;

            DontDestroyOnLoad(gameObject);

            _audSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Arma.kills == 20 || ControlVida.vida <= 0)
        {
            _audSource.Pause();
            AudioSource.PlayClipAtPoint(cancionFinal, this.transform.position); 
        }
    }

    public static void Pausar()
    {
        unicaInstancia._audSource.Pause();
    }
    public static void Despausar()
    {
        unicaInstancia._audSource.UnPause();
    }
}
