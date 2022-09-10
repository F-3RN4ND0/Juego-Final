using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public int destroyTimer = 2;
    
    public void Awake()
    {
        Destroy(gameObject, destroyTimer);
    }
}
