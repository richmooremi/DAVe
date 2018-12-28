using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public float speed = 5;         //how fast the door moves
    public float secondsToClose;    //how long the door stays open

    public enum OpenDirection { right, left, up, down};
    public OpenDirection openDirection = OpenDirection.right;

    public GameObject requiredKey;  //key needed to open the door, leave empty for none
    public bool doorLocked;
    
    public bool doorOpen;
    public bool autoClose;
    public float horizontalMoveDistance;
    public float verticalMoveDistance;
    private Vector3 closedPosition;

    // Use this for initialization
    void Start ()
    {
        //REMOVE ME
        autoClose = true;
        doorOpen = false;
        secondsToClose = 1;

        //get the original position of this door
        closedPosition = this.transform.position;

        //use the width of this door to determine how far to move it
        //the door only moves 90% of its width
        horizontalMoveDistance = transform.localScale.z * 0.9f;
        verticalMoveDistance = transform.localScale.y * 0.9f;
    }


    public override void onInteraction()
    {

        if (doorOpen)
        {
            //doorOpen = false;
            StopAllCoroutines();
            StartCoroutine(closeDoor());
        }

        else
        {
            //doorOpen = true;
            StopAllCoroutines();
            StartCoroutine(openDoor());
        }
    }

    private IEnumerator closeDoor()
    {
        doorOpen = false;

        while (true)
        {
            if (Vector3.Distance(this.closedPosition, this.transform.position) > 0.05f)
            {
                switch (openDirection)
                {
                    case OpenDirection.right:
                        transform.Translate(Vector3.forward * speed * Time.deltaTime * 1);
                        break;
                    case OpenDirection.left:
                        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);
                        break;
                    case OpenDirection.up:
                        transform.Translate(Vector3.up * speed * Time.deltaTime * -1);
                        break;
                    case OpenDirection.down:
                        transform.Translate(Vector3.up * speed * Time.deltaTime * 1);
                        break;
                }
            }

            else
                StopAllCoroutines();

            yield return null;
        }
    }

    private IEnumerator openDoor()
    {
        doorOpen = true;

        while (true)
        {
            if (Vector3.Distance(this.closedPosition, this.transform.position) < horizontalMoveDistance && (openDirection == OpenDirection.right || openDirection == OpenDirection.left))
            {
                switch (openDirection)
                {
                    case OpenDirection.right:
                        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);
                        break;
                    case OpenDirection.left:
                        transform.Translate(Vector3.forward * speed * Time.deltaTime * 1);
                        break;
  
                }
            }

            else if (Vector3.Distance(this.closedPosition, this.transform.position) < verticalMoveDistance && (openDirection == OpenDirection.up || openDirection == OpenDirection.down))
            {
                switch (openDirection)
                {
                    case OpenDirection.up:
                        transform.Translate(Vector3.up * speed * Time.deltaTime * 1);
                        break;
                    case OpenDirection.down:
                        transform.Translate(Vector3.up * speed * Time.deltaTime * -1);
                        break;
                }
            }

            else
            {
                StopAllCoroutines();

                if(autoClose)
                    StartCoroutine(waitForClose());
            }

            yield return null;
        }
    }

    private IEnumerator waitForClose()
    {
        yield return new WaitForSeconds(secondsToClose);
        StartCoroutine(closeDoor());
    }

}
