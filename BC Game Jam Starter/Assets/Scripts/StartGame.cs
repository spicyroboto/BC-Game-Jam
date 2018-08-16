using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    /// <summary>
    /// Next scene to load
    /// </summary>
    /// <remarks>
    /// Set this in the editor
    /// </remarks>
    public string levelToLoad;

    /// <summary>
    /// Prevents next scene from being called more than once
    /// </summary>
    private bool distorting;

    private void Start()
    {
        distorting = false;
    }


    /// <summary>
    /// Distorts screen when player chooses to start a new game
    /// </summary>
    public void GameStart()
    {
        // Don't start two coroutines
        if (distorting == true) { return; }
        distorting = true;

        StartCoroutine("SceneDistortion");
    }

    /// <summary>
    /// Distorts the scene by pixelating over time
    /// </summary>
    IEnumerator SceneDistortion()
    {
        var distortion = GetComponent<PixelScreenDistortion>();
        float timePassed = 0;

        while (true)
        {
            if (timePassed > 3.4f)
            {
                break;
            }

            timePassed += Time.deltaTime;

            distortion.PixelGranularity = 16.0f * (timePassed / 3.4f);

            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
