using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnEnter : MonoBehaviour
{
    public int nextLevel;

    void Start()
    {
        JSONSave.Start(JSONSaveConfig.GetConfig());   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            JSONSave.SetInt("levelsCompleted", nextLevel-1);
            SceneManager.LoadScene("Level" + nextLevel);
        }
  
    }


}
