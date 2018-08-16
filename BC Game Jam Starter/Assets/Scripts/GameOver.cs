using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Prevents restart game from being called more than once
    /// </summary>
    private bool distorting;

    /// <summary>
    /// Instruction text to be shown during sequence
    /// </summary>
    public Text instructionText;

    /// <summary>
    /// Final score text
    /// </summary>
    public Text finalScore;

    /// <summary>
    /// Next scene to load
    /// </summary>
    /// <remarks>
    /// Set this in the editor
    /// </remarks>
    public string levelToLoad;

    /// <summary>
    /// Button object that when pressed restarts the game
    /// </summary>
    public GameObject restartButton;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("RunEnding");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Coroutine that steps the player through the ending scene
    /// </summary>
    IEnumerator RunEnding()
    {
        yield return new WaitForSeconds(1);
        yield return AnimateText("* yawn*, oh man that was such a weird dream.");
        yield return new WaitForSeconds(1);
        if (Movement.totalScore >= 5)
        {
            yield return AnimateText("I think I won?");
        }
        else
        {
            yield return AnimateText("I don't think I got them all.");
        }
        yield return new WaitForSeconds(1);

        //display score
        yield return AnimateText("Final Score: " + (Movement.totalScore + (int)CountdownTimer.globalTimer));
        yield return new WaitForSeconds(2);

        restartButton.SetActive(true);
        
    }

    /// <summary>
    /// Allows player to restart the game while bypassing the tutorial
    /// </summary>
    public void RestartGame()
    {
        // Don't start two coroutines
        if (distorting == true) { return; }
        distorting = true;

        StartCoroutine("SceneDistortion");      
    }

    /// <summary>
    /// Makes text appear on screen gradually
    /// </summary>
    /// <param name="strComplete">
    /// The string to animate/show on screen
    /// </param>
    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        instructionText.text = "";
        while (i < strComplete.Length)
        {
            instructionText.text += strComplete[i++];
            yield return new WaitForSeconds(0.1f);
        }
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
        Movement.totalScore = 0;
        CountdownTimer.globalTimer = 60;
        SceneManager.LoadScene(levelToLoad);
    }
}
