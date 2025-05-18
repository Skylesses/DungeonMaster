using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public int loadingTime;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(Loading());
    }

    public IEnumerator Loading()
    {
        yield return new WaitForSeconds(loadingTime);
        loadingScreen.SetActive(false);
    }
}
