using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipcode : MonoBehaviour
{
    //Variabler för timer
    private float currentTime = 1;
    public float timer = 0;
    
    //variabler för hastighet
    public float boatRotation;
    public float boatSpeed;

    //båt färger
    public SpriteRenderer rend;
    public Color Rightcolor;
    public Color Leftcolor;
    public Color spacecolor;
    public float rColor1;
    public float rColor2;
    public float rColor3;

    //variabel för warping (för spooky season booooo)
    private float leftwarp = -9.7f;
    private float rightwarp = 9.7f;
    private float downwarp = -5.7f;
    private float upwarp = 5.7f;

    //variabel för starterposition
    private float starterX;
    private float starterY;
    private float starterZ;

    void Start()
    {
        //här gjorde jag min starter position randomiser :D, den fungerar genom att den translatar den första positionen till något slumpmässigt
        starterX = Random.Range(-9.7f, 19.4f);
        starterY = Random.Range(-5.7f, 11.4f);
        starterZ = Random.Range(0f, 360f);
        transform.Translate(starterX, starterY, 0);
        transform.Rotate(0, 0, starterZ);

        // här randomisar jag starter boatspeeden
        boatSpeed = Random.Range(1f, 15f);
    }


    void Update()
    {
        

        //Jag gör så att båten rör sig upp mot y axeln per sekund
        transform.Translate(0f, boatSpeed * Time.deltaTime, 0f); 

        // om du håller inne D så roterar du Z positionen
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -boatRotation * Time.deltaTime);
        }

        // om du håller inne A så roterar du Z postionen åt andra hållet
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, (boatRotation - (boatRotation / 3)) * Time.deltaTime);
        }

        // ville göra så att du kunde snurra runt och få random färg samtidigt du snurrade runt så jag gjorde detta. Men om du trycker på D rendar den Rightcolor.
        if (Input.GetKeyDown(KeyCode.D))
        {
            rend.color = Rightcolor;
        }

        // samma här fast du rendar lefcolor variabeln.
        if (Input.GetKeyDown(KeyCode.A))
        {
            rend.color = Leftcolor;
        }
        // När S trycks ner halveras hastigheten åt andra hållet nu tack vare "-", annars skulle den bara ZOOMA iväg
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, (-boatSpeed / 2) * Time.deltaTime, 0f);
        }

        // Det här är timern som jag lyckades göra, tiden börjar på 0 och sedan ökar den med "time.deltatime" så det blir IRL hoppas jag :( 
        timer += Time.deltaTime;

        // Det här är timern jag fick hjälp med att göra, det betyder att om timer är större än currenttime och timer är mindre än currenttime + 0.2 printar den värdet.
        if (timer > currentTime && timer < currentTime + 0.2)
        {
            print("Timer: " + (int)timer);
            currentTime = (currentTime + 1);
        }

        //här trycker man på space för en "random" färg. jag använde 255f fast det funkade inte så bra så jag fick reda av UNKNOWN MEANS att 1f är mycket bättre.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rColor1 = Random.Range(0f, 1f);
            rColor2 = Random.Range(0f, 1f);
            rColor3 = Random.Range(0f, 1f);

            spacecolor = new Color(rColor1, rColor2, rColor3);
            rend.color = spacecolor;
        }
        //5.7 y
        //9.7 x

        //om positionen är mindre än -9.7 kommer skeppet att "teleportera" till 9.7 istället.
        if (transform.position.x < -9.7)
        {
            transform.position = new Vector3(rightwarp, transform.position.y, transform.position.z);
        }

        //om positionen är mer än 9.7 kommer skeppet att "teleportera" till -9.7 istället.
        if (transform.position.x > 9.7)
        {
            transform.position = new Vector3(leftwarp, transform.position.y, transform.position.z);
        }

        //om positionen är mindre än -5.7 kommer skeppet att "teleportera" till 5.7 istället.
        if (transform.position.y < -5.7)
        {
            transform.position = new Vector3(transform.position.x, upwarp, transform.position.z);
        }

        //om positionen är mer än 5.7 kommer skeppet att "teleportera" till -5.7 istället.
        if (transform.position.y > 5.7)
        {
            transform.position = new Vector3(transform.position.x, downwarp, transform.position.z);
        }
        

    }
}
