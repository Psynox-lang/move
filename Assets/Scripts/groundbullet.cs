using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundbullet : MonoBehaviour
{
    void Start(){
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Destroy(gameObject);
        }
    }
}
