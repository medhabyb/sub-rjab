using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spma : MonoBehaviour
{
    [SerializeField] private GameObject[] tPrefab;
    [SerializeField] private float zSpawn = 0;
    [SerializeField] private float tLength = 30;
    [SerializeField] private int numberOfTiles = 5;
    [SerializeField] private Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            SpawnTile(Random.Range(0, tPrefab.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tLength))
        {
            SpawnTile(Random.Range(0, tPrefab.Length));
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject gobj = Instantiate(tPrefab[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(gobj);
        zSpawn += tLength;
    }
}

