using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    #region Singleton
    private static ScoreManager instance;
    public static ScoreManager Instance
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
