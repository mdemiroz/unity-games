using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    int correctAnswers;
    int questionsSeen;

    public int GetCorrectAnswers() {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers() {
        correctAnswers += 1;
    }

    public int GetQuestionsSeen() {
        return questionsSeen;
    }

    public void IncrementQuestionsSeen() {
        questionsSeen += 1;
    }

    public int CalculateScore() {
        return Mathf.RoundToInt(correctAnswers / (float) questionsSeen * 100);
    }

}
