using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    public GameObject whitePlatform;
    public GameObject pinkPlatform;
    public Transform playerTransform;
    public float spawnHeightOffset = 2f;
    public int numberOfPlatforms;
    public float pinkPlatformProbability = 0.5f;

    private Vector3 lastPlatformPosition;
    private float platformMinX = -5.5f;
    private float platformMaxX = 5.5f;
    private float platformMinY = 2.25f;
    private float platformMaxY = 2.25f;

    void Start()
    {
        lastPlatformPosition = new Vector3(0, 0, 0);

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (playerTransform.position.y > lastPlatformPosition.y - spawnHeightOffset)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float posX = Random.Range(platformMinX, platformMaxX);
        float posY = lastPlatformPosition.y + Random.Range(platformMinY, platformMaxY);
        Vector3 spawnPosition = new Vector3(posX, posY, 0);

        float randomValue = Random.value;
        GameObject platformToSpawn = randomValue <= pinkPlatformProbability ? pinkPlatform : whitePlatform;

        GameObject platform = Instantiate(platformToSpawn, spawnPosition, Quaternion.identity);
        lastPlatformPosition = platform.transform.position;
    }
}
