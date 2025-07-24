using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] Text text;
    public string textValue;

    void Start()
    {
        text.text = textValue;
        //Destroy(gameObject, 1.5f);
    }
}
