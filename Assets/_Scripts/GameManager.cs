using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerMissilePref;
    [SerializeField] GameObject playerMissileLauncherPref;
    [SerializeField] GameObject enemyMissilePref;
    private float minX, maxX, yVal,randomX;
    public int missilesToSpwan = 20;
    public float delayToSpawn = 0.5f;
    public int numberofBase = 6;

    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
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
        UIManager.Instance.HideGameOver();
        UIManager.Instance.HideLevelComplete();

        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        yVal = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        StartCoroutine(SpawnEnemyMissiles());


    }

    // Update is called once per frame
    void Update()
    {
        LauchPlayerMissile();
        if (missilesToSpwan <= 0)
            UIManager.Instance.ShowLevelComplete();
    }

    private void LauchPlayerMissile()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(playerMissilePref, playerMissileLauncherPref.transform.position, Quaternion.identity);
        }
    }
    
    public IEnumerator SpawnEnemyMissiles()
    {
        while(missilesToSpwan>0)
        {
            randomX = Random.Range(minX, maxX);
            Instantiate(enemyMissilePref, new Vector3(randomX, yVal + 0.5f, 0), Quaternion.identity);
            missilesToSpwan--;
            yield return new WaitForSeconds(delayToSpawn);
        }
    }

    public void RestartPressed()
    {
        ScoreManager.Instance.score = 0;
        SceneManager.LoadSceneAsync(0);
    }
}
