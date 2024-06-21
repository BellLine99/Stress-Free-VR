using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cshWeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] destructible_objects;
    public GameObject obj_pos;
    private int state = 0;
    private Vector3 planeSize;
    private Vector3 planeCenter;

    public GameObject crtMon;
    public Transform crtPos;

    void Start()
    {   
        // To Calc Obj Pos with Plane
        planeSize = obj_pos.GetComponent<Renderer>().bounds.size;
        planeCenter = obj_pos.transform.position;




    }

    void Update()
    {
        // A버튼 (무기변경)
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            state = (state + 1) % 3;

            switch (state)
            {
                case 0:
                    weapons[0].SetActive(false);
                    weapons[1].SetActive(false);
                    break;
                case 1:
                    weapons[0].SetActive(true);
                    weapons[1].SetActive(false);
                    break;
                case 2:
                    weapons[0].SetActive(false);
                    weapons[1].SetActive(true);
                    break;
            }
        }
    }

    public void createObject()
    {
        Vector3 randomPosition = new Vector3(
                Random.Range(planeCenter.x - planeSize.x / 2, planeCenter.x + planeSize.x / 2),
                planeCenter.y,
                Random.Range(planeCenter.z - planeSize.z / 2, planeCenter.z + planeSize.z / 2)
            );
        int randomIndex = Random.Range(0, destructible_objects.Length);
        GameObject instantiatedObject = Instantiate(destructible_objects[randomIndex], randomPosition, Quaternion.identity);
    }

    public void createCRT()
    {

        Destroy(GameObject.Find("CRTMonitor"));

        GameObject instantiatedObject = Instantiate(crtMon, crtPos.position, crtPos.rotation);
    }

}
