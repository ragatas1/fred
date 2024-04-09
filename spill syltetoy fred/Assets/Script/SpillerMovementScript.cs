using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpillerMovementScript : MonoBehaviour
{
    float horizontal;
    float vertical;
    public GameObject objekt;
    public Transform orientation;
    public Rigidbody rb;
    Vector3 moveDirection;
    public float moveSpeed;
    public bool hidden;
    public GameObject vignette;
    public GameObject sus;

    // Start is called before the first frame update
    void Start()
    {
        hidden = false;
        vignette.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //SusDrop();
        //}
        //Trengte ikke disse midlertidlig ^^^^ så de er sånn her
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        rb.AddForce(moveDirection.normalized * moveSpeed * Time.deltaTime, ForceMode.Force);
        if (hidden)
        {
            objekt.layer = 8;
        }
        else
        {
            objekt.layer = 6;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hidingspot")
        {
            hidden = true;
            vignette.SetActive(true);
        }
        if (other.gameObject.tag == "syn")
        {
            Debug.Log("sett");
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
    public void SusDrop()
    {
        Instantiate(sus, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
    }
}
