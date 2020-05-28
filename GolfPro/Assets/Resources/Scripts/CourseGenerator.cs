using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseGenerator : MonoBehaviour
{

    public static GameObject fairwayLight;
    public static GameObject fairwayDark;
    public static GameObject teeBox;
    public static GameObject green;
    public static GameObject sand;
    public static GameObject golfBall;

    // Use this for initialization
    void Start()
    {
        fairwayDark = (GameObject)Resources.Load("Prefabs/Fairway Dark");
        fairwayLight = (GameObject)Resources.Load("Prefabs/Fairway Light");
        teeBox = (GameObject)Resources.Load("Prefabs/Tee Box");
        green = (GameObject)Resources.Load("Prefabs/Green");
        sand = (GameObject)Resources.Load("Prefabs/Sand Trap");
        golfBall = (GameObject)Resources.Load("Prefabs/Golf Ball");

        int par = Random.Range(3, 5);

        holeGenerator(par);
     
    }

    public static void holeGenerator(int par)
    {
        float xPos = Random.Range(-1, 1);
        float zPos = Random.Range(-4, -2);
        float averageWidth = 0;
        int zCoor = 0;
        int yardage;
        int width = 0;
        int neg = 0;
        int pos = 0;

        Vector3 trapOrigin;        


        //Yardage
        if (par == 3)
        {
            yardage = Random.Range(12, 20);
        }
        else if (par == 4)
        {
            yardage = Random.Range(24, 44);
        }
        else
        {
            yardage = Random.Range(48, 64);
        }


        //Creates tee box
        Instantiate(teeBox, new Vector3(xPos, 0, zPos), Quaternion.identity);

        //Creates fairway w/ traps

        for (int i = 0; i < yardage; i++)
        {
            zCoor = i;
            pos = -1;
            neg = 0;

            width = (int)Random.Range(yardage / 4, yardage / 2);

            for (int a = 0; a < width; a++)
            {

                if ((a + 1) % 2 == 1)
                {
                    pos++;
                    Instantiate(fairwayLight, new Vector3(pos, 0, zCoor), Quaternion.identity);
                                     
                }

                else if ((a + 1) % 2 != 1)
                {
                    neg--;
                    Instantiate(fairwayDark, new Vector3(neg, 0, zCoor), Quaternion.identity);
                }
            }

            averageWidth += width;
        }
        averageWidth /= yardage;

        int tLength = Random.Range(1, 5);
        int tWidth;
        int zTrap;

        

        trapOrigin = new Vector3((int)Random.Range(-averageWidth / 2, averageWidth / 2), 0, (int)Random.Range(0, yardage - tLength));

        for (int i = 0; i < tLength; i++)
        {
            zTrap = i;
            neg = 0;
            pos = -1;
            tWidth = Random.Range(1, 5);

            for (int a = 0; a < tWidth; a++)
            {
                if ((a + 1) % 2 == 1)
                {
                    pos++;

                    RaycastHit hit;
                    if (Physics.Raycast(new Vector3(trapOrigin.x, 0, trapOrigin.z ), Vector3.down, out hit, 2))
                    {
                        hit.transform.gameObject.SetActive(false);
                        print(hit.collider.gameObject.name);
                    }

                   Instantiate(sand, new Vector3(trapOrigin.x + pos, 0, trapOrigin.z + zTrap), Quaternion.identity);
                }

                else
                {
                    neg--;

                    RaycastHit hit;
                    if (Physics.Raycast(new Vector3(trapOrigin.x, 0, trapOrigin.z), Vector3.down, out hit, 2))
                    {
                        hit.transform.gameObject.SetActive(false);
                        print(hit.collider.gameObject.name);
                    }

                  Instantiate(sand, new Vector3(trapOrigin.x + neg, 0, trapOrigin.z + zTrap), Quaternion.identity);
                }
            }
        }

        //Creates green
        float xScale = green.gameObject.transform.localScale.x + (float)Random.Range(1, 3.5f);
        float zScale = green.gameObject.transform.localScale.z + (float)Random.Range(1, 3.5f);

        Instantiate(green, new Vector3(0, 0, (float)(zCoor + (zScale / 5))), Quaternion.identity);

        ////Instantiates sand traps
        
        

            spawn(xPos, zPos);
    }

    

    //Instantiates golf ball
    public static void spawn(float xPos, float zPos)
    {
        float yPos = 0.015f;

        Instantiate(golfBall, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

}
