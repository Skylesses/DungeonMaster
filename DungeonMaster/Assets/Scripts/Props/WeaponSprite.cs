using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSprite : MonoBehaviour
{
    [SerializeField] Sprite[] weaponSprites;
    [SerializeField] Sprite newSprite;
    private int currentIndex = 0;

    public void ChangeSprite()
    {
        newSprite = weaponSprites[currentIndex];
        currentIndex = (currentIndex + 1) % weaponSprites.Length;
        gameObject.GetComponent<Image>().sprite = newSprite;
    }


}
