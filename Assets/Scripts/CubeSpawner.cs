using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CubeMover spawnCube;

    private List<GameObject> cubes = new List<GameObject>();
    public void ClearCubes()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            Destroy(cubes[i]);
        }

        cubes.Clear();
    }

    public void StartSpawn()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer ()
    {
        yield return new WaitForSeconds(InputParams.Instance.CurrentTime);
        Spawn();
        StartCoroutine(SpawnTimer());
    }
    private void Spawn()
    {
        cubes.Add(Instantiate(spawnCube, spawnPoint.position, Quaternion.identity).gameObject);
    }
}
