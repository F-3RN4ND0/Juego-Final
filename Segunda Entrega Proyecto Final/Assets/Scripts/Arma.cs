using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour
{
    public float range = 100;

    public Camera fpsCamera;

    public AudioSource _audioSor;
    public AudioClip _clipDisparo;
    public AudioClip _clipRecarga;
    public AudioClip _clipDisparoCabeza;
    public AudioClip _clipHitMarker;

    public Animator animacion;
    public AudioClip sinMunicion;
    public static int municion ;
    public int maxAmmo = 25;
    public float tiempoRecarga = 1.5f;
    public float damage = 25f;
    public float headDamage = 100f;
    public GameObject bloodEffect;
    public GameObject bloodHeadShotEffect;
    //public ParticleSystem muzzleFlash;

    private bool estaRecargando = false;
    private bool estaDisparando = false;
    public float shootRate = 0.15f;
    public float shootRateTime = 0;

    public static int kills = 0;
    void Start()
    {
        municion = maxAmmo;
    }

    void Update()
    {
        if (estaRecargando)
            return;

        if (estaDisparando)
            return;

        if (estaDisparando == false)
            animacion.SetBool("Disparando", false);

        if (Input.GetMouseButton(0))
        {
            if (Time.time > shootRateTime && municion > 0)
            {
                Disparar();
                municion -= 1;
                shootRateTime = Time.time + shootRate;
            }


            if (Input.GetMouseButtonDown(0) && municion <= 0)
            {
                AudioSource.PlayClipAtPoint(sinMunicion, gameObject.transform.position);
                Destroy(_audioSor);
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (municion >= 0 && municion <= 24)
            { 
                Debug.Log("Recargando");
                StartCoroutine(Recargar());
                return;
            }
        }
    }
    
    void Disparar()
    {
        estaDisparando = true;
        animacion.SetBool("Disparando", true);
        //muzzleFlash.Play();
        RaycastHit hit;
        AudioSource.PlayClipAtPoint(_clipDisparo, gameObject.transform.position);
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Enemigo zombie = hit.transform.GetComponent<Enemigo>();
            Enemigo head = hit.transform.GetComponentInParent<Enemigo>();
            if (hit.transform.tag == "Zombie")
            {
                if (zombie != null)
                {
                    zombie.TakeDamage(damage);
                    AudioSource.PlayClipAtPoint(_clipHitMarker, gameObject.transform.position);
                    GameObject copyBloodEffect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(copyBloodEffect, 2f);
                    
                    if (zombie.vidaEnemigo <= 0)
                        kills++;
                }
            }
            else if (hit.transform.tag == "Head")
            {
                head.TakeDamage(headDamage);
                AudioSource.PlayClipAtPoint(_clipHitMarker, gameObject.transform.position);

                if (head.vidaEnemigo <= 0)
                {
                    AudioSource.PlayClipAtPoint(_clipDisparoCabeza, gameObject.transform.position);
                    GameObject copyBloodHeadShotEffect = Instantiate(bloodHeadShotEffect, hit.point, transform.rotation);
                    Destroy(copyBloodHeadShotEffect, 4f);
                    kills++;
                }
            }
        }
        estaDisparando = false;
    }

    IEnumerator Recargar()
    {
        estaRecargando = true;
        animacion.SetBool("Recargando", true);
        AudioSource.PlayClipAtPoint(_clipRecarga, gameObject.transform.position);
        yield return new WaitForSeconds(tiempoRecarga);
        animacion.SetBool("Recargando", false);
        municion = maxAmmo;
        estaRecargando = false;
    }

}