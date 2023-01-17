using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL = 10f;

    [SerializeField] private Transform levelStart;
    [SerializeField] private List<Transform> levelList;

    [SerializeField] private PlayerMovement Player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelStart.Find("EndPosition").position;

        int startingSpawnLevels = 3;
        for (int i = 0; i < startingSpawnLevels; i++)
        {
            SpawnLevel();
        }


    }

    private void Update()
    {
        if (Vector2.Distance(Player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL)
        {
            SpawnLevel();
        }
    }
    private void SpawnLevel()
    {
        Transform chosenLevel = levelList[Random.Range(0, levelList.Count)];
        Transform lastLevelTransform = SpawnLevel(chosenLevel, lastEndPosition);
        lastEndPosition = lastLevelTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevel(Transform level, Vector2 spawnPosition)
    {
        Transform levelTransform = Instantiate(level, spawnPosition, Quaternion.identity);

        return levelTransform;
    }




}