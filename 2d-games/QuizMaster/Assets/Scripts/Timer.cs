 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour {
    
    [SerializeField] float timeToCompleteQuestion;
    [SerializeField] float timeToShowCorrectAnswer;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    public float fillFraction;

    float timerValue;

    void Update() {
        UpdateTime();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    void UpdateTime() {
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
