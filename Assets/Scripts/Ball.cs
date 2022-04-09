
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{

    public Spieler spielerKlasse;

    public GameObject spieler;
    public AudioClip kollisionZiegelAudio;
    int punkte = 0;
    Rigidbody2D rb;
    int leben = 5;
    
    public Text punkteAnzeige;
    public Text lebenAnzeige;
    public Text infoAnzeige;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject target = coll.gameObject;

        if(target.CompareTag("Ziegel"))
        {
            AudioSource.PlayClipAtPoint(kollisionZiegelAudio, transform.position);
            punkte++;

            if (punkte < 50)
            {
                Destroy(target);
                if (punkte % 10 == 0)
                    rb.velocity = new Vector2(rb.velocity.x * 1.1f, rb.velocity.y * 1.1f);
                Debug.Log("Punkte: " + punkte + " Velocity: " + rb.velocity.magnitude);
                punkteAnzeige.text = "Punkte: " + punkte;
            }
            else
            {
                Destroy(target);
                spieler.SetActive(false);
                gameObject.SetActive(false);
                Debug.Log("Win");
                punkteAnzeige.text = "Punkte: " + punkte;
                infoAnzeige.text = "Victory";
            }

           }
        else if (target.CompareTag("BodenMitte")) 
        {
            leben--;
            spieler.SetActive(false);
            gameObject.SetActive(false);
            spielerKlasse.ballmoving = false;
            lebenAnzeige.text = "Leben: " + leben;

            if(leben >= 1)
            {
                Invoke(nameof(NLeben), 0);
                infoAnzeige.text = "Du hast noch " + leben + " Leben!";
            }
            else
            {
                Debug.Log("Lost");
                infoAnzeige.text = "Du hast verloren!";
            }


        }

        }

    void  NLeben()
    {
        infoAnzeige.text = "";
        spieler.SetActive(true);
        spieler.transform.position = new Vector3(0, -4.55f, 0);

        gameObject.SetActive(true);
        transform.position = new Vector3(0, -4.1f, 0);
    }

        
    }

