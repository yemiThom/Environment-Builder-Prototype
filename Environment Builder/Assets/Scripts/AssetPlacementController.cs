using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPlacementController : MonoBehaviour
{
    [SerializeField] GameObject[] _placeableGroundPrefabs;
    [SerializeField] GameObject[] _placeableFloraPrefabs;
    [SerializeField] GameObject[] _placeableRockPrefabs;
    [SerializeField] GameObject[] _placeableMountainPrefabs;

    public void SpawnGoundBlueprint(int groundToSpawn)
    {
        Instantiate(_placeableGroundPrefabs[groundToSpawn], transform.position, transform.rotation);
    }

    public void SpawnFloraBlueprint(int floraToSpawn)
    {
        Instantiate(_placeableFloraPrefabs[floraToSpawn], transform.position, transform.rotation);
    }

    public void SpawnRockBlueprint(int rockToSpawn)
    {
        Instantiate(_placeableRockPrefabs[rockToSpawn], transform.position, transform.rotation);
    }

    public void SpawnMountainBlueprint(int mountainToSpawn)
    {
        Instantiate(_placeableMountainPrefabs[mountainToSpawn], transform.position, transform.rotation);
    }
}
