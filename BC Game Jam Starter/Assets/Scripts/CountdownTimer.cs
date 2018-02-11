using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float globalTimer;

    public float timeRemaining = 5;
    public Text timerText;
    public string levelToLoad;


    void Start()
    {
        
    }

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

    private void GameOver()
    {
        if (timeRemaining <= 1)
            SceneManager.LoadScene(levelToLoad);
    }
    
    

    private void UpdateText(string textToUpdateWith)
    {
        timerText.text = textToUpdateWith;
    }
}