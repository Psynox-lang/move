using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChangePortal : MonoBehaviour
{
    
    
    public SpriteRenderer body;
    public GameObject flash;

    // Start is called before the first frame update
    void Start()
    {
        body  = transform.GetChild(0).GetComponent<SpriteRenderer>();
        flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomColour(Color color){
        
        body.color=color;
    }
    public void setFlash(){
        flash.SetActive(true);
        Invoke("setNoFlash", 0.5f);
    }
    public void setNoFlash(){
        flash.SetActive(false);
    }
    public void endgame(){
        for(int i=0; i<3; i++)
        Invoke("setFlash", 0.2f);
    }
}
