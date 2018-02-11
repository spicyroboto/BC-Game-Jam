using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private bool distoring;

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

    public void RestartGame()
    {
        // Don't start two coroutines
        if (distoring == true) { return; }
        distoring = true;

        StartCoroutine("SceneDistortion");      
    }

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
