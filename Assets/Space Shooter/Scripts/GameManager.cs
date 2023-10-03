using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelController LevelController;
    public TMPro.TMP_Text Score_Text;
    public int Score;
    public float ScaleUp;
    public bool canScale;
    public float TimeBetweenScale = 1;
    public bool gameStarted = false;
    public GameObject Player;
    public GameObject BarUI;
    public System.Action GameEnd;
    void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        Score_Text.text = "Score : " + Score;

    }
    private void onGameStart()
    {

        //WaveController.instance.GameStart();
        //LevelController.GameStart();
    }
    public void onGameEnd()
    {
        int HScore = PlayerPrefs.GetInt("Score");
        if(HScore < Score)
        {
            PlayerPrefs.SetInt("HScore", Score);
        }
        PlayerPrefs.SetInt("LScore", Score);
        SceneManager.LoadScene("mainmenu");


    }
    public void GetScore(int score)
    {
       Score += score;
       Score_Text.text = "Score : " + Score;
       StopCoroutine(ScaleScore()); 
       StartCoroutine(ScaleScore());
       
    }
    IEnumerator ScaleScore() 
    {
        Score_Text.gameObject.transform.localScale = Vector3.one;
        Score_Text.gameObject.transform.LeanScale(Vector3.one*ScaleUp,TimeBetweenScale);
        yield return new WaitForSeconds(TimeBetweenScale);
        Score_Text.gameObject.transform.LeanScale(Vector3.one,TimeBetweenScale);
    }
}
