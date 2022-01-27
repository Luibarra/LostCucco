using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class TreePool : MonoBehaviour
{
    public GameObject treePrefab;                                    
    public int treePoolSize = 5;                                    
    public float spawnRate = 3f;                                    
    public float columnMin = -1f;                                    
    public float columnMax = 3.5f;                                    

    private GameObject[] columns;                                   
    private int currentTree = 0;                                    

    private Vector2 objectPoolPosition = new Vector2(-15, -25);        
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;
        columns = new GameObject[treePoolSize];

        for (int i = 0; i < treePoolSize; i++)
        {
           
            columns[i] = (GameObject)Instantiate(treePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentTree].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentTree++;

            if (currentTree >= treePoolSize)
            {
                currentTree = 0;
            }
        }
    }
}
