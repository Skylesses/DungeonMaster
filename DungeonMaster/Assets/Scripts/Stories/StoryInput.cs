using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryInput : MonoBehaviour
{
    //input ID
    [SerializeField] private string fieldID;

    [SerializeField] private string inputText;

    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;

    //Get text from input
    public void GrabFromInput(string input)
    {
        inputText = input;
        DisplayReactionToInput();
        SaveInput();
    }

    private void DisplayReactionToInput()
    {
        reactionTextBox.text = "You meet in a" + inputText + ".";
        reactionGroup.SetActive(true);
    }

    //save text from input
    public void SaveInput()
    {
        PlayerPrefs.SetString(fieldID, inputText);
        PlayerPrefs.Save();
    }

    public string GetInput()
    {
        return inputText;
    }
}
