using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCManager : MonoBehaviour
{
    #region Singleton
    public static PCManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public delegate void OnPcChanged();
    public OnPcChanged onPcChangedCallback;

    public SortedList<int, Pokemon> PC = new SortedList<int, Pokemon>();

    public bool Recruit(Pokemon pokemon)
    {
        int id = pokemon.id;
        if (PC.ContainsKey(id))
        {
            return false;
        }
        PC.Add(id, pokemon);
        if (onPcChangedCallback != null)
        {
            onPcChangedCallback.Invoke();
        }
        return true;
    }
}
