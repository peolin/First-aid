using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject lessonPanel;
    public GameObject[] lessonSlides = new GameObject[7];
    public GameObject backButton;
    public int slideIndex;
    public string logTxt;

    //START - choose Quiz or Quiz Lesson
    //QUIZ START -> activate lessons side-by-side by BACK and NEXT buttons
    //QUIZ -> depending on picked out of file Qx choose show panel with 2/3/4 answer options --->
    //-----> after picking OptionX check Qx answer and show NEXT --->
    //-----> after NEXT count points and show new Qx+1 --->
    //FINISH - after 10 Qx out of N questions in file --->
    //SHOW RESULTS - display score (1 answer == 1 point)

    //LESSON START -> no BACK on slide0 + NEXT on slide6 returns to menu
    //LESSON -> BACK + NEXT buttons to rotate slides

    public void StartLesson()
    {
        if (lessonPanel.activeSelf == true)
        {
            backButton.SetActive(false);
            lessonSlides[0].SetActive(true);
            slideIndex = 0;
            logTxt = "start";
        }
    }

    public void NextLessonSlide()
    {
        if (slideIndex == 0)
        {
            backButton.SetActive(true);
            lessonSlides[slideIndex].SetActive(false);
            lessonSlides[slideIndex + 1].SetActive(true);
            slideIndex++;
            logTxt = "from 0 to 1";
        }
        else if (slideIndex == 6)
        {
            lessonSlides[slideIndex].SetActive(false);
            lessonPanel.SetActive(false);
            menuPanel.SetActive(true);
            slideIndex = 0;
            logTxt = "last slide";
        }
        else if ((slideIndex > 0) & (slideIndex < 6))
        {
            lessonSlides[slideIndex].SetActive(false);
            lessonSlides[slideIndex + 1].SetActive(true);
            slideIndex++;
            logTxt = "from " + (slideIndex - 1) + " to " + slideIndex;
        }
    }

    public void PreviousLessonSlide()
    {
        if ((slideIndex > 1) & (slideIndex <= 6))
        {
            lessonSlides[slideIndex].SetActive(false);
            lessonSlides[slideIndex - 1].SetActive(true);
            slideIndex = slideIndex - 1;
        }
        else if (slideIndex == 1)
        {
            lessonSlides[slideIndex].SetActive(false);
            lessonSlides[slideIndex - 1].SetActive(true);
            slideIndex = slideIndex - 1;
            backButton.SetActive(false);
        }
    }
}
