using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrefabs;
    public GameObject StartBlock;

    private Vector3 startPosition;


    private float startblockZPos;
    private float blockLength = 0;
    private int blockCount = 7;
    private int safeZone = 15;

    public Transform PlayerTransform;
    List<GameObject> CurrentBlocks = new List<GameObject>();



    void Start()
    {
        startblockZPos = StartBlock.transform.position.z;
        blockLength = StartBlock.GetComponent<BoxCollider>().bounds.size.z;
        startPosition = PlayerTransform.position;
        Destroy(StartBlock);

        StartGame();

    }

    public void StartGame()
    {
        PlayerTransform.position = startPosition;

        foreach (var block in CurrentBlocks)
        {
            Destroy(block);
        }
        CurrentBlocks.Clear();

        for (int i = 0; i < blockCount; ++i)
        {
            SpawnBlock();
        }
    }

    private void SpawnBlock()
    {
        GameObject block = Instantiate(RoadBlockPrefabs[Random.Range(0, RoadBlockPrefabs.Length)], transform);
        Vector3 blockPos;

        if (CurrentBlocks.Count > 0)
        {
            blockPos = CurrentBlocks[CurrentBlocks.Count - 1].transform.position + new Vector3(0, 0, -blockLength);
        }
        else
        {
            blockPos = new Vector3(0, 0, startblockZPos);
        }

        block.transform.position = blockPos;
        CurrentBlocks.Add(block);
    }

    void LateUpdate()
    {
        CheckForSpawn();
    }

    private void CheckForSpawn()
    {
        if (CurrentBlocks[0].transform.position.z - PlayerTransform.position.z > safeZone)
        {
            SpawnBlock();
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        Destroy(CurrentBlocks[0].gameObject);
        CurrentBlocks.RemoveAt(0);
    }
}
