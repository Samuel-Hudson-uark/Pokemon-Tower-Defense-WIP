using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Pokemon selectedPokemon;


}
