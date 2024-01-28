using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject blueHand;
    [SerializeField] private GameObject redHand;
    
    
    void Awake()
    {
        DisplayCard[] redCards = redHand.GetComponentsInChildren<DisplayCard>();
        DisplayCard[] blueCards = blueHand.GetComponentsInChildren<DisplayCard>();

        foreach (var card in redCards)
        {
            card.SetVisible(false);
        }
        
        foreach (var card in blueCards)
        {
            card.SetVisible(false);
        }

    }


}
