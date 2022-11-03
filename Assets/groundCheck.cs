using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public GameObject car;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ground")   car.GetComponent<carGOBRRRR>().isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground") car.GetComponent<carGOBRRRR>().isGrounded = false;
    }
}
