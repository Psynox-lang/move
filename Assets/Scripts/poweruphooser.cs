using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweruphooser : MonoBehaviour
{
    public int powerupelement;
     public List<GameObject> element = new List<GameObject>();
    public void powerupchange(int power)
    {   
        //swicth all powerupoff
        powerupelement=power;
        element[0].SetActive(false);
        element[1].SetActive(false);
        element[2].SetActive(false);
        element[3].SetActive(false);
        switch(power)
        {
            case 0:
            //do fire;
            Debug.Log("fire");
            element[0].SetActive(true);
            break;
            case 1:
            Debug.Log("water");
            element[1].SetActive(true);
            break;
            case 2:
            Debug.Log("ground");
            element[2].SetActive(true);
            break;
            case 3:
            Debug.Log("air");
            element[3].SetActive(true);
            break;
        }
    }
}
