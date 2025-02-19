using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;        // Index of the scene to load
    public GameObject loadingScreen;  // Reference to the loading screen GameObject
    public UnityEngine.UI.Slider progressBar; // Reference to the progress bar (Slider)

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Start loading the next scene
            print("Switching Scene to " + sceneBuildIndex);
            StartCoroutine(LoadSceneWithLoadingScreen(sceneBuildIndex));
        }
    }

    private IEnumerator LoadSceneWithLoadingScreen(int sceneIndex)
    {
        // Activate the loading screen
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        // Begin loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Prevent the scene from activating immediately
        operation.allowSceneActivation = false;

        // Update progress
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // Update progress bar if available
            if (progressBar != null)
            {
                progressBar.value = progress;
            }

            // Check if the scene is fully loaded
            if (operation.progress >= 0.9f)
            {
                // Allow activation once the loading is complete
                operation.allowSceneActivation = true;
            }

            yield return null; // Wait for the next frame
        }
    }
}
