using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject platform_Init; // 1
    public GameObject platform_Final; // 2
    public GameObject platform_1; // 3
    public GameObject platform_2; // 4
    public GameObject platform_Fall; //5
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

                    case 5:
                        InstantiateTile(platform_Fall, i, j);
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
        rows = 11;
        columns = 6;
        InitTilesMatrix();

        //Tiles
        tilesMatrix[1,1] = 1;

        tilesMatrix[2,1] = 3;
        tilesMatrix[2,2] = 3;
        tilesMatrix[3,2] = 3;
        tilesMatrix[4,2] = 3;
        tilesMatrix[5,2] = 3;
        tilesMatrix[5,3] = 4;
        tilesMatrix[5,4] = 4;
        tilesMatrix[6,4] = 3;
        tilesMatrix[6,3] = 3;
        tilesMatrix[6,2] = 3;
        tilesMatrix[7,2] = 4;
        tilesMatrix[7,3] = 4;
        tilesMatrix[8,3] = 3;
        tilesMatrix[9,3] = 3;
        tilesMatrix[9,2] = 3;

        tilesMatrix[9,1] = 2;

        ApplyFallPlatform();
    }

    public void ApplyFallPlatform()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if(tilesMatrix[i,j] == 0)
                {
                    if(HasAdjacentPlatform(i, j)) tilesMatrix[i, j] = 5;
                }
            }    
        }
    }

    private bool HasAdjacentPlatform(int i, int j)
    {

        if(OutOfRange(rows, columns, i-1, j) == false) //UP
        {
            if(tilesMatrix[i-1, j] != 0 && tilesMatrix[i-1, j] != 5) return true;
        }
        if(OutOfRange(rows, columns, i+1, j) == false) //DAWN
        {
            if(tilesMatrix[i+1, j] != 0 && tilesMatrix[i+1, j] != 5) return true;
        }
        if(OutOfRange(rows, columns, i, j-1) == false) //LEFT
        {
            if(tilesMatrix[i, j-1] != 0 && tilesMatrix[i, j-1] != 5) return true;
        }
        if(OutOfRange(rows, columns, i, j+1) == false) //RIGHT
        {
            if(tilesMatrix[i, j+1] != 0 && tilesMatrix[i, j+1] != 5) return true;
        }

        return false;
    }

    private bool OutOfRange(int rowSize, int colSize, int i, int j)
    {
        if(i < 0 || j < 0 || i >= rowSize || j >= colSize) return true;
        else return false;
    }
}
