using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text instructionText;
    public Text finalScore;
    public string levelToLoad;
    public GameObject restartButton;
    public Movement playerScore;


    // Use this for initialization
    void Start()
    {

        StartCoroutine("RunEnding");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RunEnding()
    {
        yield return new WaitForSeconds(1); 
        instructionText.text = "*yawn*, oh man that such a weird dream.";
        yield return new WaitForSeconds(2);
        instructionText.text = "I think I won?";
        yield return new WaitForSeconds(2);

        //display score
        finalScore.text = "Final Score:  count - " + Movement.totalScore + " + " + "time remaining - " + (int)CountdownTimer.globalTimer;
        yield return new WaitForSeconds(5f);
        finalScore.text = "Final Score: " + (Movement.totalScore + (int)CountdownTimer.globalTimer);
        yield return new WaitForSeconds(2);

        restartButton.SetActive(true);
        
    }

    public void RestartGame()
    {
        Movement.totalScore = 0;
        CountdownTimer.globalTimer = 60;
        SceneManager.LoadScene(levelToLoad);
    }
}
