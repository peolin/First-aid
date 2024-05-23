using System.Security.AccessControl;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public QuizQuestions quizData;
    private string fileName = "D:\\ДИСЕРТАЦІЯ\\Проєкт\\Перша допомога\\Assets\\JSON\\Q1 Questions - bleeding.json"; //JSON filepath
    private string jsonString;

    // property to access full question list
    public List<QuestionData> Questions
    {
        get { return quizData.questions; }
    }

    void Start()
    {
        jsonString = File.ReadAllText(fileName);

        // Function to return an instance of an object from it's JSON representation
        quizData = JsonUtility.FromJson<QuizQuestions>(jsonString);
        List<QuestionData> questions = quizData.questions;
    }
}

// structure for all answer options
[System.Serializable]
public struct AnswerOptions
{
    public string option;
    public int index;
}

// plain class for Question object from json
[System.Serializable]
public class QuestionData
{
    public string question;
    public List<AnswerOptions> answerOptions; // list for all answer options + indexing
    public int correctAnswerIndex;

    // public string hint;
}

// structure-class for a list of Question+answers+indexing objects
[System.Serializable]
public class QuizQuestions
{
    public List<QuestionData> questions;
}