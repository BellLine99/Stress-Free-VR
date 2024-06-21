using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshExit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Application.Quit();
            Debug.Log("Exit");
        }
    }
}
