using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    void Start()
    {
        if (instance == null)
        {
	        instance = this;
	    } 
        else if(instance == this)
        {
	        Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

	    InitGameManager();
    }

    private void InitGameManager()
    {
        
    }
}
