using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryInput : MonoBehaviour
{
    [SerializeField] private string inputText;

    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;

    //Get Text from input
    public void GrabFromInput(string input)
    {
        inputText = input;
        DisplayReactionToInput();
    }

    private void DisplayReactionToInput()
    {
        reactionTextBox.text = "You meet in a" + inputText + ".";
        reactionGroup.SetActive(true);
    }

    public void HandOverInput()
    {

    }
}
