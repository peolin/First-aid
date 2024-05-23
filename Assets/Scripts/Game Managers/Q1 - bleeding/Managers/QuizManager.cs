using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    //START - choose Quiz or Quiz Lesson
    //QUIZ START -> activate lessons side-by-side by BACK and NEXT buttons
    //QUIZ -> depending on picked out of file Qx choose show panel with 2/3/4 answer options --->
    //-----> after picking OptionX check Qx answer and show NEXT --->
    //-----> after NEXT count points and show new Qx+1 --->
    //FINISH - after all Qx out of N questions in file --->
    //SHOW RESULTS - display score

    //LESSON START -> no BACK on slide0 + NEXT on slide6 returns to menu
    //LESSON -> BACK + NEXT buttons to rotate slides
    public GameObject quizManagement;
    public QuizStateMachine stateMachine;
    public HintManager hintManager;
    private List<HintData> hintsList;

    public GameObject menuPanel;
    public GameObject quizPanel;

    // PANELS FOR QUESTIONS  with 2/3/4 answer options
    public GameObject panel2Options;
    public GameObject panel3Options;
    public GameObject panel4Options;
    public int chosenOptionIndex;

    public TextMeshProUGUI hintText;

    public bool userAnswered;

    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scorePoints;

    public GameObject nextQuestionButton;
    public GameObject backToCourseButton;

    void Start()
    {
        panel2Options.SetActive(false);
        panel3Options.SetActive(false);
        panel4Options.SetActive(false);
        resultPanel.SetActive(false);
        nextQuestionButton.SetActive(true);
        backToCourseButton.SetActive(false);
        chosenOptionIndex = -10;
        userAnswered = false;
        hintManager = this.GetComponent<HintManager>();
        stateMachine = quizManagement.GetComponent<QuizStateMachine>();
        hintsList = hintManager.hintData.hints; // show hints only after user pressed a button
        hintText.text = "Потрібна підказка? Просто натисни на мене!";
    }

    //public QuestionManager questionManager; // ref to QUESTION MANAGER parser - all questions + answers in Questions-property
    //public HintManager hintManager; // ref to HINT MANAGER parser - all hints + corresponding questions indexes - property
    //public QuizStateMachine stateMachine; // ref to STATE MACHINE


    public void DisplayQuestion2Options(QuestionData chosenQuestion)
    {
        Debug.Log("Show Q2O");
        panel2Options.SetActive(true);
        panel3Options.SetActive(false);
        panel4Options.SetActive(false);
        panel2Options.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = chosenQuestion.question;
        // UNCHECK + LABEL TOGGLE 0-1
        panel2Options.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[0].option;
        panel2Options.transform.GetChild(1).GetComponent<Toggle>().isOn = false;

        panel2Options.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[1].option;
        panel2Options.transform.GetChild(2).GetComponent<Toggle>().isOn = false;

        Debug.Log("Waiting for an answer - Q20.");
    }

    public void DisplayQuestion3Options(QuestionData chosenQuestion)
    {
        Debug.Log("Show Q3O");
        panel2Options.SetActive(false);
        panel3Options.SetActive(true);
        panel4Options.SetActive(false);
        panel3Options.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = chosenQuestion.question;
        // UNCHECK + LABEL TOGGLE 0-2
        panel3Options.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[0].option;
        panel3Options.transform.GetChild(1).GetComponent<Toggle>().isOn = false;

        panel3Options.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[1].option;
        panel3Options.transform.GetChild(2).GetComponent<Toggle>().isOn = false;

        panel3Options.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[2].option;
        panel3Options.transform.GetChild(3).GetComponent<Toggle>().isOn = false;

        Debug.Log("Waiting for an answer - Q30.");
    }

    public void DisplayQuestion4Options(QuestionData chosenQuestion)
    {
        Debug.Log("Show Q4O");
        panel2Options.SetActive(false);
        panel3Options.SetActive(false);
        panel4Options.SetActive(true);
        panel4Options.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = chosenQuestion.question;
        // UNCHECK + LABEL TOGGLE 0-3
        panel4Options.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[0].option;
        panel4Options.transform.GetChild(1).GetComponent<Toggle>().isOn = false;

        panel4Options.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[1].option;
        panel4Options.transform.GetChild(2).GetComponent<Toggle>().isOn = false;

        panel4Options.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[2].option;
        panel4Options.transform.GetChild(3).GetComponent<Toggle>().isOn = false;

        panel4Options.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>().text = chosenQuestion.answerOptions[3].option;
        panel4Options.transform.GetChild(4).GetComponent<Toggle>().isOn = false;

        Debug.Log("Waiting for an answer - Q40.");
    }

    public void BackToCourseMenu()
    {
        SceneManager.LoadScene(1);
        Start();
    }

    public void AnswerOption0()
    {
        chosenOptionIndex = 0;
    }

    public void AnswerOption1()
    {
        chosenOptionIndex = 1;
    }
    public void AnswerOption2()
    {
        chosenOptionIndex = 2;
    }
    public void AnswerOption3()
    {
        chosenOptionIndex = 3;
    }

    public void NextQuestion()
    {
        // checking if NONE of the options were chosen and user clicked NEXT at the START   0
        if (chosenOptionIndex == -10)
        {
            Debug.Log("No options were chosen at the START!");
            hintText.text = "Будь ласка, обери відповідь!";
            userAnswered = false;
        }
        // if ANY options were chosen and user clicked NEXT at the START
        // +                          1
        // if ANY options were chosen DURING quiz - return Index to default value for next Question
        else if ((chosenOptionIndex == 0) || (chosenOptionIndex == 1) || (chosenOptionIndex == 2) || (chosenOptionIndex == 3))
        {
            Debug.Log("Option was chosen: " + chosenOptionIndex);
            userAnswered = true;
            hintText.text = "Потрібна підказка? Просто натисни на мене!";
        }
        // if NONE options were chosen during quiz   -1
        else if (chosenOptionIndex == -1)
        {
            Debug.Log("No option was chosen!");
            hintText.text = "Будь ласка, обери відповідь!";
            userAnswered = false;
        }
    }

    public void ShowHint()
    {
        Debug.Log(stateMachine.currentQuestionIndex + " " + hintManager.hintData.hints.Count + " " + hintsList.Count);
        hintText.text = hintManager.hintData.hints[stateMachine.currentQuestionIndex].hintText;
    }

    public void ShowResults(int score, int questionCount)
    {
        panel2Options.SetActive(false);
        panel3Options.SetActive(false);
        panel4Options.SetActive(false);
        resultPanel.SetActive(true);
        nextQuestionButton.SetActive(false);
        backToCourseButton.SetActive(true);

        double points = score * 12 / questionCount;
        scorePoints.text = points.ToString();
        if ((points == 0) || (points <= 6))
        {
            resultText.text = "Спробуй пройти тест ще раз!";
        }
        else if ((points > 6) && (points <= 9))
        {
            resultText.text = "Непоганий результат! Спробуй пройти тест ще раз.";
        }
        else if ((points > 9) && (points <= 11))
        {
            resultText.text = "Хороший результат! Спробуй пройти тест ще раз.";
        }
        else if (points == 12)
        {
            resultText.text = "Відмінний результат!";
        }
        hintText.text = "Перевір свою оцінку!";
        chosenOptionIndex = -10;
        userAnswered = false;
    }
}
