using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSavedProps : MonoBehaviour
{
    public Vector3 spawnPosBig;
    public Vector3 spawnPosSmallOne;
    public Vector3 spawnPossmallTwo;
    public Vector3 spawnPossmallThree;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SaveProps.big, spawnPosBig, Quaternion.identity);
        Instantiate(SaveProps.smallOne, spawnPosSmallOne, Quaternion.identity);
        Instantiate(SaveProps.smallTwo, spawnPossmallTwo, Quaternion.identity);
        Instantiate(SaveProps.smallThree, spawnPossmallThree, Quaternion.identity);
    }

}
