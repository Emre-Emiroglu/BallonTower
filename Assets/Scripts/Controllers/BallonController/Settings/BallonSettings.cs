using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme;
using DevShirme.Utils;

[CreateAssetMenu(fileName ="Ballon Settings", menuName ="DevShirme/Settings/Ballon Settings")]
public class BallonSettings : DevSettings
{
    #region Fields
    [Header("Ballon Rising Settings")]
    [SerializeField] private float maxYPos = 7f;
    [SerializeField] private float minYPos = 5f;
    [SerializeField] private float maxXPos = 1f;
    [SerializeField] private float minXPos = -1f;
    [SerializeField] private float maxZPos = .1f;
    [SerializeField] private float minZPos = -.1f;
    [SerializeField] private float risingDuration = 1f;
    [SerializeField] private AnimationCurve risingCurve;
    [Header("Spawn Settings")]
    [Range(.1f, 10f)][SerializeField] private float spawnDelay = 1f;
    [Header("Color Settings")]
    [SerializeField] private List<Color> Colors;
    #endregion

    #region Getters
    public Vector3 GetRandomRisingPos()
    {
        float x = Random.Range(minXPos, maxXPos);
        float y = Random.Range(minYPos, maxYPos);
        float z = Random.Range(minZPos, maxZPos);
        return new Vector3(x, y, z);
    }
    public Color GetRandomColor()
    {
        var shuffled = Utilities.Shuffle(Colors);
        return (shuffled[Random.Range(0, shuffled.Count)]);
    }
    public float RisingDuration => risingDuration;
    public AnimationCurve RisingCurve => risingCurve;
    public float SpawnDelay => spawnDelay;
    #endregion
}
