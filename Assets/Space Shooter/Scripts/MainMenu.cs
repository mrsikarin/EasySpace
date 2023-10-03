using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public GameObject SoundObj;
    public GameObject MenuObj;
    public GameObject ScoreObj;
    public TMPro.TMP_Text HScore_Text;
    public TMPro.TMP_Text LScore_Text;
    public float timeStart = 1f;
    public System.Action GameStart;
    public GameObject objectToKeep;


    void Awake()
    {
        instance = this;  
        if (GameObject.Find(objectToKeep.name) != objectToKeep)
        {
            Destroy(objectToKeep);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(objectToKeep);
    //    GameManager.instance.GameEnd += ShowMenu;
    int HScore = 0;
    int LScore = 0;
    if(PlayerPrefs.HasKey("HScore"))
        HScore = PlayerPrefs.GetInt("HScore");
    if(PlayerPrefs.HasKey("LScore"))
        LScore = PlayerPrefs.GetInt("LScore");
    HScore_Text.text = "High Score : "+HScore;
    LScore_Text.text = "Last Score : "+LScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }

}
