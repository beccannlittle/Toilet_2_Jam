using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject beginningPrefab;
    public GameObject middlePrefab;
    public GameObject endPrefab;

    public GameObject[] platformPrefabs;

    public Transform startGeneration;

    public int generationOffset = 1;

    private int totalOffset = 0;

    private void Start()
    {
        //Instantiate(platformPrefabs[0], startGeneration);
        //totalOffset += generationOffset;
        //StartCoroutine(GeneratePlatform());
    }
    

    private IEnumerator GeneratePlatform()
    {
        while (true)
        {
            Vector2 newSpot = new Vector2(startGeneration.position.x, startGeneration.position.y);
            newSpot.x += totalOffset;
            totalOffset += generationOffset;
            Instantiate(middlePrefab).transform.position = newSpot;
            yield return null;
        }
    }

}
