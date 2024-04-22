using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class SpillerMovementScript : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public GameObject objekt;
    public Transform orientation;
    public Rigidbody rb;
    Vector3 moveDirection;
    public float moveSpeed;
    public float hoppeKraft;
    public bool hidden;
    public bool kanHoppe;
    public GameObject vignette;
    public GameObject sus;
    public float ventetid;
    public GameObject txt1;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        hidden = false;
        vignette.SetActive(false);
        StartCoroutine(starting());
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.Escape))
        {
            SusDrop();
        }
      */
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDirection = orientation.forward * -vertical + orientation.right * horizontal;
        rb.AddForce(moveDirection.normalized * moveSpeed * Time.deltaTime, ForceMode.Force);
        if (hidden)
        {
            objekt.layer = 8;
        }
        else
        {
            objekt.layer = 6;
        }
        if (kanHoppe && grounded)
        {
            if (Input.GetButtonDown("Interact"))
            {
                rb.AddForce(0, hoppeKraft, 0);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
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
    IEnumerator starting()
    {
        txt1.SetActive(true);
        yield return new WaitForSeconds(ventetid);
        txt1.SetActive(false);
    }
}
