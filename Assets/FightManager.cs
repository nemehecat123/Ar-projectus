using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public Button fightButton;
    private HashSet<string> detectedCards = new HashSet<string>();

    void Start()
    {
        fightButton.onClick.AddListener(OnFightButtonClick);
    }

    public void CardDetected(string cardName)
    {
        detectedCards.Add(cardName);
        Debug.Log("Card detected: " + cardName);
    }

    public void CardLost(string cardName)
    {
        detectedCards.Remove(cardName);
        Debug.Log("Card lost: " + cardName);
    }

    private void OnFightButtonClick()
    {

        if (detectedCards.Count == 0)
        {
            Debug.Log("No cards detected.");
        }
        else
        {
            foreach (var card in detectedCards)
            {
                Debug.Log("Card currently detected: " + card);
            }
        }
    }
}