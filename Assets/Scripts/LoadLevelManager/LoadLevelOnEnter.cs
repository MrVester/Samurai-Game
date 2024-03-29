using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnEnter : MonoBehaviour
{

    public int nextLevel;
    public float timeFor3Stars;
    public float timeFor2Stars;
    public float timeFor1Star;
    [SerializeField]
    private float timer;
    private EnemiesCounter enemiesCounter;
    private Collider2D collider;
    private SpriteRenderer arrow;

    private void Awake()
    {

    }
    void Start()
    {
        collider = GetComponent<Collider2D>();
        arrow = GetComponent<SpriteRenderer>();
        DisableCollider();
        EnemiesCounter.current.onAllEnemiesDead += ActivateCollider;
        timer = 0;

        JSONSave.Start(JSONSaveConfig.GetConfig());
        enemiesCounter = GetComponent<EnemiesCounter>();


    }

    private void Update()
    {
        timer += Time.deltaTime;

    }
    private void ActivateCollider()
    {
        collider.enabled = true;
        arrow.enabled = true;
    }
    private void DisableCollider()
    {
        collider.enabled = false;
        arrow.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (JSONSave.GetInt("levelsCompleted") < nextLevel - 1)
                JSONSave.SetInt("levelsCompleted", nextLevel - 1);

            if (timer <= timeFor3Stars)
            {

                JSONSave.SetInt("level" + (nextLevel - 1) + "Stars", 3);
            }
            else
            if (timer <= timeFor2Stars)
            {
                if (JSONSave.GetInt("level" + (nextLevel - 1) + "Stars") < 3)
                    JSONSave.SetInt("level" + (nextLevel - 1) + "Stars", 2);
            }
            else
            if (timer <= timeFor1Star)
            {
                if (JSONSave.GetInt("level" + (nextLevel - 1) + "Stars") < 2)
                    JSONSave.SetInt("level" + (nextLevel - 1) + "Stars", 1);
            }
            else
            {
                if (JSONSave.GetInt("level" + (nextLevel - 1) + "Stars") < 1)
                    JSONSave.SetInt("level" + (nextLevel - 1) + "Stars", 0);
            }
            SceneManager.LoadScene("Level" + nextLevel);
        }

    }


}
