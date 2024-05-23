using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject bottom_panel;
    public GameObject mainMenu_panel;
    public GameObject settings_panel;
    public GameObject langSelect_panel;
    //public GameObject achievement_panel;
    //public GameObject trophies_panel;
    public GameObject courses_panel;
    public AudioSource audioSource;
    public TextMeshProUGUI messageText;

    // Start is called before the first frame update
    void Start()
    {
        bottom_panel.SetActive(true);
        mainMenu_panel.SetActive(true);
        settings_panel.SetActive(false);
        langSelect_panel.SetActive(false);
        //achievement_panel.SetActive(false);
        //trophies_panel.SetActive(false);
        courses_panel.SetActive(false);
        messageText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {

    }

    //---------------STUFF IN COURCES PANEL-------------------------
    public void Courses()
    {
        //bottom_panel.SetActive(true);
        mainMenu_panel.SetActive(false);
        settings_panel.SetActive(false);
        langSelect_panel.SetActive(false);
        //achievement_panel.SetActive(false);
        //trophies_panel.SetActive(false);
        courses_panel.SetActive(true);
        messageText.text = " ";
    }

    /*public void Cources1()
    {
        SceneManager.LoadScene(1); // LOAD CHOSEN COURCE'S SCENE
    }*/

    //---------------STUFF IN MAIN MENU PANEL-----------------------
    public void Menu()
    {
        //bottom_panel.SetActive(true);
        mainMenu_panel.SetActive(true);
        settings_panel.SetActive(false);
        langSelect_panel.SetActive(false);
        //achievement_panel.SetActive(false);
        //trophies_panel.SetActive(false);
        courses_panel.SetActive(false);
        messageText.text = " ";
    }

    //-----------STUFF IN ACHIEVEMENTS PANEL------------------------
    public void Courses1()
    {
        //SceneManager.LoadScene(1); // LOAD CHOSEN ACHIEVEMENTS SCENE
    }

    //-----------STUFF IN TROPHIES PANEL----------------------------
    public void Trophies()
    {
        //SceneManager.LoadScene(1); // LOAD CHOSEN TROPHIES SCENE
    }

    //-----------STUFF IN SETTINGS PANEL----------------------------
    public void Settings()
    {
        mainMenu_panel.SetActive(false);
        settings_panel.SetActive(true);
        messageText.text = " ";
    }

    public void Settings_sound_toggle(System.Boolean toggleValue)
    {
        //System.Boolean toggleValue = 
        if (toggleValue == false)
        {
            Debug.Log("Turn off audio");
            audioSource.mute = true;
        }
        else
        {
            Debug.Log("Turn on audio");
            audioSource.mute = false;
        }
    }

    public void Settings_lang_select()
    {
        settings_panel.SetActive(false);
        langSelect_panel.SetActive(true);
    }

    public void Settings_lang_select_ua()
    {
        // switching language to Ukrainian
    }

    public void Settings_lang_select_eng()
    {
        // switching language to English
    }

    public void Settings_lang_select_back()
    {
        settings_panel.SetActive(true);
        langSelect_panel.SetActive(false);
    }

    public void GoToQuiz0()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToQuiz1()
    {
        //SceneManager.LoadScene(2);
        messageText.text = "Ми працюємо над доданням інших курсів! Спробуй пройти наш перший курс - Перша допомога: Кровотеча!";
    }

    public void GoToQuiz2()
    {
        //SceneManager.LoadScene(3);
        messageText.text = "Ми працюємо над доданням інших курсів! Спробуй пройти наш перший курс - Перша допомога: Кровотеча!";
    }

    public void GoToQuiz3()
    {
        //SceneManager.LoadScene(4);
        messageText.text = "Ми працюємо над доданням інших курсів! Спробуй пройти наш перший курс - Перша допомога: Кровотеча!";
    }
}
