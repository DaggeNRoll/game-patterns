using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class AchievementEngine : MonoBehaviour
{
    [SerializeField] private GameObject achievementTextObject;
    private TMP_Text _achievementText;
    public static AchievementEngine AchievementSystemInstance  = null;
    [SerializeField] private InputManagerCommand inputManager;
    
   

    private void Awake()
    {
        if (AchievementSystemInstance == null)
        {
            AchievementSystemInstance = this;
        }
        else if (AchievementSystemInstance == this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
     
    }

    private void Start()
    {
        inputManager.OnCubeMoved += OnCubeMovedFunc;
        inputManager.OnCubeScaled += OnCubeScaledFunc;
        _achievementText = achievementTextObject.transform.Find("Achievement text").gameObject.GetComponent<TMP_Text>();
    }

    private void OnCubeMovedFunc(object sender, InputManagerCommand.OnCubeMoveArgs e)
    {
        _achievementText.text = $"You've moved the cube {e.Direction}";
        achievementTextObject.SetActive(true);
        inputManager.OnCubeMoved -= OnCubeMovedFunc;
    }

    private void OnCubeScaledFunc(object sender, EventArgs e)
    {
        _achievementText.text = "You've scaled the cube";
        achievementTextObject.SetActive(true);
        inputManager.OnCubeScaled -= OnCubeScaledFunc;
    }
    
}
