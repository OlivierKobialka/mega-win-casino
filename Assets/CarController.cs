using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform pointA; // Starting point
    public Transform pointB; // Destination point
    public GameObject[] carPrefabs; // Array of car prefabs

    private GameObject currentCar;
    private float speed;

    void Start()
    {
        SpawnCar();
    }

    void SpawnCar()
    {
        // Randomly select a car prefab
        int randomIndex = Random.Range(0, carPrefabs.Length);
        currentCar = Instantiate(carPrefabs[randomIndex], pointA.position, Quaternion.identity);

        // Assign a random speed
        speed = Random.Range(15f, 30f);

        // Start the movement coroutine
        StartCoroutine(MoveCar());
    }

    IEnumerator MoveCar()
    {
        while (Vector2.Distance(currentCar.transform.position, pointB.position) > 0.1f)
        {
            // Move the car towards point B
            currentCar.transform.position = Vector2.MoveTowards(currentCar.transform.position, pointB.position, speed * Time.deltaTime);
            yield return null;
        }

        // Despawn the car after it reaches point B
        Destroy(currentCar);

        // Optionally, spawn a new car after a delay
        yield return new WaitForSeconds(2f);
        SpawnCar();
    }
}
