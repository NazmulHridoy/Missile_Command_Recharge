using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] private GameObject gameOverPanel, levelCompletePanel;

    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.score;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);   
    }
    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowLevelComplete()
    {
        levelCompletePanel.SetActive(true);
    }
    public void HideLevelComplete ()
    {
        levelCompletePanel.SetActive(false);
    }
}
