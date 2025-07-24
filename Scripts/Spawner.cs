using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    int numberToSpawn;
    public GameObject spawnItem;
    public RectTransform panel;
    public float spawnInterval;


    void Start()
    {
        spawnInterval = Random.Range(2f, 5f);
        InvokeRepeating(nameof(spawnObject), 0f, spawnInterval);
    }

    public void spawnObject()
    {
        numberToSpawn = Random.Range(1, 3);

        for(int i = 0; i < numberToSpawn; i++)
        {
            GameObject newObj = Instantiate(spawnItem, panel);
            RectTransform newRect = newObj.GetComponent<RectTransform>();

            float x = Random.Range(-panel.rect.width / 2f, panel.rect.width / 2f);
            float y = Random.Range(-panel.rect.height / 2f, panel.rect.height / 2f);

            newRect.anchoredPosition = new Vector2(x, y);
        }
    }
}
