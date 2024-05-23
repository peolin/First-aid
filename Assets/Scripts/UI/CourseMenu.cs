using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject lessonPanel;
    public GameObject quizPanel;

    public QuizStateMachine stateMachine; // awake script a the start of the quiz

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(true);
        lessonPanel.SetActive(false);
        quizPanel.SetActive(false);
    }

    public void StartQuiz()
    {
        Debug.Log("Activated quiz!");
        menuPanel.SetActive(false);
        lessonPanel.SetActive(false);
        quizPanel.SetActive(true);
        stateMachine.Activate();
    }

    public void StartLesson()
    {
        menuPanel.SetActive(false);
        lessonPanel.SetActive(true);
        quizPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
