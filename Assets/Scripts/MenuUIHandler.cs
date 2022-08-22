using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;
    public void StartNew()
    {
        PersistenceManager.Instance.currentName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Start()
    {
        if(PersistenceManager.Instance.currentName != null)
        {
            playerName.text = PersistenceManager.Instance.currentName;
        }
        
    }

    public void Exit()
    {
        PersistenceManager.Instance.SaveScoring();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
