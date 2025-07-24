using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{

    public static PopUpManager instance;
    [SerializeField] GameObject popUpPrefab;

    public void spawnPopUp(){
        GameObject popUpObject = Instantiate(popUpPrefab);
        popUpObject.GetComponent<PopUp>().textValue = "Nucleus Fact";
    }

    private void Awake()
    {
        instance = this;
    }

}
