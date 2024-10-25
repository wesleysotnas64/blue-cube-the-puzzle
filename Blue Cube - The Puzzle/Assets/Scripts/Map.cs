using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject platform_1;
    public int idMap;
    public int[,] tilesMatrix;
    public int rows;
    public int columns;
    
    void Start()
    {
        InitMap();
        RenderMap();
    }

    void Update()
    {
        
    }

    private void InitTilesMatrix()
    {
        tilesMatrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                tilesMatrix[i, j] = 0; 
            }
        }
    }

    private void RenderMap()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if(tilesMatrix[i, j] == 1)
                {
                    GameObject platform = Instantiate(platform_1);
                    platform.transform.position = new Vector3(i, 0, j);
                    platform.GetComponent<PlatformPresentation>().Init();
                }
            }
        }
    }

    private void InitMap()
    {
        switch (idMap)
        {
            case 0:
                Map_Test();
                break;

            default:
                break;
        }
    }

    private void Map_Test()
    {
        rows = 5;
        columns = 3;
        InitTilesMatrix();

        //Tiles
        tilesMatrix[0,0] = 1;
        tilesMatrix[1,0] = 1;
        tilesMatrix[1,1] = 1;
        tilesMatrix[2,1] = 1;
        tilesMatrix[3,1] = 1;
        tilesMatrix[4,1] = 1;
        tilesMatrix[4,2] = 1;
    }
}
