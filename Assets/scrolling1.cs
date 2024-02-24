using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr= GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.x/5;
        offset.y = transform.position.y/5;

        mat.mainTextureOffset = offset;
        
    }
}
