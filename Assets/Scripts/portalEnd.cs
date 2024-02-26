using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;
    public List<Color> colors = new List<Color>();
    private int randomInt;
    void Start()
    {
       // transform.rotation=player.transform.rotation;

        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
        randomInt = Random.Range(0, colors.Count);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
       { other.gameObject.GetComponent<scalePortal>().DecreaseScale();
           ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startColor = colors[randomInt];
          particleSystem.Play();   
       }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"){
        other.gameObject.GetComponent<scalePortal>().IncreaseScale();
        other.gameObject.GetComponent<colourChangePortal>().randomColour(colors[randomInt]);
       
        Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
