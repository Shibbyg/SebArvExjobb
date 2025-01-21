using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class AudioBossManager : MonoBehaviour
{
    [Header("Event Instances")]
    [SerializeField] private EventReference bossWalk;
    [SerializeField] private EventReference bossLaserAttack;
    [SerializeField] private EventReference bossGrenadeAttack;
    [SerializeField] private EventReference bossLightningAttack;
    [SerializeField] private EventReference bossTakeDamage;
    [SerializeField] private EventReference bossShieldUp;
    [SerializeField] private EventReference bossShieldDown;
    [SerializeField] private EventReference bossSteamStage;
    [SerializeField] private EventReference bossDie;

    private EventInstance bossSteamStageInstance;

    [Header("Music Settings")]
    public string bossMusic = "";
    public string stageParameter = "";
    public string progressionMusic = "";
    public float stage1Value = 0f;
    public float stage2Value = 0f;
    public float bossDeathValue = 0f;
    
    
    private StudioEventEmitter bossMusicEmitter;

    private void Start()
    {
        bossMusicEmitter = GameObject.FindGameObjectWithTag(bossMusic).GetComponent<StudioEventEmitter>();
    }

    public void BossWalk(GameObject boss)
    {
        if (bossWalk.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossWalk");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossWalk, boss);
    }

    public void BossLaserAttack(GameObject laserObj)
    {
        if (bossLaserAttack.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossLaserAttack");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossLaserAttack, laserObj);
    }

    public void BossGrenadeAttack(GameObject grenadeObj)
    {
        if (bossGrenadeAttack.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossGrenadeAttack");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossGrenadeAttack, grenadeObj);
    }

    public void BossLightningAttack(GameObject lightningObj)
    {
        if (bossLightningAttack.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossLightningAttack");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossLightningAttack, lightningObj);
    }

    public void BossTakeDamage(GameObject boss)
    {
        if (bossTakeDamage.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossTakeDamage");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossTakeDamage, boss);
    }

    public void BossShieldUp(GameObject boss)
    {
        if (bossShieldUp.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossShieldUp");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossShieldUp, boss);
    }

    public void BossShieldDown(GameObject boss)
    {
        if (bossShieldDown.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossShieldDown");
            return;
        }
        RuntimeManager.PlayOneShotAttached(bossShieldDown, boss);
    }

    public void BossSteamStage1(GameObject boss)
    {
        if (bossSteamStage.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossSteamStage");
        }
        else
        {
            bossSteamStageInstance = RuntimeManager.CreateInstance(bossSteamStage);
            RuntimeManager.AttachInstanceToGameObject(bossSteamStageInstance, transform,boss.GetComponent<Rigidbody2D>());
            bossSteamStageInstance.setParameterByName("SteamStage", 1f);
            bossSteamStageInstance.start(); 
        }
        bossMusicEmitter.SetParameter(stageParameter, stage1Value);
    }

    public void BossSteamStage2(GameObject boss)
    {
        if (bossSteamStage.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossSteamStage");
        }
        else
        {
            bossSteamStageInstance.setParameterByName("SteamStage", 2f);
            bossSteamStageInstance.start();
            bossSteamStageInstance.release();
        }
        bossMusicEmitter.SetParameter(stageParameter, stage2Value);
    }

    public void BossDie(GameObject boss)
    {
        if (bossDie.IsNull)
        {
            Debug.LogWarning("Fmod event not found: bossDie");
        }
        RuntimeManager.PlayOneShotAttached(bossDie, boss);
        bossMusicEmitter.SetParameter(stageParameter, bossDeathValue);
        bossMusicEmitter.SetParameter(progressionMusic,3);
    }
}