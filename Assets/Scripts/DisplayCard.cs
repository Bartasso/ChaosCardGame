using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    [SerializeField] private Card displayedCard;
    
    private string _cardName;
    private string _cardDescription;
    private int _cardCost;
    private int _cardPower;
    private int _cardHealth;
    private Sprite _cardSprite;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text powerText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image imageField;
    
    [SerializeField] private GameObject backgroundObject;
    [SerializeField] private GameObject cardBodyObject;
    [SerializeField] private bool isPlayed;

    private void Update()
    {
        _cardName = displayedCard.cardName;
        _cardCost = displayedCard.cardCost;
        _cardPower = displayedCard.cardPower;
        _cardHealth = displayedCard.cardHealth;
        _cardDescription = displayedCard.cardDescription;
        _cardSprite = displayedCard.cardImage;

        nameText.text = _cardName;
        costText.text = _cardCost.ToString();
        powerText.text = _cardPower.ToString();
        healthText.text = _cardHealth.ToString();
        descriptionText.text = _cardDescription;
        imageField.sprite = _cardSprite;

        if (!isPlayed)
        {
            backgroundObject.SetActive(false);
            cardBodyObject.SetActive(false);
        }
        else
        {
            backgroundObject.SetActive(true);
            cardBodyObject.SetActive(true);
        }
    }

    public void ChangeCard(Card drawnCard)
    {
        displayedCard = drawnCard;
    }

    public void SetVisible(bool visible)
    {
        isPlayed = visible;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
