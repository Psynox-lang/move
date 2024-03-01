using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;

    public List<Color> colors = new List<Color>();

    private int randomInt;

    public ScoreManager sc;

    void Start()
    {
        // transform.rotation=player.transform.rotation;
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
        randomInt = Random.Range(0, colors.Count);
        float slsize = Random.Range(0.2f, 0.5f);
        transform.localScale = new Vector3(slsize, slsize, 1);
        sc =
            GameObject
                .FindWithTag("GameController")
                .GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<scalePortal>().DecreaseScale();
            ParticleSystem.MainModule mainModule = particleSystem.main;
            mainModule.startColor = colors[randomInt];
            particleSystem.Play();
            other.gameObject.GetComponent<colourChangePortal>().portalMusic();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<scalePortal>().IncreaseScale();
            other
                .gameObject
                .GetComponent<colourChangePortal>()
                .randomColour(colors[randomInt]);

            sc.incrementScore(15,transform.position);
            Destroy (gameObject);
        }
    }
}
