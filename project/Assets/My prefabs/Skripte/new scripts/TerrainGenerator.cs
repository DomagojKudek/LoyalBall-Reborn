using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public int depth = 3;

    public int width = 128;
    public int height = 128;

    public float scale = 10f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float speed = 1f;

    public int direction = 0;

    private void Start()
    {

        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }
    private void Update()
    {
        if (direction == 0)
        {
            offsetY += Time.deltaTime * speed;
        }
        if (direction == 1)
        {
            offsetX -= Time.deltaTime * speed;
        }
        if (direction == 2)
        {
            offsetY -= Time.deltaTime * speed;
        }
        if (direction == 3)
        {
            offsetX += Time.deltaTime * speed;
        }
        
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x=0;x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale +offsetX;
        float yCoord = (float)y / height * scale+offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
        //return Mathf.Sin(xCoord);
    }

}
