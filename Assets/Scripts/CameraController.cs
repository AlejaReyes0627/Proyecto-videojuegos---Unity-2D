using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camara para cambiar de cuarto
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Seguir al jugador
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDist = 5;
    [SerializeField] private float cameraSpeed = 2;
    private float lookahead;
    private void Update()
    {
        // Camara para cambiar de cuarto
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        //Seguir Jugador
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        lookahead = Mathf.Lerp(lookahead, (aheadDist * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
