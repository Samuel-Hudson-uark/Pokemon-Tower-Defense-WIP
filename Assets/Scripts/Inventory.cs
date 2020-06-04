using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public delegate void OnPokemonChanged();
    public OnPokemonChanged onPokemonChangedCallback;

    public delegate void OnCurrencyChanged();
    public OnCurrencyChanged onCurrencyChangedCallback;

    public List<Pokemon> party = new List<Pokemon>();
    public int partySize = 6;
    public bool editingMode = true;
    public InventorySlot selectedButton;

    public int currency = 0;
    public int maxCurrency = 9999;

    public bool Add(Pokemon pokemon)
    {
        if(party.Count >= partySize || party.Contains(pokemon))
        {
            return false;
        }
        //Debug.Log("Adding" + pokemon.name);
        party.Add(pokemon);
        if(onPokemonChangedCallback != null)
        {
            onPokemonChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Pokemon pokemon)
    {
        party.Remove(pokemon);
        if (onPokemonChangedCallback != null)
        {
            onPokemonChangedCallback.Invoke();
        }
    }

    public bool SpendCurrency(int cost)
    {
        if(currency - cost < 0)
        {
            return false;
        } 
        else
        {
            currency -= cost;
            if (onCurrencyChangedCallback != null)
            {
                onCurrencyChangedCallback.Invoke();
            }
            return true;
        }
    }

    public void GainCurrency(int gain)
    {
        if(currency + gain < maxCurrency)
        {
            
            currency += gain;
        } 
        else
        {
            currency = maxCurrency;
        }
        if (onCurrencyChangedCallback != null)
        {
            onCurrencyChangedCallback.Invoke();
        }
    }

}
