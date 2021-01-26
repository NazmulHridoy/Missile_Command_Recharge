using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileController : MonoBehaviour
{
    [SerializeField] private float emissileSpeed = 5f;
    [SerializeField] private GameObject[] playerBase;
    private Vector2 baseTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GameObject.FindGameObjectsWithTag("Base");
        baseTarget = playerBase[Random.Range(0, playerBase.Length)].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, baseTarget, emissileSpeed * Time.deltaTime);
        if(transform.position==(Vector3)baseTarget)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag=="Missile")
        {
            ScoreManager.Instance.score++;
            UIManager.Instance.UpdateScoreText();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.tag=="Base")
        {
            GameManager.Instance.numberofBase--;
            if(GameManager.Instance.numberofBase <= 0)
            {
                UIManager.Instance.ShowGameOver();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }        
    }
}
