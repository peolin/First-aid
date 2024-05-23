using System.Security.AccessControl;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class HintManager : MonoBehaviour
{
    public QuizHints hintData;
    private string fileName = "D:\\ДИСЕРТАЦІЯ\\Проєкт\\Перша допомога\\Assets\\JSON\\Q1 Hints - bleeding.json"; //JSON filepath
    private string jsonString;

    // property to access hints list
    public List<HintData> Hints
    {
        get { return hintData.hints; }
    }
    // Start is called before the first frame update
    void Start()
    {
        jsonString = File.ReadAllText(fileName);

        // Function to return an instance of an object from it's JSON representation
        hintData = JsonUtility.FromJson<QuizHints>(jsonString);
        List<HintData> hints = hintData.hints;

    }
}

// plain class for HINT object from json
[System.Serializable]
public class HintData
{
    public string hintText;
    public int questionIndex;
}

// structure-class for a list of HINT+question index objects
[System.Serializable]
public class QuizHints
{
    public List<HintData> hints;
}

