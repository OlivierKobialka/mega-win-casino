using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepsScript : MonoBehaviour
{
    public GameObject footstep;
    private bool isMoving = false; // Tracks if any movement keys are pressed

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any movement keys are pressed
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            if (!isMoving) // Prevents repeated activation
            {
                footsteps();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving) // Only stop footsteps if previously moving
            {
                StopFootsteps();
                isMoving = false;
            }
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}
