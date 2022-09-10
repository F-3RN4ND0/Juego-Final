using UnityEngine.SceneManagement;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 3f;
    public float runSpeed = 3.2f;
    public float rotationSpeed = 0.5f;
    public Vector3 rotationInput = Vector3.zero;
    public Rigidbody _rigidb;

    public float sensibilidadMouse = 200;
    public float xRotacion;
    public float yRotacion;
    public Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        MovimientoJugador();
    }
    void Update()
    {
        MouseLook();

    }
    void MovimientoJugador()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        bool correrConShift = Input.GetKey(KeyCode.LeftShift);
        Vector3 movementDirection = new Vector3(hor, 0, ver);
        movementDirection.Normalize();
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1f);
        _rigidb.MovePosition(_rigidb.position + (transform.TransformDirection(movementDirection) * speed * Time.fixedDeltaTime));
        bool caminar = movementDirection == Vector3.zero;

        if (correrConShift && !caminar)
        {
            _rigidb.MovePosition(_rigidb.position + (transform.TransformDirection(movementDirection) * runSpeed * Time.fixedDeltaTime));
        }
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -45, 60);
        yRotacion += mouseX;
        cam.localRotation = Quaternion.Euler(xRotacion, yRotacion, 0);
        yRotacion = Mathf.Clamp(yRotacion, -5, 5);
    }
    
}
