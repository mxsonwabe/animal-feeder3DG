using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    InputAction _spawnAction;
    float _startDelay;
    float _spawnFreq;
    public GameObject[] animalPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startDelay = 3.0f;
        _spawnFreq = 0.5f;
        _spawnAction = InputSystem.actions.FindAction("Spawn");
        InvokeRepeating(nameof(SpawnRandomAnimal), _startDelay, _spawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        // if (_spawnAction.WasPressedThisFrame())
        // {
            // SpawnRandomAnimal();
        // }
        // Invokes the method specified after the given delay, at the given frequency
    }

    void SpawnRandomAnimal()
    {
        int animalIdx = Random.Range(0, animalPrefabs.Length);
        Vector3 pos = new (
            Random.Range(UtilsManager.minX, UtilsManager.maxX),
            0.0f,
            Random.Range(UtilsManager.minZ + (UtilsManager.maxZ / 2.0f), UtilsManager.maxZ)
        );
        Instantiate(
            animalPrefabs[animalIdx],
            pos,
            animalPrefabs[animalIdx].transform.rotation
        );
    }
}
