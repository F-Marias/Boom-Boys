using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playBtn;
    public Button trainingBtn;
    public Button optionsBtn;
    public Button howtpBtn;
    public Button exitBtn;
 
    public void Start()
    {
        playBtn.onClick.AddListener(PlayClick);
        trainingBtn.onClick.AddListener(TrainingClick);
        optionsBtn.onClick.AddListener(OptionsClick);
        howtpBtn.onClick.AddListener(HowTPClick);
        exitBtn.onClick.AddListener(ExitClick);
    }

    private void PlayClick() //go to char and map selection scene
    {
        throw new NotImplementedException();
    }

    private void TrainingClick() //go to training
    {
        throw new NotImplementedException();
    }

    private void OptionsClick() //open options
    {
        throw new NotImplementedException();
    }

    private void HowTPClick() //open how to play window
    {
        throw new NotImplementedException();
    }

    private void ExitClick()
    {
        Application.Quit();
    }
}
