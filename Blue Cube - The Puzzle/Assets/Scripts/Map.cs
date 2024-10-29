using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject platform_Init; // 1
    public GameObject platform_Final; // 2
    public GameObject platform_1; // 3
    public GameObject platform_2; // 4
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

                switch (tilesMatrix[i, j])
                {
                    case 1:
                        InstantiateTile(platform_Init, i, j);
                        break;
                    
                    case 2:
                        InstantiateTile(platform_Final, i, j);
                        break;

                    case 3:
                        InstantiateTile(platform_1, i, j);
                        break;

                    case 4:
                        InstantiateTile(platform_2, i, j);
                        break;

                    default:
                        break;
                }

            }
        }
    }

    private void InstantiateTile(GameObject _gameObject, int _xPosition, int _zPosition)
    {
        GameObject platform = Instantiate(_gameObject);
        platform.transform.position = new Vector3(_xPosition, 0, _zPosition);
        platform.GetComponent<PlatformPresentation>().Init();
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
        tilesMatrix[1,0] = 4;
        tilesMatrix[1,1] = 4;
        tilesMatrix[2,1] = 4;
        tilesMatrix[3,1] = 4;
        tilesMatrix[4,1] = 4;
        tilesMatrix[4,2] = 2;
    }
}
