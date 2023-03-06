using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button resetButton;
    private void Start()
    {
        resetButton.onClick.AddListener(() =>
        {
            ResetScene();
        });
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
