using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPlacementController : MonoBehaviour
{
    [SerializeField] GameObject[] _placeableGroundPrefabs;
    [SerializeField] GameObject[] _placeableEvergreenPrefabs;
    [SerializeField] GameObject[] _placeableBirchPrefabs;

    public void SpawnGoundBlueprint(int groundToSpawn)
    {
        Instantiate(_placeableGroundPrefabs[groundToSpawn], transform.position, transform.rotation);
    }

    public void SpawnEvergreenBlueprint(int evergreenToSpawn)
    {
        Instantiate(_placeableEvergreenPrefabs[evergreenToSpawn], transform.position, transform.rotation);
    }

    public void SpawnBirchBlueprint(int birchToSpawn)
    {
        Instantiate(_placeableBirchPrefabs[birchToSpawn], transform.position, transform.rotation);
    }
}
