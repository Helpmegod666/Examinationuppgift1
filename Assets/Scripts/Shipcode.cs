using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipcode : MonoBehaviour
{

    //variabler för hastighet
    public float boatRotation;
    public float boatSpeed;

    //båt färger
    public SpriteRenderer rend;
    public Color Rightcolor;
    public Color Leftcolor;

    public float timer = 0;
    

    void Start()
    {

    }


    void Update()
    {
        

        //Jag gör så att båten rör sig upp mot y axeln per sekund
        transform.Translate(0f, boatSpeed * Time.deltaTime, 0f); 

        // Detta gör så att man kan svänga höger och även ändrar färgen till "Rightcolor" alltså blå
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -boatRotation * Time.deltaTime);
            rend.color = Rightcolor;
        }

        // Detta gör så att man kan svänga vänster och även ändrar färgen till "leftcolor" alltså grön ((UPDATE: Jag gjorde så att det går långsamare att svänga vänster))
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, (boatRotation - (boatRotation / 3)) * Time.deltaTime);
            rend.color = Leftcolor;
        }

        // När S trycks ner halveras hastigheten åt andra hållet nu tack vare "-", annars skulle den bara ZOOMA iväg
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, (-boatSpeed / 2) * Time.deltaTime, 0f);
        }

        // Det här är timern som jag lyckades göra, tiden börjar på 0 och sedan ökar den med "time.deltatime" så det blir IRL hoppas jag :( 
        timer += timer + Time.deltaTime;
    }
}
