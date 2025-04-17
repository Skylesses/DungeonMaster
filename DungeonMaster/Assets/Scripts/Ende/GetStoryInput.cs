using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetStoryInput : MonoBehaviour
{
    [SerializeField] private TMP_Text storyText;

    //input ID
    public string fieldID;

    // Start is called before the first frame update
    void Start()
    {
       //load input from stories
       if(PlayerPrefs.HasKey(fieldID))
       {
            string input = PlayerPrefs.GetString(fieldID);
            storyText.text = input;
       }
       else
       {
            storyText.text = "Yo, where input???";
       }
    }
}
