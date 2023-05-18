using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void OnEnable()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

	    InitGameManager();
    }

    private void InitGameManager()
    {
        JSONSave.Start(JSONSaveConfig.GetConfig());
    }

}
