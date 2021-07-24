using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN = 50f;

    [SerializeField]
    private List<Transform> levelPartList;
    [SerializeField]
    private Transform start;
    [SerializeField]
    private PlayerController player;

    private Vector3 lastEndPosition;

    [SerializeField]
    internal float distanceBetweenMin;
    [SerializeField]
    internal float distanceBetweenMax;

    private float distanceBetween = 5;

    private float minHeight;


    private void Awake()
    {
        lastEndPosition = getPlatformPosition(start);
        distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
        int startingSpawn = 5;
        for (int i = 0; i < startingSpawn; i++)
        {
            SpawnLevelPart();
        }

    }
    private void Update()
    {
        distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN)
        {
            SpawnLevelPart();
        }

    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0,levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);


        lastEndPosition = getPlatformPosition(lastLevelPartTransform);
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) 
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity, transform);
        return levelPartTransform;
    }

    private Vector3 getPlatformPosition(Transform levelTransform)
    {
        float x = levelTransform.Find("EndPosition").position.x + distanceBetween;
        float y = levelTransform.Find("EndPosition").position.y;
        float z = levelTransform.Find("EndPosition").position.z;
        return new Vector3(x,y,z);
    }
}
