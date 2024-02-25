using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetobs : MonoBehaviour
{
    // Start is called before the first frame update
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
