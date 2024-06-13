using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshChangeObject : MonoBehaviour
{
    public float forceAmount;
    public GameObject newPrefab;
    private Rigidbody rb_col;
    private Rigidbody rb_new;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {

            rb_col = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = rb_col.velocity;
            Debug.Log("rb_col: " + forceDirection);

            Destroy(gameObject);
            GameObject instantiatedObject = Instantiate(newPrefab, transform.position, Quaternion.identity);

            Debug.Log("rb_col: " + rb_col.velocity.magnitude);
            forceAmount = rb_col.velocity.magnitude * 30.0f;
            Debug.Log("forceAmount: " + forceAmount);
            foreach (Transform child in instantiatedObject.transform)
            {
                rb_new = child.gameObject.GetComponent<Rigidbody>();
                if (rb_new != null)
                {
                    rb_new.AddForce(forceDirection * forceAmount);
                    Debug.Log(rb_new.gameObject.name + ": " + rb_new.velocity.magnitude);
                    StartCoroutine(LogVelocityNextFrame(rb_new));
                }
            }
            //Debug.Log("rb_col: " + rb_col.velocity.magnitude);
        }
            
    }

    IEnumerator LogVelocityNextFrame(Rigidbody rb)
    {
        // Wait for the next frame
        yield return new WaitForEndOfFrame();

        // Then log the velocity
        Debug.Log(rb.gameObject.name + ": " + rb.velocity.magnitude);
    }
}
