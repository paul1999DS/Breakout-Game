
using UnityEngine;

public class Spieler : MonoBehaviour
{

    public GameObject ZiegelEins;
    public GameObject ZiegelZwei;
    public GameObject ZiegelDrei;

    public Ball ballklasse;

    public GameObject ball;
    Rigidbody2D ballRB;
    public bool ballmoving = false;

    readonly float eFaktor = 10;

    // Start is called before the first frame update
    void Start()
    
    {
        ballRB = ball.GetComponent<Rigidbody2D>();

        for(int j = 1; j <= 10; j++) 
        { 
        
            for(int i = 1; i<= 5; i++)
            {
                
                int zufall = Random.Range(1, 4);
                GameObject ziegel = zufall switch
                {
                    1 => ZiegelEins,
                    2 => ZiegelZwei,
                    _ => ZiegelDrei,
                };


            Instantiate(ziegel, new Vector3(j * 1.2f-6.6f, i * 0.75f -0.25f, 0), Quaternion.identity);
            }
        }

    }

    void Update()
    {
        

        float xEingabe = Input.GetAxis("Horizontal");
        float yEingabe = Input.GetAxis("Vertical");
        
        if(!ballmoving && yEingabe > 0)
        {
            int ballDirection = Random.Range(120, 241);
            int ballN = Random.Range(1, 3);
            if (ballN == 1)
                ballDirection = ballDirection - 360;
            ballRB.AddForce(new Vector2(ballDirection, 200));
            ballmoving = true;
        }

        if(ballmoving)
        {
            ballklasse.infoAnzeige.text = "";
            float xNeu = transform.position.x + xEingabe * eFaktor * Time.deltaTime;
            if (xNeu < -4.9f) xNeu = -4.9f;
            if (xNeu > 4.9f) xNeu = 4.9f;
            transform.position = new Vector3(xNeu, transform.position.y, 0);
        }

           
    }

}
