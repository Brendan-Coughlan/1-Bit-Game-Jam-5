using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private Vector2 forestSpawnArea;
    [SerializeField] private int treeCount;

    private void Start()
    {
        for(int i = 0; i < treeCount; i++)
        {
            Instantiate(treePrefab, new Vector3(Random.Range(-forestSpawnArea.x, forestSpawnArea.x), Random.Range(-forestSpawnArea.y, forestSpawnArea.y), 0), Quaternion.identity);
        }
    }
}
