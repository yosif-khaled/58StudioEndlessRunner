// This script needs some serious work done
// will keep for now, but will defineey refine it later
// Idea is I want to place an empty game object to spawn trigger to add curved roads if I want to later

using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private float tileSpawnPos = -10; // on z-axis
    [SerializeField] private int onScreenTilesNumber;
    [SerializeField] private Transform playerTransform; // might be a problem if I want to scale up - may be I should use FindGOTag"Player"

    private List<GameObject> onScreenTiles = new List<GameObject>();
    private float tileSize = 10; // hardcoded -- try to fix that later

    private void Start()
    {
        onScreenTilesNumber = 10;

        for (int i = 0; i < onScreenTilesNumber; i++)
        {
            if (i == 0)
            {

                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, tiles.Length));
            }
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - (tileSize * 1.5) > (tileSpawnPos - (onScreenTilesNumber * tileSize)))
        {
            SpawnTile(Random.Range(1, tiles.Length));
            DestroyOffScreenTile();

        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject newTile;
        //newTile = Instantiate(tiles[tileIndex], spawnPosition, transform.rotation);
        newTile = Instantiate(tiles[tileIndex]) as GameObject; // weird syntax
        newTile.transform.SetParent(transform);
        //Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, tileSpawnPos);
        newTile.transform.position = Vector3.forward * tileSpawnPos;
        onScreenTiles.Add(newTile);
        tileSpawnPos += tileSize;
    }

    private void DestroyOffScreenTile()
    {
        Destroy(onScreenTiles[0]);
        onScreenTiles.RemoveAt(0);
    }
}