using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.PoolModule;

public class Ballon : PoolObject
{
    #region Fields
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider mainCol;
    private Coroutine risingCoroutine;
    private bool isActive;
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
        mainCol.enabled = false;
        isActive = true;
    }
    public override void DespawnObj()
    {
        base.DespawnObj();
        isActive = false;
    }
    #endregion

    #region Executes
    public void Rising(float targetYPos, float targetXPos, float duration, AnimationCurve curve)
    {
        clearRisingCoroutine();

        risingCoroutine = StartCoroutine(risingAnim(targetYPos, targetXPos, duration, curve));
    }
    private IEnumerator risingAnim(float targetYPos, float targetXPos, float duration, AnimationCurve curve)
    {
        float t = 0f;
        Vector3 orgPos = transform.position;
        Vector3 targetPos = new Vector3(targetXPos, targetYPos, orgPos.z);
        Vector3 targetScale = Vector3.one;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(orgPos, targetPos, curve.Evaluate(t / duration));
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, curve.Evaluate(t / duration));
            yield return null;
        }

        mainCol.enabled = true;
    }
    private void clearRisingCoroutine()
    {
        if (risingCoroutine != null)
            StopCoroutine(risingCoroutine);
    }
    #endregion

    #region Update
    private void FixedUpdate()
    {
        if (isActive)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.fixedDeltaTime * 20f);
        }
    }
    #endregion
}
