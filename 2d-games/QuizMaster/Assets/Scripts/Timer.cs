 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour {
    
    [SerializeField] float timeToCompleteQuestion;
    [SerializeField] float timeToShowCorrectAnswer;

    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnsweringQuestion = false;
    float timerValue;

    void Update() {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion) {
            if(timerValue > 0) {
                // calculate the time circle area
                fillFraction = timerValue / timeToCompleteQuestion;
            } else {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
        } else {
            if(timerValue > 0) {
                // calculate the time circle area
                fillFraction = timerValue / timeToShowCorrectAnswer;
            } else {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }

        Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
