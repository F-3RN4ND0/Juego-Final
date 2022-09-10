using UnityEngine;
using UnityEngine.AI;
public class Enemigo : MonoBehaviour
{
    public Transform posJugador;
    public NavMeshAgent IA;
    public float enemySpeed;
    public Animation Anim;
    public string AnimacionAtacar;
    public string AnimacionCaminar;
    public string AnimacionMuerte;
    public bool isDead = false;
    public static bool playerisDead = false;
    public float vidaEnemigo = 100f;
    public float danoEnemigo;
    public GameObject cabeza;
    void Start()
    {
        posJugador = GameObject.FindGameObjectWithTag("Player").transform;
        IA = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        IA.speed = enemySpeed;
        IA.destination = posJugador.position;

        if (IA.velocity == Vector3.zero)
        {
            Anim.CrossFade(AnimacionAtacar);
        }
        else
        {
            Anim.CrossFade(AnimacionCaminar);
        }
    }

    public void TakeDamage (float amount)
    {
        vidaEnemigo -= amount;
        if (vidaEnemigo <= 0f)
        {
            Die();
        }
    }
    public void Atacar()
    {
        if (Vector3.Distance(transform.position, posJugador.transform.position) <= 1.7)
        posJugador.GetComponent<ControlVida>().RecibirDano(danoEnemigo);
    }

    void Die()
    {
        isDead = true;
        Anim.CrossFade(AnimacionMuerte);
        IA.speed = 0;
        CapsuleCollider.Destroy(this);
        cabeza.SetActive(false);
        Destroy(this.gameObject,2.7f);
    }
} 