using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraScript : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    bool mus;
    float mouseX;
    float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetAxis("joy x")+Input.GetAxis("joy y") != 0)
        {
            mus = false;
        }
        else
        {
            mus = true;
        }
        transform.position = orientation.position;
        if (!mus)
        {
            mouseX = Input.GetAxisRaw("joy x") * Time.deltaTime * sensX;
            mouseY = Input.GetAxisRaw("joy y") * Time.deltaTime * sensY;
        }
        else
        {
            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        }

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
