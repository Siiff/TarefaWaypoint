using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //array de waypoints e o atual waypoint//
    public GameObject[] waypoints;
    int currentWP = 0;

    //Floats//
    [Header ("Variaveis")]
    [Range (0.0f, 5.0f)]
    public float speed = 1.0f, //velocidade do cubo
        accuracy = 1.0f, //precisão do cubo ~distancia da qual ele ira parar do ponto~
        rotspeed = 0.4f; //rotação do cubo para a nova rota

    private void Start()
    {
        //Encontrando os objetos na cena com a tag "waypoint"//
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); 
    }

    //ao fim de cada frame
    private void LateUpdate()
    {
        //retornando valor 0
        if (waypoints.Length == 0) return;
        {
            //definindo o vetor do local objetivo
            Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);
            //fazendo o calculo da localização atual e do alvo
            Vector3 direction = lookAtGoal - this.transform.position;
            //rotação do cubo
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotspeed);
            //Se a magnitude for menor que a "precisão", adicionar +1 em currentWP para prosseguir pro proximo waypoint
            if(direction.magnitude < accuracy)
            {
                currentWP++;
                //Se a quantidade de currentwp for maior q o array, zerar
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }
        }
        //aplicando no translate desse objeto a velocidade vezes deltaTime
        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }


}
