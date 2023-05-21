using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController current;
    void Awake()
    {
        current = this;
    }
    [SerializeField]
    private AudioSource playerAttackSource;
    [SerializeField]
    private AudioSource enemyAttackSource;
    [SerializeField]
    private AudioSource bossAttackSource;
    [SerializeField]
    private AudioSource hitSource;
    [SerializeField]
    private AudioSource playerStepsSource;


    void Start()
    {
        JSONSave.Start(JSONSaveConfig.GetConfig());
    }

    public void PlayPlayerAttackSound()
    {
        playerAttackSource.volume = JSONSave.GetFloat("SaveVolume");
        playerAttackSource.Play();
    }

    public void PlayEnemyAttackSound()
    {
        enemyAttackSource.volume = JSONSave.GetFloat("SaveVolume");
        enemyAttackSource.Play();
    }
    public void PlayBossAttackSound()
    {
        bossAttackSource.volume = JSONSave.GetFloat("SaveVolume");
        bossAttackSource.Play();
    }
    public void PlayHitSound()
    {
        hitSource.volume = JSONSave.GetFloat("SaveVolume");
        hitSource.Play();
    }
    public void PlayPlayerStepsSound()
    {
        playerStepsSource.volume = JSONSave.GetFloat("SaveVolume");
        playerStepsSource.Play();
    }
    public void StopPlayerStepsSound()
    {
        playerStepsSource.Stop();
    }
    public bool isPlayerStepsPlaying()
    {
        return playerStepsSource.isPlaying;
    }
}
