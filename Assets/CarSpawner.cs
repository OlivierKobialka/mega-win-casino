using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;              // Car prefab with SpriteRenderer component
    public Sprite[] carSprites;               // Array to hold the car sprites
    public GameObject pointA;                 // Start point
    public GameObject pointB;                 // End point
    public int carCount = 5;                  // Number of cars to spawn
    public float minSpeed = 1f;               // Minimum speed for cars
    public float maxSpeed = 5f;               // Maximum speed for cars

    void Start()
    {
        LoadSpritesFromFolder();
        for (int i = 0; i < carCount; i++)
        {
            SpawnCar();
        }
    }

    // Load sprites from the "CarPack" folder into the carSprites array
    void LoadSpritesFromFolder()
    {
        carSprites = Resources.LoadAll<Sprite>("CarPack");
    }

    void SpawnCar()
    {
        // Instantiate the car prefab at point A's position
        GameObject car = Instantiate(carPrefab, pointA.transform.position, Quaternion.identity);

        // Randomly choose a sprite from the array and assign it to the car's SpriteRenderer
        SpriteRenderer carSpriteRenderer = car.GetComponent<SpriteRenderer>();
        carSpriteRenderer.sprite = carSprites[Random.Range(0, carSprites.Length)];

        // Get a random speed within the specified range
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Access and initialize the `movement` component
        movement carMovement = car.GetComponent<movement>();
        carMovement.Initialize(pointA, pointB, randomSpeed);
    }
}
