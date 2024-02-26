using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourPlanet : MonoBehaviour
{ 
    public List<Color> colors = new List<Color>();
    
    public SpriteRenderer body;

    // Start is called before the first frame update
    void Start()
    {
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
        int randomInt = Random.Range(0, colors.Count);
        body.color=colors[randomInt];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
