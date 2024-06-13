using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshTest : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log("rb_new: " + rb.velocity.magnitude);
        Debug.Log("rb_new: " + rb.velocity.normalized);
    }
}
