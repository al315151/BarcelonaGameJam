﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public GameObject snakeTail;
    private Vector3 direction = -Vector3.forward;
    private Vector3 passPosition, lastPosition, newPos, lastDirection, rotationDirection;

    private Quaternion actualRotation, lastRotation, rotationBody;
    private float moveCD = 0f;

    public List<GameObject> snake;

    bool canPlay = true;

    void Update()
    { 
        if(canPlay){      
            getInputs();
            movementSnake();
        }
  
    }

    void movementSnake(){
        
        if(Mathf.Abs(transform.position.x) < 11 && Mathf.Abs(transform.position.z) < 11){
            if (moveCD > 0f){
                moveCD -= Time.deltaTime;
            }
            else if(moveCD <= 0f){
                if(lastDirection != -direction){
                    newPos = transform.position + direction;
                    //Actualiza la posición de la lista
                    if(snake.Count != 0){
                        passPosition = transform.position;
                        lastRotation = transform.rotation;
                        for(int i = 0; i < snake.Count; i++){
                            rotationBody = snake[i].transform.rotation;

                            lastPosition = snake[i].transform.position;

                            snake[i].transform.rotation = lastRotation;
                            snake[i].transform.position = passPosition; 

                            lastRotation = rotationBody;
                            passPosition = lastPosition;
                        }
                    }

                    actualRotation = Quaternion.Euler(0, rotationDirection.y, 0);
                    transform.rotation = actualRotation;
                    transform.position = newPos;
                    lastDirection = direction;
                    moveCD = 0.3f;
                }
                else{
                    newPos = transform.position + lastDirection;
                    //Actualiza la posición de la lista
                    if(snake.Count != 0){
                        passPosition = transform.position;
                        for(int i = 0; i < snake.Count; i++){
                            lastPosition = snake[i].transform.position;
                            snake[i].transform.position = passPosition; 
                            passPosition = lastPosition;
                        }
                    }
                    transform.position = newPos;
                    moveCD = 0.3f;
                }
            }
        }
        else{
            Destroy(this.gameObject);
            canPlay = false;
            print("Fin del Juego");
        }
    }

    void getInputs(){
        if(Input.GetKeyDown(KeyCode.W) && direction != -Vector3.forward){
            direction = Vector3.forward;
            rotationDirection = new Vector3(0, 180, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A) && direction != Vector3.right){
            direction = Vector3.left;
            rotationDirection = new Vector3(0, 90, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D) && direction != Vector3.left){
            direction = Vector3.right;
            rotationDirection = new Vector3(0, -90, 0);
        }
        else if(Input.GetKeyDown(KeyCode.S) && direction != Vector3.forward){
            direction = -Vector3.forward;
            rotationDirection = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Apple"){
            Destroy(other.gameObject);
            AppleSpawner.appleCount--;
            GameObject aux = Instantiate(snakeTail, transform.position - direction, Quaternion.identity);
            snake.Add(aux);
        }

        if(other.tag == "Tail"){
            Destroy(this.gameObject);
            canPlay = false;
            print("FIN DEL JUEGO POR CHOQUE");
        }
    }
}
