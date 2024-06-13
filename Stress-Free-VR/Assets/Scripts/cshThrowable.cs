using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class cshThrowable : MonoBehaviour
{
    List<Vector3> trackingPos = new List<Vector3>();
    public float velocity = 1000f;

    bool pickedUp = false;
    GameObject parentHand;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp == true)
        {
            rb.useGravity = false;

            if(trackingPos.Count > 15 )
            {
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position);

            float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

            if(triggerRight < 0.1f)
            {
                pickedUp = false;
                Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
                rb.AddForce(direction * velocity);
                rb.useGravity = true;
                rb.isKinematic = false;
                GetComponent<Collider>().isTrigger = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        if (collision.gameObject.tag == "Controller" && triggerRight > 0.9f)
        {
            pickedUp = true;
            parentHand = collision.gameObject;
        }
    }
}
