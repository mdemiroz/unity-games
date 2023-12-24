using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start() {
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
        // DisplayQuestion();
    }

    void Update() {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion) {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        } else if(!hasAnsweredEarly && !timer.isAnsweringQuestion) {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void DisplayQuestion() {
        questionText.text = question.GetQuestion();

        for(int i = 0; i<answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index) {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index) {
        correctAnswerIndex = question.GetCorrectAnswerIndex();

        //if the answer is correct
        if(index == correctAnswerIndex) {
            questionText.text = "Correct";
        } else {
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was: " + correctAnswer;
        }

        Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }

    void GetNextQuestion() {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    void SetButtonState(bool state) {
        for(int i = 0; i<answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite() {
        for(int i = 0; i<answerButtons.Length; i++) {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
