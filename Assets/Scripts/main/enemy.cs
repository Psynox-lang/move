using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    public GameObject Player;

    public float speed;

    public Vector3 velocity;
    public GameObject differentColor;
    public GameObject sameColor;
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    public ScoreManager sc;
    [SerializeField] GameObject end;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        transform.position =
            Vector3
                .SmoothDamp(transform.position,
                player.position,
                ref velocity,
                speed * 0.01f);

        if (velocity.x < 0)
        {
            spriteRenderer.flipY = true;
        }
        else if (velocity.x > 0)
        {
            spriteRenderer.flipY = false;
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 0.1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //add function call to end player effect here
            other.gameObject.GetComponent<colourChangePortal>().endMusic();
            end.SetActive(true);
            Destroy(other.gameObject);
            Destroy(gameObject);
            sc.setHighScore();
            sc.gameObject.SetActive(false);
        }
        else if (other.tag == "Planet")
        {
            if (
                other
                    .gameObject
                    .transform
                    .GetChild(0)
                    .GetComponent<colourPlanet>()
                    .body
                    .color !=
                Player.GetComponent<colourChangePortal>().body.color
            )
            {
               sc.incrementScore(35, other.gameObject.transform.position);
                Player.GetComponent<colourChangePortal>().samePlanetMusic();
                Instantiate(differentColor,other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                //score plus
            }
            else
            {
                sc.incrementScore(-10,other.gameObject.transform.position);
                Instantiate(sameColor,other.gameObject.transform.position, Quaternion.identity);
                 Player.GetComponent<colourChangePortal>().diffPlanetMusic();
                Destroy(other.gameObject);
            }
        }
    }
    // void endgame(){
    //     Invoke("")
    // }
   
}
