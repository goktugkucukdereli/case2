using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawned = delegate { };
    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (MoveCube.CurrentCube != null)
                MoveCube.CurrentCube.Stop();

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];
            currentSpawner.SpawnCube();
            OnCubeSpawned();
        }
    }
}
