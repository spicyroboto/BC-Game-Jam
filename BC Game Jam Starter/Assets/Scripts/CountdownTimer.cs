using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    /// <summary>
    /// Used to determine final score in Game Over
    /// </summary>
    /// <remarks>
    /// This is bad. Should not be using static variable to send info between scenes. Fix later if time.
    /// </remarks>
    public static float globalTimer;

    /// <summary>
    /// Time remaining in scene
    /// </summary>
    /// <remarks>
    /// Set in editor
    /// </remarks>
    public float timeRemaining = 5;

    public Text timerText;

    /// <summary>
    /// Next scene to load
    /// </summary>
    /// <remarks>
    /// Set this in the editor
    /// </remarks>
    public string levelToLoad;

    void Update()
    {
        SubtractTimeLeft(Time.deltaTime);
        UpdateText(Mathf.Floor(timeRemaining).ToString());
        GameOver();
    }

    /// <summary>
    /// Reduce <see cref="timeRemaining"/> by a specified amount.
    /// </summary>
    /// <param name="delta">The amount to subtract the time by.</param>
    private void SubtractTimeLeft(float delta)
    {
        timeRemaining -= delta;
        globalTimer = timeRemaining;
    }


    /// <summary>
    /// Determines whether level is over by checking time remaining
    /// </summary>
    private void GameOver()
    {
        if (timeRemaining <= 1)
            SceneManager.LoadScene(levelToLoad);
    }
    
    
    /// <summary>
    /// Updates current score
    /// </summary>
    /// <param name="textToUpdateWith"></param>
    private void UpdateText(string textToUpdateWith)
    {
        timerText.text = textToUpdateWith;
    }
}