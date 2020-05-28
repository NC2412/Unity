using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelEditor : MonoBehaviour
{

    public Image img;

    Texture2D texture;

    // Use this for initialization
    void Start()
    {
        texture = new Texture2D(Screen.width, Screen.height);

        ClearScreen();
    }

    public void ClearScreen()
    {
        for (int i = 0; i < texture.width; i++)
        {
            for (int a = 0; a < texture.height; a++)
            {
                texture.SetPixel(i, a, Color.clear);
            }
        }
        texture.Apply();

        img.GetComponent<Image>().material.mainTexture = texture;
    }

    public void glitchEndlessModeScreen()
    {
        int startX = Random.Range(0, Screen.width - 300);
        int startY = Random.Range(0, Screen.height - 300);
        int endX = Random.Range(startX, Screen.width);
        int endY = Random.Range(startY, Screen.height);
        int randCol;

        for (int i = startX; i < endX; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                randCol = Random.RandomRange(0, 5);

                switch (randCol)
                {
                    case 0:
                        texture.SetPixel(i, j, Color.blue);
                        break;

                    case 1:
                        texture.SetPixel(i, j, Color.green);
                        break;

                    case 2:
                        texture.SetPixel(i, j, Color.red);
                        break;

                    case 3:
                        texture.SetPixel(i, j, Color.black);
                        break;

                    case 4:
                        texture.SetPixel(i, j, Color.clear);
                        break;

                }
            }
        }
        texture.Apply();
    }

    float glitchTimer = 3;

    public void GlitchStartScreen()
    {
        int xAreaStart = Random.Range(0, Screen.width - 500);
        int xAreaEnd = Random.Range(xAreaStart, xAreaStart + 500);
        int yAreaStart = Random.Range(0, Screen.height - 500);
        int yAreaEnd = Random.Range(yAreaStart, yAreaStart + 500);
        int randNum;

        for (int i = xAreaStart; i < xAreaEnd; i++)
        {
            for (int j = yAreaStart; j < yAreaEnd; j++)
            {
                randNum = Random.RandomRange(0, 5);

                switch (randNum)
                {
                    case 0:
                        texture.SetPixel(i, j, Color.blue);
                        break;

                    case 1:
                        texture.SetPixel(i, j, Color.green);
                        break;

                    case 2:
                        texture.SetPixel(i, j, Color.red);
                        break;

                    case 3:
                        texture.SetPixel(i, j, Color.black);
                        break;

                    case 4:
                        texture.SetPixel(i, j, Color.clear);
                        break;
                }
            }
        }

        texture.Apply();
    }

    void Update()
    {
        if (Application.loadedLevelName == "Start Scene")
        {

            glitchTimer -= Time.deltaTime;

            if (glitchTimer <= 0)
            {
                GlitchStartScreen();
                glitchTimer = 3;
            }
        }
    }
}
