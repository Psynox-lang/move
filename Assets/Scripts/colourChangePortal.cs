using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChangePortal : MonoBehaviour
{
    
    
    public SpriteRenderer body;

    // Start is called before the first frame update
    void Start()
    {
        body  = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomColour(Color color){
        
        body.color=color;
    }
}
