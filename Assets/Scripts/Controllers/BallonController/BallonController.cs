using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme;
using DevShirme.Core;
using DevShirme.PoolModule;

public class BallonController : DevShirmeController
{
    #region Fields
    [Header("Componenets")]
    [SerializeField] private Magnet magnet;
    [SerializeField] private Transform ballonAttachObj;
    [Header("Toggle")]
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
        magnet.Init();
    }
    #endregion

    #region Executes
    private void spawnBallon()
    {
        Ballon ballon = pm.GetObj("Ballon", ballonAttachObj.position, ballonAttachObj.gameObject) as Ballon;

        Color randomColor = bs.GetRandomColor();
        ballon.SetMaterialColor(randomColor);

        Vector3 targetPos = bs.GetRandomRisingPos();
        ballon.Rising(targetPos, bs.RisingDuration, bs.RisingCurve);
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
