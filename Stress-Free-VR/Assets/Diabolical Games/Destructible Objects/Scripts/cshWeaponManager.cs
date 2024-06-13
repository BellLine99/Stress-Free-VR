using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshWeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    private int state = 0;

    void Update()
    {
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
}
