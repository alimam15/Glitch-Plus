using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSelector : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
   

    private void OnMouseDown()
    {
       var selectors = FindObjectsOfType<DefenderSelector>();

        foreach (DefenderSelector selector in selectors) {
            selector.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SelectDefender(defenderPrefab);
        Debug.Log(defenderPrefab);
       
    }

}
 