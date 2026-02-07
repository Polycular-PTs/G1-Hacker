using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelProgress", menuName = "Scriptable Objects/LevelProgress")]
public class LevelProgress : ScriptableObject
{
    public int currentLevel;
    public List<Level> levels;
}

[Serializable]
public class Level
{
    [Header("GameOver")]
    public string loadSceneToTryAgain;
    [Header("Desktop")]
    public string nextSceneAfterLogin;
    [Header("BildQuiz")]
    public BildQuiz bildQuiz;
    [Header("Quiz")]
    public Quiz quiz;
}

[Serializable]
public class BildQuiz
{
    public string[] correctWords;
    public Sprite img;
    public string nextScene;
    public int maxTries;
    public string hint;
}

[Serializable]
public class Quiz
{
    [TextArea]
    public string header;
    [TextArea]
    public string[] answers;
    public int[] rightAnswers;
    public string nextScene;
}
