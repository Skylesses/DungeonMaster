using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveWeapons : MonoBehaviour
{
    [Header("Tavern")]
    public Image skeletSword;
    public Image skeletSpear;
    public Image skeletShieldOne;
    public Image skeletShieldTwo;

    [Header("Ship")]
    public Image sailorSword;
    public Image banditSwordOne;
    public Image banditSwordTwo;

    [Header("Jail")]
    public Image guardSword;
    public Image guardShield;

    [Header("Woods")]
    public Image goblinClub;
    public Image golbinSword;

    //save Images of the weapons
    public void SaveWeaponImages()
    {
        PlayerPrefs.SetString("skeletSword", skeletSword.sprite.name);
        PlayerPrefs.SetString("skeletSpear", skeletSpear.sprite.name);
        PlayerPrefs.SetString("skeletShieldOne", skeletShieldOne.sprite.name);
        PlayerPrefs.SetString("skeletShieldTwo", skeletShieldTwo.sprite.name);
        PlayerPrefs.SetString("sailorSword", sailorSword.sprite.name);
        PlayerPrefs.SetString("banditSwordOne", banditSwordOne.sprite.name);
        PlayerPrefs.SetString("banditSwordTwo", banditSwordTwo.sprite.name);
        PlayerPrefs.SetString("guardSword", guardSword.sprite.name);
        PlayerPrefs.SetString("guardShield", guardShield.sprite.name);
        PlayerPrefs.SetString("goblinClub", goblinClub.sprite.name);
        PlayerPrefs.SetString("golbinSword", golbinSword.sprite.name);
    }
}
