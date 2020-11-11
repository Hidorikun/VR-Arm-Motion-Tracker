using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleInteraction : MonoBehaviour
{

    public float force = 200.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag != "Paddle")
            return;
        
        ContactPoint contact = collision.contacts[0];

        // Rotate the object so that the y-axis faces along the normal of the surface
        //force = collision.other.GetComponentInParent<HandTracking>().force;

        //Debug.Log("shot with " + force); 
        //gameObject.GetComponent<Rigidbody>().AddForce(contact.normal * force);
    }
    
}
