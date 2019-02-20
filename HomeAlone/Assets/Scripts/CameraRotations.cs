using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class CameraRotations : MonoBehaviour
{
    public Camera cam;

    private float sensitivityX = 0.5F;
    private float sensitivityY = 0.5F;

    private float minimumX = -5F;
    private float maximumX = 5F;

    private float minimumY = -25F;
    private float maximumY = 25F;

    float rotationY = 0f;
    float rotationX = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update() {

        rotationY += Input.GetAxis("Horizontal") * sensitivityY;
        rotationX += Input.GetAxis("Vertical") * sensitivityX;

        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}