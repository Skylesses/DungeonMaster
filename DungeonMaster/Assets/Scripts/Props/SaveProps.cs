using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProps : MonoBehaviour
{
    public static GameObject big;
    public static GameObject smallOne;
    public static GameObject smallTwo;
    public static GameObject smallThree;

    public Vector3 spawnPosBig;
    public Vector3 spawnPosSmallOne;
    public Vector3 spawnPossmallTwo;
    public Vector3 spawnPossmallThree;

    //save the prop as prefab for later
    public void SaveInCache()
    {
        SaveProps.big = Instantiate(big);
    }
}
