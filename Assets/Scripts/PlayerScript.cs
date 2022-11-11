using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private bool isMoving;
    private Vector2 input;
    public LayerMask solidObjectsLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");

            /*if(input.x != 0) {
                input.y=0;
            }*/
            if(input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;

                if(isWalkable(targetPos))
                {
                    StartCoroutine(move(targetPos));

                }
                

            }
        }
    }
    IEnumerator move(Vector3 targetPos)
    {
        isMoving=true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving=false;
    }
    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos,0.7f,solidObjectsLayer)!=null)
        {
            return false;
        }
        return true;

    }
}
