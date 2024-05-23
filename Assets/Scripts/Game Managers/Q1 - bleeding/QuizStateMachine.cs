using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStateMachine : MonoBehaviour
{
    public enum GameState
    {
        Preparation, // setup - load questions
        QuestionDisplay, // choose question + await+get answer
        QuestionResult, // transitional between new Question and results
        QuizResultDisplay, // finish quiz with resulting points + trophy showcase
        Default // waiting for start
    }

    private GameState currentState;

    public GameObject quizUIManager;
    public QuizManager quizManager;
    public QuestionManager questionManager;
    private List<QuestionData> questionsList;

    //public HintManager hintManager;
    //private List<HintData> hintsList;


    public int questionsListSize; // keeps the size of the questions list
    public int quizQuestionsCount; // keeps track of how many questions are left to be shown
    public int currentQuestionIndex; // keeps the index of the currently displayed question
    public QuestionData chosenQuestion; // keeps the data of the current question
    public List<int> usedQuestionIndexList = new List<int>(); // keeps indexes of used questions

    public int score;

    public bool startQuiz; // tracks if user activated the quiz

    public void Activate()
    {
        Debug.Log("Activated!");
        currentState = GameState.Preparation;
        startQuiz = true;
        quizQuestionsCount = 0;
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started!");
        currentState = GameState.Default;
        quizManager = quizUIManager.GetComponent<QuizManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentState == GameState.Preparation)
        {
            Debug.Log("Preparation");
            questionsList = questionManager.quizData.questions;
            //hintsList = hintManager.hintData.hints; // show hints only after user pressed a button
            questionsListSize = questionsList.Count;
            // loading a list of questions + activating panel

            if (startQuiz) { currentState = GameState.QuestionDisplay; }
        }

        else if (currentState == GameState.QuestionDisplay)
        {
            /* IF there were 0 or less then Q list size questions used - show new question
            ELSE - go to QuizResult state */

            /*1 - pick a random question
            2 - check number of answer options
            3 - call quizManager functions to show+fill correct question panel
            4 - go to QuestionResult*/

            if ((quizQuestionsCount == 0) || (quizQuestionsCount <= questionsListSize))
            {
                QuestionIndex(); // PICKING INDEX

                chosenQuestion = questionsList[currentQuestionIndex]; // using chosen index

                Debug.Log("Current question is number " + currentQuestionIndex + " and correct answer is " + chosenQuestion.correctAnswerIndex);

                // CHOOSING PANEL TO SHOW
                if (chosenQuestion.answerOptions.Count == 2)
                {
                    quizManager.DisplayQuestion2Options(chosenQuestion);
                    currentState = GameState.QuestionResult;
                }
                else if (chosenQuestion.answerOptions.Count == 3)
                {
                    quizManager.DisplayQuestion3Options(chosenQuestion);
                    currentState = GameState.QuestionResult;
                }
                else if (chosenQuestion.answerOptions.Count == 4)
                {
                    quizManager.DisplayQuestion4Options(chosenQuestion);
                    currentState = GameState.QuestionResult;
                }

                // after showing Q - wait answer in state QuestionResult
            }
        }

        else if (currentState == GameState.QuestionResult)
        {
            /* check answer - CORRECT -> score++ ||| WRONG -> show hint of correct question by index
            check the number of shown questions VS total number of question
            if equals - proceed to QuizResultDisplay* ||| if less - restart QuestionDisplay + currentQuestionIndex == null */

            if (quizManager.userAnswered)
            {
                if (CheckAnswer(chosenQuestion.correctAnswerIndex) == true)
                {
                    quizQuestionsCount++;
                    score++;
                    Debug.Log("Correct answer. Going to display next question. Points: " + score);
                }
                else
                {
                    quizQuestionsCount++;
                    Debug.Log("Wrong answer. Going to display next question. Points: " + score);
                    //quizManager.ShowHint(chosenQuestion.hint);
                }
                quizManager.chosenOptionIndex = -1;
                quizManager.userAnswered = false;

                if (quizQuestionsCount == questionsListSize)
                {
                    quizManager.chosenOptionIndex = -1;
                    currentState = GameState.QuizResultDisplay;
                }
                else
                {
                    currentState = GameState.QuestionDisplay;
                }
            }
        }

        else if (currentState == GameState.QuizResultDisplay)
        {
            // count all points
            quizManager.ShowResults(score, questionsListSize);
            // close panel through QuizManager
        }
        else if (currentState == GameState.Default)
        {
            Debug.Log("Waiting for the quiz to start.");
        }
    }

    public void QuestionIndex()
    {
        int randomIndex = UnityEngine.Random.Range(0, questionsList.Count);
        while (usedQuestionIndexList.Contains(randomIndex))
        {
            randomIndex = UnityEngine.Random.Range(0, questionsList.Count);
        }

        currentQuestionIndex = randomIndex;
        Debug.Log("Picking question index: " + currentQuestionIndex);
        usedQuestionIndexList.Add(currentQuestionIndex);
    }

    bool CheckAnswer(int correctAnswer)
    {
        Debug.Log("Checking answer!");
        if (quizManager.chosenOptionIndex == correctAnswer)
        {
            score = score + 1;
            return true;
        }
        else
        {
            return false;
        }
    }
}
