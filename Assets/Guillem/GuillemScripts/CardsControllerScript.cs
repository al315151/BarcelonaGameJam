using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardsControllerScript : MonoBehaviour
{

    public Camera camera;

    private bool canClick = true;
    public int clicks, points;

    private GameObject[] cards;
    public List<GameObject> selectedCards;
    float timer = 2f;
    bool endGame = false;

    Vector3 point;
    Vector2 mousePos;
    // Start is called before the first frame update

    public Text score_Text;


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
        timer = 2f;
        point = Vector3.zero;
        selectedCards.Clear();
        canClick = true;
        if(cards == null){
            cards = GameObject.FindGameObjectsWithTag("Apple");
        }
        randomCards();
        clicks = 0;
        points = 0;
        score_Text.text = "Puntuacion: " + points;
    }

    public void Restart(){
        StartCardGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(!endGame){
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
                    if(points >= 10){
                        endGame = true;
                    }
                    score_Text.text = "Puntuacion: " + points;
                    StartCoroutine(waitForFlipWin());
                    canClick = true;
                }
                else{
                    StartCoroutine(waitForFlip());
                    canClick = true;
                }
            }
        }
        else{
            exitGame();
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
        yield return new WaitForSeconds(0.2f);
        flipCard(selectedCards[0]);
        flipCard(selectedCards[1]);
        selectedCards.Clear();
        randomCards();
    }
     IEnumerator waitForFlip(){
        yield return new WaitForSeconds(0.2f);
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

    public void exitGame(){
        if (timer <= 0){
            SceneManager.LoadScene("Oficina");
        }
        else{
            timer -= Time.deltaTime;
        }
    }
}
