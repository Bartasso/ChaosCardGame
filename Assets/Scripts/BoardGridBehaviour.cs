using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGridBehaviour : MonoBehaviour
{
    [SerializeField] private DisplayCard cardOnThisField;

    private readonly Color _player1Color = Color.red;
    private readonly Color _player2Color = Color.blue;
    private Color _originalColor;
    private MeshRenderer _renderer;
    private bool _cardVisible;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _originalColor = _renderer.material.color;
    }

    void OnMouseOver()
    {
        if (CompareTag("Red"))
        {
            _renderer.material.color = _player1Color;
        }
        if (CompareTag("Blue"))
        {
            _renderer.material.color = _player2Color;
        }
    }

    private void OnMouseDown()
    {
        cardOnThisField.SetVisible(!_cardVisible);
        _cardVisible = !_cardVisible;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
    }
}
