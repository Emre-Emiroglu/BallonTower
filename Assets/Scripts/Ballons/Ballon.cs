using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;

public class Ballon : PoolObject
{
    #region Fields
    [Header("Ballon Fields")]
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Collider mainCol;
    private Coroutine risingCoroutine;
    #endregion

    #region Core
    public override void initilaze()
    {
        base.initilaze();
    }
    public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);

        clearRisingCoroutine();
        transform.localScale = Vector3.zero;
        //mainCol.enabled = false;
        lr.enabled = false;
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
    }
    #endregion

    #region RisingAnim
    public void Rising(Vector3 targetPos, float duration, AnimationCurve curve)
    {
        clearRisingCoroutine();
        risingCoroutine = StartCoroutine(risingAnim(targetPos, duration, curve));
    }
    private IEnumerator risingAnim(Vector3 targetPos, float duration, AnimationCurve curve)
    {
        float t = 0f;
        Vector3 orgPos = transform.position;
        Vector3 targetScale = Vector3.one;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(orgPos, targetPos, curve.Evaluate(t / duration));
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, curve.Evaluate(t / duration));
            yield return null;
        }
        mainCol.enabled = true;
        lr.enabled = true;
    }
    private void clearRisingCoroutine()
    {
        if (risingCoroutine != null)
            StopCoroutine(risingCoroutine);
    }
    #endregion

    #region Rope
    private void setRope()
    {
        if (InUse && lr.enabled)
        {
            lr.SetPosition(0, Vector3.zero);
            lr.SetPosition(1, transform.position * -1);
        }
    }
    #endregion

    #region Updates
    private void LateUpdate()
    {
        setRope();
    }
    #endregion

}
