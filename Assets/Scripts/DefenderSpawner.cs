using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour
{
    //[SerializeField] GameObject trophy;
    //[SerializeField] GameObject cactus;
    Defender defender ;
    [SerializeField] Text  starsText;
    [SerializeField] int stars = 100;
    [SerializeField] Text lifesText;
    [SerializeField] int lifes = 3;
    
    int starsToSpend;


    private void Start()
    {
        //.Log("stars: " + stars);
        //Debug.Log("stars text : " + starsText);
        ToText(stars, starsText);
        ToText(lifes, lifesText);
        //StarsText();
       // LifessText();
        //defender = GameObject.Find("Cactus");
        // Debug.Log(defender);
    }

    public int GetLifes()
    {
        return lifes;
    }

    private void ToText(int number, Text textNumber)
    {
        var toText = number.ToString();
        if (toText != null && textNumber)
        {
            textNumber.text = toText;
        }
    }

    /*private void StarsText()
    {

     var starsToText = stars.ToString();
        if (starsToText != null)
        {
            starsText.text = starsToText;
        }
    }

    private void LifessText()
    {

        var lifesToText = lifes.ToString();
        if (lifesText != null)
        {
            lifesText.text = lifesToText;
        }
    }*/

    public void SpendStars(int starCost)
    {
        stars -= starCost;
        ToText(stars, starsText);

    }
    public void AddStars(int amount)
    {
        //Debug.Log("stars: " + stars);
        //Debug.Log("stars text : " + starsText);
        stars += amount;
        ToText(stars, starsText);
    }

    public void LoseLife()
    {
        lifes -= 1;
        ToText(lifes, lifesText);
    }

    public void AddLifes(int amount)
    {
        lifes += amount;
        ToText(lifes, lifesText);
    }

    public int GetStars()
    {
        return stars;
    }

    // Start is called before the first frame update
 

    public void SelectDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
        starsToSpend = defender.GetStarCost();
    }

    private bool HaveEnoughStars()
    {
        return stars >= starsToSpend;
    }

    private void OnMouseDown()
    {
        //Debug.Log("click!");
        //SelectDefender();
        //Debug.Log(defender);
        if (defender && stars > 0) { SpawnDefender(GetSquareClicked()); }
        
        //SpendStars(defender.GetStarCost());

    }

    private void SpawnDefender(Vector2 positionSpawn)
    {
        //if (positionSpawn.y > 1)
        //{
        if (HaveEnoughStars())
        {
            Defender newDefender = Instantiate(defender, positionSpawn, transform.rotation) as Defender;
            SpendStars(defender.GetStarCost());
        }
        //}

    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

  

    private Vector2 GetSquareClicked()
    {
        Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 positionWorld = Camera.main.ScreenToWorldPoint(pos);

        return SnapToGrid(positionWorld);
    }


    /*public  void SelectDefender()
    {
        Vector2 selectedDefender = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Debug.Log(selectedDefender);
        selectedDefender = GetSquareClicked();
        Debug.Log(selectedDefender);

        if (selectedDefender.y <= 1 && selectedDefender.x <= 1 && selectedDefender.x >=0)
        {
            Debug.Log("inside 1");
           // defender = cactus;
            defender = GameObject.Find("Cactus");
        }
        if(selectedDefender.y <= 1 && selectedDefender.x <= 2 && selectedDefender.x > 1)
        {
            Debug.Log("inside 2");
            //defender = trophy;
            defender = GameObject.Find("Trophy");
        }
        else
        {
            Debug.Log("inside null");
        }
        
    }
    */
}
