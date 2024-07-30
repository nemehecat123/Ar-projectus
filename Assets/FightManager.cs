using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public Button fightButton;
    private HashSet<string> detectedCards = new HashSet<string>();

    private Dictionary<string, int> cardValues = new Dictionary<string, int>
    {
        { "Ace of Spades", 14 }, // Assuming Ace is the highest
        { "2 of Spades", 2 },
        { "3_of_hearts", 3 },
        { "jack_of_hearts", 5},

        // ... Add all the cards with their values
        { "King of Spades", 13 }
        // Repeat for other suits: Hearts, Diamonds, Clubs
    };

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
        else if (detectedCards.Count == 1)
        {
            Debug.Log("There is only one card detected. Two are required to play this game. Get one more. ");
        }
        else
        {
            List<string> cards = new List<string>(detectedCards);

            string card1 = cards[0];
            string card2 = cards[1];
            Debug.Log("AAAAAAAAA do sem pride AAAAAAAAAAAAAA");
            if (cardValues.ContainsKey(card1) && cardValues.ContainsKey(card2))
            {


                Debug.Log("BBBBBBBBBBBBBBBB do sm pride BBBBBBBBBBBBBBBBBBBBBBB");

                int value1 = cardValues[card1];
                int value2 = cardValues[card2];

                if (value1 > value2)
                {
                    Debug.Log(card1 + " wins against " + card2);
                }
                else if (value1 < value2)
                {
                    Debug.Log(card2 + " wins against " + card1);
                }
                else
                {
                    Debug.Log(card1 + " and " + card2 + " are equal!");
                }
            }

        }
    }
}