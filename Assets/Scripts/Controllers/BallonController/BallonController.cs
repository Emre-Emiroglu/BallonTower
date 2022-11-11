using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme;
using DevShirme.Core;
using DevShirme.PoolModule;

public class BallonController : DevShirmeController
{
    #region Fields
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool canSpawn = false;
    private BallonSettings bs;
    private PoolManager pm;
    private float timer;
    #endregion

    #region Core
    public override void Initialize()
    {
        bs = settings as BallonSettings;
        pm = DevShirmeCore.Instance.GetAManager(ManagerType.PoolManager) as PoolManager;
        timer = 0f;
    }
    #endregion

    #region Executes
    private void spawnBallon()
    {
        float yPos = Random.Range(bs.MinYPos, bs.MaxYPos);
        float xPos = Random.Range(bs.MinXPos, bs.MaxXPos);
        Ballon ballon = pm.GetObj("Ballon", spawnPoint.position) as Ballon;
        ballon.Rising(yPos, xPos, bs.RisingDuration, bs.RisingCurve);
    }
    private void Update()
    {
        if (canSpawn)
            spawner(bs.SpawnDelay);
    }
    private void spawner(float delay)
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            timer = 0f;
            spawnBallon();
        }
    }
    #endregion
}
