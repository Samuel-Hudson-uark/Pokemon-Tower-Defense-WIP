using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor;

    private GameObject unit;

    private SpriteRenderer sprite;
    private Color startColor;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startColor = sprite.color;
    }

    void OnMouseUp()
    {
        if(unit == null)
        {
            Pokemon pokemonToPlace = UnitManager.instance.selectedPokemon;
            if (pokemonToPlace != null)
            {
                Inventory inventory = Inventory.instance;
                if (inventory.SpendCurrency(pokemonToPlace.cost))
                {
                    unit = (GameObject)Instantiate(pokemonToPlace.pokemon, transform.position, transform.rotation);
                    inventory.selectedButton.PlacePokemon();
                }
                else
                {
                    Debug.Log("Not enough currency to place the Pokemon!");
                }
                
            }

        } else
        {
            //Can't place a Pokemon on an occupied tile (and probably don't need an error message for this lol)
            Debug.Log("Can't send out another Pokemon here!");
        }
    }

    void OnMouseEnter()
    {
        if(UnitManager.instance.selectedPokemon != null)
            sprite.color = hoverColor;
    }

    void OnMouseExit()
    {
        sprite.color = startColor;
    }
}
