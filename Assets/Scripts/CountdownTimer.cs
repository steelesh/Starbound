using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    float currentTime = 0f;
    float startingTime = 3f;
    public bool timerFinished = false;
    private bool countdownStarted = false;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (!countdownStarted && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            countdownStarted = true;
        }

        if (countdownStarted)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                timerFinished = true;
                countdownText.enabled = false;
            }
        }
    }
}
