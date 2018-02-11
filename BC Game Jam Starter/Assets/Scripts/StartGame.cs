using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public string levelToLoad;

    private bool distoring;

    private void Start()
    {
        distoring = false;
    }

    public void GameStart()
    {
        // Don't start two coroutines
        if (distoring == true) { return; }
        distoring = true;

        StartCoroutine("SceneDistortion");
    }

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
