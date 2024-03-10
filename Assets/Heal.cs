using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int health = 100;
    public enemy en;
    public colourChangePortal cs;

public void increaseHelath(int shealth)
{
    health+=shealth;
}


public void decreaseHelath(int shealth)
{   
    health-=shealth;
    cs.setFlash();
    if(health<=0)
    {
        en.stopgame();
    }
}





}
