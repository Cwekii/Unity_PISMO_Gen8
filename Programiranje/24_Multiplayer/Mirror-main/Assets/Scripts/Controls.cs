using UnityEngine;
using Mirror;

public class Controls : NetworkBehaviour
{
    public float speed, horizontalSpeed;
    public Canvas canvas;


    private Camera cam;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();

        if (!isLocalPlayer)
        {
            Destroy(cam.gameObject);
            canvas.gameObject.SetActive(false);
        }
        else
        {
            Invoke("LockMouse", 2);
        }
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // exit from update if this is not the local player
        if (!isLocalPlayer) return;

        // handle player input for movement
        CheckInputs();
        CheckRotation();
    }

    private void CheckRotation()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }

    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.W)) /*Cmd_*/MoveForward();
        if (Input.GetKey(KeyCode.A)) /*Cmd_*/StrifeLeft();
        if (Input.GetKey(KeyCode.D)) /*Cmd_*/StrifeRight();
        if (Input.GetKey(KeyCode.S)) /*Cmd_*/MoveBackwards();

    }
   
    //[Command(requiresAuthority = false)]
    private void /*Cmd_*/MoveBackwards()
    {
        transform.position -= transform.forward * Time.deltaTime * speed;
    }

    //[Command(requiresAuthority = false)]
    private void /*Cmd_*/StrifeRight()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    //[Command(requiresAuthority = false)]
    private void /*Cmd_*/StrifeLeft()
    {
        transform.position -= transform.right * Time.deltaTime * speed;
    }

    //[Command(requiresAuthority = false)]
    private void /*Cmd_*/MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
