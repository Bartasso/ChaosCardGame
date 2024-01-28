using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cardCost;
    public int cardPower;
    public int cardHealth;
    public string cardDescription;
    public Sprite cardImage;
}
