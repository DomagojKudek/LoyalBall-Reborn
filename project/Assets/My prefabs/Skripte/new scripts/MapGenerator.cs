using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading;
using Random = UnityEngine.Random;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    public int seedNumber;
    public int levelLength;

    public GameObject[] straightTileType; // what prefabs to spawn

    public GameObject[] curveTileType;

    public GameObject upTile;
    public GameObject liftTile;
    public GameObject bigTerrain;
    public GameObject finishTile;

    public GameObject[] spawnObjects; // what prefabs to spawn

    public GameObject pillar;
    public GameObject sphere;

    Dictionary<Vector3, Tile> tileDictionary = new Dictionary<Vector3, Tile>();

    public void startGame()
    {
        Random.seed = seedNumber;
        //Debug.Log(seedNumber);
        levelLength *= 11;
        //Debug.Log(levelLength);
        GenerateMap();
    }


    public GameObject createNewTile(int direction, int type, Vector3 position)
    {
        //lijevo stvaranje
        if (direction == 0)
        {
            //staticni
            if ((type >= 0 && type <= 7 ) || (type > 15))
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                return newTile;
            }

            //cube random
            if (type == 10)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile3(newTile, direction);
                return newTile;
            }
            //string 1
            if (type == 11)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile4(newTile);
                return newTile;
            }
            //empty/rot/move
            if (type == 12)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile5(newTile);
                return newTile;
            }
            //perlin noise tile
            if (type == 13)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * -90)) as GameObject;
                newTile.transform.Find("Terrain").position += new Vector3(-32, 0, 0);
                generateTile6(newTile, 0);
                return newTile;
            }
            //vertical moving platforms
            if (type == 14)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile7(newTile, direction);
                return newTile;
            }
            //rotating circle
            if (type == 15)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                return newTile;
            }
            // pillar
            if (type == 8)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile9(newTile, direction);
                return newTile;
            }
            // balls
            if (type == 9)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile10(newTile, direction);
                return newTile;
            }
        }
        //ravno stvaranje
        if (direction == 1)
        {
            //staticni
            if ((type >= 0 && type <= 7) || (type > 15))
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                return newTile;
            }
            //cube random
            if (type == 10)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile3(newTile, direction);
                return newTile;
            }
            //string 1
            if (type == 11)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile4(newTile);
                return newTile;
            }
            //empty/rot/move
            if (type == 12)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile5(newTile);
                return newTile;
            }
            //perlin noise tile
            if (type == 13)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile6(newTile, 0);
                return newTile;
            }
            //vertical moving platforms
            if (type == 14)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile7(newTile, direction);
                return newTile;
            }
            //rotating circle
            if (type == 15)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                return newTile;
            }
            // pillar
            if (type == 8)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile9(newTile, direction);
                return newTile;
            }
            // balls
            if (type == 9)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile10(newTile, direction);
                return newTile;
            }
        }
        //desno stvaranje
        if (direction == 2)
        {
            //staticni
            if ((type >= 0 && type <= 7) || (type > 15))
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                return newTile;
            }
            //cube random
            if (type == 10)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile3(newTile, direction);
                return newTile;

            }
            //string 1
            if (type == 11)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile4(newTile);
                return newTile;
            }
            //empty/rot/move
            if (type == 12)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile5(newTile);
                return newTile;
            }
            //perlin noise tile
            if (type == 13)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * -90)) as GameObject;
                newTile.transform.Find("Terrain").position += new Vector3(-32, 0, 0);
                generateTile6(newTile, 0);
                return newTile;
            }
            //vertical moving platforms
            if (type == 14)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                generateTile7(newTile, direction);
                return newTile;
            }
            //rotating circle
            if (type == 15)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                return newTile;
            }
            // pillar
            if (type == 8)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile9(newTile, direction);
                return newTile;
            }
            // balls
            if (type == 9)
            {
                GameObject newTile = Instantiate(straightTileType[type], position + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile10(newTile, direction);
                return newTile;
            }

        }
        //unatrag stvaranje
        if (direction == 3)
        {
            //staticni
            if ((type >= 0 && type <= 7) || (type > 15))
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                return newTile;
            }
            //cube random
            if (type == 10)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile3(newTile, direction);
                return newTile;

            }
            //string 1
            if (type == 11)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile4(newTile);
                return newTile;
            }
            //empty/rot/move
            if (type == 12)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile5(newTile);
                return newTile;
            }
            //perlin noise tile
            if (type == 13)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile6(newTile, 0);
                return newTile;
            }
            //vertical moving platforms
            if (type == 14)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile7(newTile, direction);
                return newTile;
            }
            //rotating circle
            if (type == 15)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                return newTile;
            }
            // pillar
            if (type == 8)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile9(newTile, direction);
                return newTile;
            }
            // balls
            if (type == 9)
            {
                GameObject newTile = Instantiate(straightTileType[type], position, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                generateTile10(newTile, direction);
                return newTile;
            }
        }
        return null;
    }

    public void generateTile3(GameObject newTile, int direction)
    {
        Transform cubeHolder = new GameObject("cubes").transform;
        cubeHolder.parent = newTile.transform;
        for (int i = 0; i < 25; i++)
        {
            Vector3 spawnPosition = Vector3.zero;
            Vector3 currentPosition = new Vector3();
            currentPosition = newTile.transform.position;


            if (direction == 0)
            {
                spawnPosition.x = Random.Range(-7.5f + currentPosition.x, 39.5f + currentPosition.x);
                spawnPosition.y = Random.Range(0.5f + currentPosition.y, 0.5f + +currentPosition.y);
                spawnPosition.z = Random.Range(-7.5f + currentPosition.z, 7.5f + currentPosition.z);
            }
            if (direction == 1)
            {
                spawnPosition.x = Random.Range(-7.5f + currentPosition.x, 7.5f + currentPosition.x);
                spawnPosition.y = Random.Range(0.5f + currentPosition.y, 0.5f + +currentPosition.y);
                spawnPosition.z = Random.Range(-7.5f + currentPosition.z, 39.5f + currentPosition.z);
            }
            if (direction == 2)
            {
                spawnPosition.x = Random.Range(-7.5f + currentPosition.x, 39.5f + currentPosition.x);
                spawnPosition.y = Random.Range(0.5f + currentPosition.y, 0.5f + +currentPosition.y);
                spawnPosition.z = Random.Range(-7.5f + currentPosition.z, 7.5f + currentPosition.z);
            }
            if (direction == 3)
            {
                spawnPosition.x = Random.Range(-7.5f + currentPosition.x, 7.5f + currentPosition.x);
                spawnPosition.y = Random.Range(0.5f + currentPosition.y, 0.5f + +currentPosition.y);
                spawnPosition.z = Random.Range(-7.5f + currentPosition.z, 39.5f + currentPosition.z);
            }



            int objectToSpawn = Random.Range(0, spawnObjects.Length);

            GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;
            spawnedObject.transform.parent = cubeHolder;
            spawnedObject.GetComponent<TargetMover>().spinSpeed = Random.Range(120f, 200f);
            spawnedObject.GetComponent<TargetMover>().motionMagnitude = Random.Range(0.05f, 0.1f);
        }
    }

    public void generateTile4(GameObject newTile)
    {
        int randomChild = RandomTypeNumber(0, 3);

        Transform first = newTile.transform.GetChild(0).GetChild(randomChild);
        first.gameObject.SetActive(false);
        if (randomChild == 0)
        {
            first.parent.GetChild(1).gameObject.SetActive(false);
        }
        if (randomChild == 1)
        {
            first.parent.GetChild(2).gameObject.SetActive(false);
        }
        if (randomChild == 2)
        {
            first.parent.GetChild(0).gameObject.SetActive(false);
        }

        first = newTile.transform.GetChild(2).GetChild(randomChild);
        first.gameObject.SetActive(false);

        if (randomChild == 0)
        {
            first.parent.GetChild(2).gameObject.SetActive(false);
        }
        if (randomChild == 1)
        {
            first.parent.GetChild(0).gameObject.SetActive(false);
        }
        if (randomChild == 2)
        {
            first.parent.GetChild(1).gameObject.SetActive(false);
        }

        randomChild = RandomTypeNumber(0, 2);
        first = newTile.transform.GetChild(1).GetChild(randomChild);
        first.gameObject.SetActive(false);
    }

    public void generateTile5(GameObject newTile)
    {
        List<Transform> childList = new List<Transform>();

        for (int i = 0; i < 12; i++)
        {
            childList.Add(newTile.transform.GetChild(i));
        }

        for (int i = 0; i < childList.Count - 1; i++)
        {
            int j = Random.Range(i, childList.Count);
            Transform temp = childList[i];
            childList[i] = childList[j];
            childList[j] = temp;
        }
        childList[0].gameObject.SetActive(false);
        childList[1].gameObject.SetActive(false);
        childList[2].gameObject.SetActive(false);
        childList[3].gameObject.SetActive(false);

        childList[8].gameObject.GetComponent<Animator>().enabled = true;
        childList[9].gameObject.GetComponent<Animator>().enabled = true;
        childList[10].gameObject.GetComponent<Animator>().enabled = true;
        childList[11].gameObject.GetComponent<Animator>().enabled = true;

    }

    public void generateTile6(GameObject newTile, int option)
    {
        Terrain terrain = newTile.GetComponentInChildren<Terrain>();
        TerrainData newData = new TerrainData();
        terrain.terrainData = newData;
        newTile.GetComponentInChildren<TerrainCollider>().terrainData = newData;
        if (option == 0)
        {
            newTile.GetComponentInChildren<TerrainGenerator>().direction = Random.Range(0, 4);
            newTile.GetComponentInChildren<TerrainGenerator>().depth = Random.Range(1, 4);
            newTile.GetComponentInChildren<TerrainGenerator>().scale = Random.Range(1f, 5f);
            newTile.GetComponentInChildren<TerrainGenerator>().speed = Random.Range(1f, 5f);
        }
        else if (option == 1)
        {
            newTile.GetComponentInChildren<TerrainGenerator>().direction = Random.Range(0, 4);
            newTile.GetComponentInChildren<TerrainGenerator>().depth = Random.Range(5, 10);
            newTile.GetComponentInChildren<TerrainGenerator>().scale = Random.Range(5f, 10f);
            newTile.GetComponentInChildren<TerrainGenerator>().speed = Random.Range(1f, 2f);
        }
    }

    public void generateTile7(GameObject newTile, int direction)
    {
        for (int i = 0; i < 5; i++)
        {
            TargetMover current = newTile.transform.GetChild(i).GetComponent<TargetMover>();

            current.motionMagnitude = Random.Range(0.05f, 0.115f);
            if (direction == 1 || direction == 3)
            {
                current.transform.position += new Vector3(Random.Range(-6f, 6f), 0, 0);
            }
            if (direction == 0 || direction == 2)
            {
                current.transform.position += new Vector3(0, 0, Random.Range(-6f, 6f));
            }
        }

    }

    public void generateTile9(GameObject newTile, int direction)
    {
        GameObject newPillar = null;
        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                float chance = Random.Range(0f, 1f);
                if (chance >= 0 && chance <= 0.8)
                {
                    if (direction == 0 || direction == 2)
                    {
                        newPillar = Instantiate(pillar, newTile.transform.position + new Vector3(2 * i - 7, 0, 2 * j - 7), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                    }
                    else if (direction == 1 || direction == 3)
                    {
                        newPillar = Instantiate(pillar, newTile.transform.position + new Vector3(2 * j - 7, 0, 2 * i - 7), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                    }
                    float height = Random.Range(newPillar.transform.localScale.y - 2.5f, newPillar.transform.localScale.y + 2.5f);
                    newPillar.transform.localScale = new Vector3(2f, height, 2f);
                    newPillar.transform.parent = newTile.transform;
                }
            }
        }
        if (direction == 0)
        {
            newTile.transform.Rotate(0, 180, 0);
        }

    }

    public void generateTile10(GameObject newTile, int direction)
    {
        GameObject ball = null;
        for (int i = -6; i < 42; i += 4)
        {
            if (direction == 1 || direction == 3)
            {
                ball = Instantiate(sphere, newTile.transform.position + new Vector3(Random.Range(-6f, 6f), 0, i), Quaternion.Euler(Vector3.up * 0)) as GameObject;
            }
            if (direction == 0 || direction == 2)
            {
                ball = Instantiate(sphere, newTile.transform.position + new Vector3(i, 0, Random.Range(-6f, 6f)), Quaternion.Euler(Vector3.up * 0)) as GameObject;
            }
            ball.transform.parent = newTile.transform;
        }
        if (direction == 0)
        {
            newTile.transform.Rotate(0, 180, 0);
        }
    }

    public int RandomNumber(int min, int max, List<int> flag, int N)
    {
        int broj = Random.Range(min, max);
        //Debug.Log("ovo je tile: " + N + "  random broj: " + broj + "  flag tablica: " + flag[broj]);
        return flag[broj];
    }

    public int RandomTypeNumber(int min, int max)
    {
        int broj = Random.Range(min, max);
        //Debug.Log(broj);
        return broj;
    }

    public void GenerateMap()
    {
        //matrica blokova
        int N = 1;
        Vector3 direction = new Vector3();
        int startingPositionX = 0;
        int startingPositionY = 0;
        int startingPositionZ = 0;

        Vector3 upCheck = new Vector3(0, 0, 48);
        Vector3 downCheck = new Vector3(0, 0, -48);
        Vector3 rightCheck = new Vector3(48, 0, 0);
        Vector3 leftCheck = new Vector3(-48, 0, 0);

        //destroy stare generirane tileove
        string mapName = "Generated Map";
        if (transform.Find(mapName))
        {
            DestroyImmediate(transform.Find(mapName).gameObject);
        }

        Transform mapGenerator = new GameObject(mapName).transform;

        string tileHolderName = "Tiles";
        Transform tileHolder = new GameObject(tileHolderName).transform;
        tileHolder.parent = mapGenerator;
        mapGenerator.parent = transform;

        Vector3 initPosition = new Vector3(startingPositionX * 48, startingPositionY * 8, startingPositionZ * 48);
        GameObject initTile = Instantiate(straightTileType[0], initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
        direction = Vector3.forward;
        Tile startTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
        tileDictionary[initPosition] = startTile;
        initTile.name = "Tile 0";
        initTile.transform.parent = tileHolder;

        while (N < levelLength)
        {

            //LIJEVO
            if (direction == Vector3.left)
            {
                List<int> flag = new List<int>();
                initPosition += leftCheck;

                if (!tileDictionary.ContainsKey(initPosition + leftCheck) && !tileDictionary.ContainsKey(initPosition + leftCheck + leftCheck))
                {
                    flag.Add(0);
                }

                if (!tileDictionary.ContainsKey(initPosition + upCheck) && !tileDictionary.ContainsKey(initPosition + upCheck + upCheck))
                {
                    flag.Add(1);
                }

                if (!tileDictionary.ContainsKey(initPosition + downCheck) && !tileDictionary.ContainsKey(initPosition + downCheck + downCheck))
                {
                    flag.Add(3);
                }

                int randomNumber = 100;
                if (flag.Count() == 0 || N % 11 == 0 || N == levelLength - 1)
                {
                    GameObject newTile = Instantiate(upTile, initPosition + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y + 1, direction);
                    tileDictionary[initPosition] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, -8, 0)] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, 8, 0)] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.left;
                    initPosition += new Vector3(0, 8, 0);
                }
                else
                {
                    randomNumber = RandomNumber(0, flag.Count(), flag, N);
                }

                if (randomNumber == 0)
                {
                    int randomType = RandomTypeNumber(0, straightTileType.Length);
                    GameObject newTile = createNewTile(0, randomType, initPosition);
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.left;
                }
                if (randomNumber == 1)
                {
                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * 270)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.forward;
                }
                if (randomNumber == 3)
                {
                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.back;
                }
            }


            //NAPRIJED
            else if (direction == Vector3.forward)
            {
                List<int> flag = new List<int>();
                initPosition += upCheck;

                if (!tileDictionary.ContainsKey(initPosition + leftCheck) && !tileDictionary.ContainsKey(initPosition + leftCheck + leftCheck))
                {
                    flag.Add(0);
                }

                if (!tileDictionary.ContainsKey(initPosition + upCheck) && !tileDictionary.ContainsKey(initPosition + upCheck + upCheck))
                {
                    flag.Add(1);
                }

                if (!tileDictionary.ContainsKey(initPosition + rightCheck) && !tileDictionary.ContainsKey(initPosition + rightCheck + rightCheck))
                {
                    flag.Add(2);
                }


                int randomNumber = 100;
                if (flag.Count() == 0 || N % 11 == 0 || N == levelLength - 1)
                {
                    GameObject newTile = Instantiate(upTile, initPosition + new Vector3(0, 0, 32), Quaternion.Euler(Vector3.up * 180)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y + 1, direction);
                    tileDictionary[initPosition] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, -8, 0)] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, 8, 0)] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.forward;
                    initPosition += new Vector3(0, 8, 0);
                }
                else
                {
                    randomNumber = RandomNumber(0, flag.Count(), flag, N);
                }

                if (randomNumber == 1)
                {
                    int randomType = RandomTypeNumber(0, straightTileType.Length);
                    GameObject newTile = createNewTile(1, randomType, initPosition);
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.forward;

                }
                else if (randomNumber == 0)
                {
                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.left;
                }
                else if (randomNumber == 2)
                {
                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.right;
                }
            }


            //DESNO
            else if (direction == Vector3.right)
            {
                List<int> flag = new List<int>();
                initPosition += rightCheck;

                if (!tileDictionary.ContainsKey(initPosition + downCheck) && !tileDictionary.ContainsKey(initPosition + downCheck + downCheck))
                {
                    flag.Add(3);
                }

                if (!tileDictionary.ContainsKey(initPosition + upCheck) && !tileDictionary.ContainsKey(initPosition + upCheck + upCheck))
                {
                    flag.Add(1);
                }

                if (!tileDictionary.ContainsKey(initPosition + rightCheck) && !tileDictionary.ContainsKey(initPosition + rightCheck + rightCheck))
                {
                    flag.Add(2);
                }

                int randomNumber = 100;
                if (flag.Count() == 0 || N % 11 == 0 || N == levelLength - 1)
                {
                    GameObject newTile = Instantiate(upTile, initPosition + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * 270)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y + 1, direction);
                    tileDictionary[initPosition] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, -8, 0)] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, 8, 0)] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.right;
                    initPosition += new Vector3(0, 8, 0);
                }
                else
                {
                    randomNumber = RandomNumber(0, flag.Count(), flag, N);
                }


                if (randomNumber == 1)
                {

                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition + new Vector3(0, 0, 32), Quaternion.Euler(Vector3.up * 180)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.forward;
                }
                if (randomNumber == 2)
                {
                    int randomType = RandomTypeNumber(0, straightTileType.Length);
                    GameObject newTile = createNewTile(2, randomType, initPosition);
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.right;
                }
                if (randomNumber == 3)
                {

                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition + new Vector3(-16, 0, 16), Quaternion.Euler(Vector3.up * 90)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.back;
                }
            }

            //DOLJE
            else if (direction == Vector3.back)
            {
                List<int> flag = new List<int>();
                initPosition += downCheck;

                if (!tileDictionary.ContainsKey(initPosition + downCheck) && !tileDictionary.ContainsKey(initPosition + downCheck + downCheck))
                {
                    flag.Add(3);
                }

                if (!tileDictionary.ContainsKey(initPosition + leftCheck) && !tileDictionary.ContainsKey(initPosition + leftCheck + leftCheck))
                {
                    flag.Add(0);
                }

                if (!tileDictionary.ContainsKey(initPosition + rightCheck) && !tileDictionary.ContainsKey(initPosition + rightCheck + rightCheck))
                {
                    flag.Add(2);
                }

                int randomNumber = 100;
                if (flag.Count() == 0 || N % 11 == 0 || N == levelLength - 1)
                {
                    GameObject newTile = Instantiate(upTile, initPosition + new Vector3(0, 0, 0), Quaternion.Euler(Vector3.up * 0)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y + 1, direction);
                    tileDictionary[initPosition] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, -8, 0)] = createdTile;
                    tileDictionary[initPosition + new Vector3(0, 8, 0)] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.back;
                    initPosition += new Vector3(0, 8, 0);
                }
                else
                {
                    randomNumber = RandomNumber(0, flag.Count(), flag, N);
                }

                if (randomNumber == 2)
                {
                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition + new Vector3(16, 0, 16), Quaternion.Euler(Vector3.up * 270)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.right;
                }
                if (randomNumber == 0)
                {
                    GameObject newTile = Instantiate(curveTileType[Random.Range(0, 8)], initPosition + new Vector3(0, 0, 32), Quaternion.Euler(Vector3.up * 180)) as GameObject;
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.left;
                }
                if (randomNumber == 3)
                {
                    int randomType = RandomTypeNumber(0, straightTileType.Length);
                    GameObject newTile = createNewTile(3, randomType, initPosition);
                    Tile createdTile = new Tile(this, initPosition, true, 0, 0, (int)initPosition.y, direction);
                    tileDictionary[initPosition] = createdTile;
                    newTile.name = "Tile" + N;
                    newTile.transform.parent = tileHolder;
                    direction = Vector3.back;
                }
            }
            N++;
        }

        //FINAL PART
        if (N == levelLength)
        {
            if (direction == Vector3.left)
            {
                initPosition += leftCheck;
                GameObject newTile = Instantiate(liftTile, initPosition, Quaternion.Euler(Vector3.up * -90)) as GameObject;
                newTile.transform.position += new Vector3(16, 0, 16);
                newTile.name = "LIFT" + N;
                newTile.transform.parent = tileHolder;
                direction = Vector3.left;
                //
                initPosition += Vector3.up * 100f + leftCheck;
                GameObject newTile1 = Instantiate(straightTileType[0], initPosition, Quaternion.Euler(Vector3.up * -90)) as GameObject;
                newTile1.transform.position += new Vector3(32, 0, 16);
                newTile1.name = "FINAL 1";
                newTile1.transform.parent = tileHolder;
                direction = Vector3.left;
                //
                initPosition += leftCheck;
                GameObject newTile2 = Instantiate(bigTerrain, initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile2.transform.position += new Vector3(-216, 0, 8);
                newTile2.name = "FINAL 2";
                newTile2.transform.parent = tileHolder;
                direction = Vector3.left;
                generateTile6(newTile2, 1);
                //
                initPosition += new Vector3(-272, 0, 240);
                GameObject newTile3 = Instantiate(finishTile, initPosition, Quaternion.Euler(Vector3.up * 90)) as GameObject;
                newTile3.transform.position += new Vector3(16, 0, 16);
                newTile3.name = "GOSPODIN LIJEPI";
                newTile3.transform.parent = tileHolder;
                direction = Vector3.left;
            }
            if (direction == Vector3.forward)
            {
                initPosition += upCheck;
                GameObject newTile = Instantiate(liftTile, initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile.name = "LIFT" + N;
                newTile.transform.parent = tileHolder;
                direction = Vector3.forward;
                //
                initPosition += Vector3.up * 100f + upCheck;
                GameObject newTile1 = Instantiate(straightTileType[0], initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile1.transform.position += new Vector3(0, 0, -16);
                newTile1.name = "FINAL 1";
                newTile1.transform.parent = tileHolder;
                direction = Vector3.forward;
                //
                initPosition += upCheck;
                GameObject newTile2 = Instantiate(bigTerrain, initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile2.transform.position += new Vector3(-8, 0, -24);
                newTile2.name = "FINAL 2";
                newTile2.transform.parent = tileHolder;
                direction = Vector3.forward;
                generateTile6(newTile2, 1);
                //
                initPosition += new Vector3(240, 0, 272);
                GameObject newTile3 = Instantiate(finishTile, initPosition, Quaternion.Euler(Vector3.up * 180)) as GameObject;
                newTile3.name = "GOSPODIN LIJEPI";
                newTile3.transform.parent = tileHolder;
                direction = Vector3.forward;
            }
            if (direction == Vector3.right)
            {
                initPosition += rightCheck;
                GameObject newTile = Instantiate(liftTile, initPosition, Quaternion.Euler(Vector3.up * 90)) as GameObject;
                newTile.transform.position += new Vector3(-16, 0, 16);
                newTile.name = "LIFT" + N;
                newTile.transform.parent = tileHolder;
                direction = Vector3.right;
                //
                initPosition += Vector3.up * 100f + rightCheck;
                GameObject newTile1 = Instantiate(straightTileType[0], initPosition, Quaternion.Euler(Vector3.up * 90)) as GameObject;
                newTile1.transform.position += new Vector3(-32, 0, 16);
                newTile1.name = "FINAL 1";
                newTile1.transform.parent = tileHolder;
                direction = Vector3.right;
                //
                initPosition += rightCheck;
                GameObject newTile2 = Instantiate(bigTerrain, initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile2.transform.position += new Vector3(-40, 0, 8);
                newTile2.name = "FINAL 2";
                newTile2.transform.parent = tileHolder;
                direction = Vector3.right;
                generateTile6(newTile2, 1);
                //
                initPosition += new Vector3(272, 0, 240);
                GameObject newTile3 = Instantiate(finishTile, initPosition, Quaternion.Euler(Vector3.up * -90)) as GameObject;
                newTile3.transform.position += new Vector3(-16, 0, 16);
                newTile3.name = "GOSPODIN LIJEPI";
                newTile3.transform.parent = tileHolder;
                direction = Vector3.right;
            }
            if (direction == Vector3.back)
            {
                initPosition += downCheck;
                GameObject newTile = Instantiate(liftTile, initPosition, Quaternion.Euler(Vector3.up * 180)) as GameObject;
                newTile.transform.position -= new Vector3(0, 0, -32);
                newTile.name = "LIFT" + N;
                newTile.transform.parent = tileHolder;
                direction = Vector3.back;
                //
                initPosition += Vector3.up * 100f + downCheck;
                GameObject newTile1 = Instantiate(straightTileType[0], initPosition, Quaternion.Euler(Vector3.up * 180)) as GameObject;
                newTile1.transform.position += new Vector3(0, 0, 48);
                newTile1.name = "FINAL 1";
                newTile1.transform.parent = tileHolder;
                direction = Vector3.back;
                //
                initPosition += downCheck;
                GameObject newTile2 = Instantiate(bigTerrain, initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile2.transform.position += new Vector3(-8, 0, -200);
                newTile2.name = "FINAL 2";
                newTile2.transform.parent = tileHolder;
                direction = Vector3.back;
                generateTile6(newTile2, 1);
                //
                initPosition += new Vector3(240, 0, -272);
                GameObject newTile3 = Instantiate(finishTile, initPosition, Quaternion.Euler(Vector3.up * 0)) as GameObject;
                newTile3.transform.position -= new Vector3(0, 0, -32);
                newTile3.name = "GOSPODIN LIJEPI";
                newTile3.transform.parent = tileHolder;
                direction = Vector3.back;
            }
        }

    }
}