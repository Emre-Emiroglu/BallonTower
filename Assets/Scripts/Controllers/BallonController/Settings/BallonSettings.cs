using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme;

[CreateAssetMenu(fileName ="Ballon Settings", menuName ="DevShirme/Settings/Ballon Settings")]
public class BallonSettings : DevSettings
{
    #region Fields
    [Header("Ballon Rising Settings")]
    [SerializeField] private float maxYPos = 7f;
    [SerializeField] private float minYPos = 5f;
    [SerializeField] private float maxXPos = 1f;
    [SerializeField] private float minXPos = -1f;
    [SerializeField] private float risingDuration = 1f;
    [SerializeField] private AnimationCurve risingCurve;
    [Header("Spawn Settings")]
    [Range(.1f, 10f)][SerializeField] private float spawnDelay = 1f;
    #endregion

    #region Getters
    public float MaxYPos => maxYPos;
    public float MinYPos => minYPos;
    public float MaxXPos => maxXPos;
    public float MinXPos => minXPos;
    public float RisingDuration => risingDuration;
    public AnimationCurve RisingCurve => risingCurve;
    public float SpawnDelay => spawnDelay;
    #endregion
}
