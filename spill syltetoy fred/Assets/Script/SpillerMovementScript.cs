using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpillerMovementScript : MonoBehaviour
{
    float horizontal;
    float vertical;
    public Transform orientation;
    public Rigidbody rb;
    Vector3 moveDirection;
    public float moveSpeed;
    public bool hidden;
    public GameObject vignette;

    // Start is called before the first frame update
    void Start()
    {
        hidden = false;
        vignette.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        rb.AddForce(moveDirection.normalized * moveSpeed * Time.deltaTime, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hidingspot")
        {
            hidden = true;
            vignette.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "hidingspot")
        {
            hidden = false;
            vignette.SetActive(false);
        }
    }
}
