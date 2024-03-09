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
        List<Color> colors = new List<Color>();
        colors.Add(new Color(227f / 255f, 142f / 255f, 1f / 255f)); // RGB: (227, 142, 1)
        colors.Add(new Color(64f / 255f, 183f / 255f, 161f / 255f)); // RGB: (64, 183, 161)
        colors.Add(new Color(134f / 255f, 113f / 255f, 91f / 255f)); // RGB: (134, 113, 91)
        colors.Add(new Color(188f / 255f, 216f / 255f, 222f / 255f)); // RGB: (134, 113, 91)
        int randomInt = Random.Range(0, colors.Count);
        body.color=colors[randomInt];
    }

}
