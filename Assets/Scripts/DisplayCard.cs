using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCard : MonoBehaviour
{
    [SerializeField] private Card displayedCard;
    
    private string _cardName;
    private int _cardCost;
    private int _cardPower;
    private int _cardHealth;
    private string _cardDescription;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text powerText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text descriptionText;

    private void Update()
    {
        _cardName = displayedCard.cardName;
        _cardCost = displayedCard.cardCost;
        _cardPower = displayedCard.cardPower;
        _cardHealth = displayedCard.cardHealth;
        _cardDescription = displayedCard.cardDescription;

        nameText.text = _cardName;
        costText.text = _cardCost.ToString();
        powerText.text = _cardPower.ToString();
        healthText.text = _cardHealth.ToString();
        descriptionText.text = _cardDescription;
    }
}
