using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightRotatoin : MonoBehaviour
{
    private float sensitivityX = 0.5F;
    private float sensitivityY = 0.5F;

    private float minimumX = -70F;
    private float maximumX = 70F;

    private float minimumY = -70F;
    private float maximumY = 70F;

    float rotationY = 0f;
    float rotationX = 0f;


    public GameObject flashLight;
    

    void Start()
    {
        //rsor.lockState = CursorLockMode.Locked;
        
    }
    void Update()
    {

        rotationY += Input.GetAxis("Mouse X") * sensitivityY;
        rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        flashLight.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);


      
    }
}
