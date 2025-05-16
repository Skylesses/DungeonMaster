using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWeapons : MonoBehaviour
{
    public Image weapon;
    public string weaponName;

    // Start is called before the first frame update
    void Start()
    {
        string savedName = PlayerPrefs.GetString(weaponName);
        Sprite[] allSprites = Resources.LoadAll<Sprite>("Weapons");

        foreach (Sprite s in allSprites)
        {
            if (s.name == savedName)
            {
                gameObject.GetComponent<Image>().sprite = s;
                break;
            }
        }
    }
}
