using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsControllerScript : MonoBehaviour
{

    public Camera camera;

    private bool canClick = true;
    public int clicks, points;

    private GameObject[] cards;
    public List<GameObject> selectedCards;

    Vector3 point;
    Vector2 mousePos;
    // Start is called before the first frame update

    void OnEnable() {
        StartCardGame();
    }

    void OnDisable() {
        cards = new GameObject[0];
        selectedCards.Clear();
    }
    public void StartCardGame()
    {
        mousePos = Vector2.zero;
        point = Vector3.zero;
        selectedCards.Clear();
        canClick = true;
        if(cards == null){
            cards = GameObject.FindGameObjectsWithTag("Apple");
        }
        randomCards();
        clicks = 0;
        points = 0;
    }

    public void Restart(){
        StartCardGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canClick){
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            point = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane)); 
            if(detectCard()){
                clicks ++;
                if(clicks >= 2){
                    canClick = false;
                    clicks = 0;
                }
            }
        }

        if(!canClick && selectedCards.Count == 2){
            if(selectedCards[0].GetComponent<CardColor>().color == selectedCards[1].GetComponent<CardColor>().color){
                points ++;
                StartCoroutine(waitForFlipWin());
                canClick = true;
            }
            else{
                StartCoroutine(waitForFlip());
                canClick = true;
            }
        }
    }

    bool detectCard(){
        RaycastHit hit;
        if (Physics.Raycast(point, Vector3.forward, out hit, Mathf.Infinity))
        {
            selectedCards.Add(hit.collider.gameObject);
            flipCard(hit.collider.gameObject);
            return true;
        }
        return false;
    }

    void flipCard(GameObject obj){
        obj.transform.Rotate(new Vector3(0, 0, 180));
    }

    IEnumerator waitForFlipWin(){
        yield return new WaitForSeconds(0.5f);
        flipCard(selectedCards[0]);
        flipCard(selectedCards[1]);
        selectedCards.Clear();
        randomCards();
    }
     IEnumerator waitForFlip(){
        yield return new WaitForSeconds(0.5f);
        flipCard(selectedCards[0]);
        flipCard(selectedCards[1]);
        selectedCards.Clear();
    }

    void randomCards(){
        Vector3 auxPos;
        int random;
        for(int i = 0; i < cards.Length; i++){
            random = (int)Random.Range(0, cards.Length);
            if(cards[i].transform.position != cards[random].transform.position){
                auxPos = cards[i].transform.position;
                cards[i].transform.position = cards[random].transform.position;
                cards[random].transform.position = auxPos;
            }
        }
    }
}
