using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForSave : MonoBehaviour
{
    public ForSave instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance.instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }


    [System.Serializable]
    class SaveData
    {


    }




}
