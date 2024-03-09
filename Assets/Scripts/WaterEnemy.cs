using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : MonoBehaviour
{
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void spawnS()
    {
        Instantiate(water, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
