using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;

public class Ballon : PoolObject
{
    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
    }
    #endregion
}
