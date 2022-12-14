using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class carGOBRRRR : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float sensivity = 31; 
    [SerializeField] float speed = 10;
    public bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isGrounded)
            move();
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y * 2, transform.position.z);
            transform.Rotate(180, 0, 0);
        }

        if (Time.timeScale == 0.5f && Input.GetKeyDown(KeyCode.K)) Time.timeScale = 1;
        if (Time.timeScale == 1 && Input.GetKeyDown(KeyCode.K)) Time.timeScale = 0.5f;
    }

    void move()
    {
        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (rb.velocity.magnitude > 1)
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Horizontal") * sensivity, transform.eulerAngles.z), Time.deltaTime);
        if (Input.GetAxis("Vertical") == 0 && locVel.z > .1f) locVel.z -= speed * Time.deltaTime;
        if (locVel.z < .01f && locVel.z > -.01f && Input.GetAxis("Vertical") != 0) locVel.z = 0;
        rb.velocity = transform.TransformDirection(locVel);
    }
}