using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start() {
        DisplayQuiz();
    }

    void DisplayQuiz() {
        questionText.text = question.GetQuestion();

        for(int i = 0; i<answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index) {
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

        SetButtonState(false);
    }

    void GetNextQuiz() {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuiz();
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
