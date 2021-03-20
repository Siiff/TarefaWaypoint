using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //array de waypoints e o atual waypoint//
    public GameObject[] waypoints;
    int currentWP = 0;

    //Floats//
    float speed = 1.0f, //velocidade do cubo
        accuracy = 1.0f, //precisão do cubo ~distancia da qual ele ira parar do ponto~
        rotspeed = 0.4f; //rotação do cubo para a nova rota

    private void Start()
    {
        //Encontrando os objetos na cena com a tag "waypoint"//
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        
    
    }


}
