using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private SnakeMovement Controls;
    [SerializeField] private GameObject _winPanel;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }

    private const string LevelIndexKey = "LevelIndex";

    private void Start()
    {
        _winPanel.SetActive(false);
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        //Controls.enabled = false;
        Debug.Log("Game over!");
        ReloadLevel();
    }

    public void OnPlayerReachFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        _winPanel.SetActive(true);
        Controls.enabled = false;
        //LevelIndex++;
        Debug.Log("Won!");
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
