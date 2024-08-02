using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class FightManager : MonoBehaviour
{
    public Button fightButton;
    private HashSet<string> detectedCards = new HashSet<string>();
    public TextMeshProUGUI resultText;

    private Dictionary<string, int> cardValues = new Dictionary<string, int>
    {
        //hearts
        { "1_of_hearts", 14 },
        { "2_of_hearts", 2 },
        { "3_of_hearts", 3 },
        { "4_of_hearts", 4 },
        { "5_of_hearts", 5 },
        { "6_of_hearts", 6 },
        { "7_of_hearts", 7 },
        { "8_of_hearts", 8 },
        { "9_of_hearts", 9 },
        { "10_of_hearts", 10 },
        { "jack_of_hearts", 11},
        { "queen_of_hearts", 12},
        { "king_of_hearts", 13},

        //spades
        { "1_of_spades", 14 },
        { "2_of_spades", 2 },
        { "3_of_spades", 3 },
        { "4_of_spades", 4 },
        { "5_of_spades", 5 },
        { "6_of_spades", 6 },
        { "7_of_spades", 7 },
        { "8_of_spades", 8 },
        { "9_of_spades", 9 },
        { "10_of_spades", 10 },
        { "jack_of_spades", 11},
        { "queen_of_spades", 12},
        { "king_of_spades", 13},

        //diamonds
        { "1_of_diamonds", 14 },
        { "2_of_diamonds", 2 },
        { "3_of_diamonds", 3 },
        { "4_of_diamonds", 4 },
        { "5_of_diamonds", 5 },
        { "6_of_diamonds", 6 },
        { "7_of_diamonds", 7 },
        { "8_of_diamonds", 8 },
        { "9_of_diamonds", 9 },
        { "10_of_diamonds", 10 },
        { "jack_of_diamonds", 11},
        { "queen_of_diamonds", 12},
        { "king_of_diamonds", 13},

        //clubs
        { "1_of_clubs", 14 },
        { "2_of_clubs", 2 },
        { "3_of_clubs", 3 },
        { "4_of_clubs", 4 },
        { "5_of_clubs", 5 },
        { "6_of_clubs", 6 },
        { "7_of_clubs", 7 },
        { "8_of_clubs", 8 },
        { "9_of_clubs", 9 },
        { "10_of_clubs", 10 },
        { "jack_of_clubs", 11},
        { "queen_of_clubs", 12},
        { "king_of_clubs", 13}

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
            resultText.text = "No cards detected.";
            StartCoroutine(HideResultTextAfterDelay(3));

        }
        else if (detectedCards.Count == 1)
        {
            Debug.Log("There is only one card detected. Two are required to play this game. Get one more. ");
            resultText.text = "Get one more card.";
            StartCoroutine(HideResultTextAfterDelay(3));


        }
        else
        {
            List<string> cards = new List<string>(detectedCards);

            string card1 = cards[0];
            string card2 = cards[1];
            if (cardValues.ContainsKey(card1) && cardValues.ContainsKey(card2))
            {
                int value1 = cardValues[card1];
                int value2 = cardValues[card2];

                if (value1 > value2)
                {
                    Debug.Log(card1 + " wins against " + card2);
                    resultText.text = card1 + "WINS!";
                    StartCoroutine(HideResultTextAfterDelay(3));

                }
                else if (value1 < value2)
                {
                    Debug.Log(card2 + " wins against " + card1);
                    resultText.text = card2 + "WINS!";
                    StartCoroutine(HideResultTextAfterDelay(3));

                }
                else
                {
                    Debug.Log(card1 + " and " + card2 + " are equal!");
                    resultText.text = "IT IS A TIE.";
                    StartCoroutine(HideResultTextAfterDelay(3));
                }
            }

        }




    }

    public IEnumerator HideResultTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (resultText != null)
        {
            resultText.text = "";
        }
    }
}