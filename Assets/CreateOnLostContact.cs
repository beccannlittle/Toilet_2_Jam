using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnLostContact : MonoBehaviour {

    public string tagToCreateWhenLeaving;
    public GameObject[] prefabsToCreate;
    public int gapSize = 5;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToCreateWhenLeaving))
        {
            Vector2 currentPos = gameObject.transform.position;
            Instantiate(prefabsToCreate[0]).transform.position = new Vector2(currentPos.x + gapSize, currentPos.y);
        }
    }
}
