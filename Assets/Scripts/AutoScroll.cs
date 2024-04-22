using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    [SerializeField, Range(1f, 50f)]
    private float scrollSpeed = 50f;
    private float watingTime = 5f;
    private float maxScroll;
    private ScrollRect scrollRect;
    private RectTransform contenRectTransform;
    public RectTransform target;
    private Vector2 defaultPosition;
    private bool canMove;
    float diff = 10;
    int levelno = 0;
    public List<float> targetpostion = new List<float>();
    public List<float> spritePos = new List<float>();




    private void Start()
    {
        levelno = PlayerPrefs.GetInt("unlocked", 0);
       scrollRect = GetComponent<ScrollRect>();
       contenRectTransform = this.scrollRect.content;

        for (int i = 0; i < targetpostion.Count; i++)
        {
            
            for (int j= 0; j < 2; j++)
            {
                spritePos.Add(targetpostion[i]);
            }
        }
     //  maxScroll = targe
    }
    private void Update()
    {
        //if(totalcount<targetpostion.Count)
        //{
        //    spritePos[] = targetpostion[totalcount];
        //}
        bool hasScrolled = this.contenRectTransform.localPosition.y > spritePos[levelno];


      // Debug.Log((this.contenRectTransform.localPosition.y - spritePos[levelno]));
        if (!hasScrolled && !canMove)
        {
            this.Move();
        }
        else
        {

            canMove = true;
        }


    }

    private void Move()
    {
        Vector3 contentPosition = this.contenRectTransform.localPosition;
        float newPositionY = contentPosition.y+ this.scrollSpeed;
        Vector3 newPosition = new Vector3(contentPosition.x, newPositionY, contentPosition.z);
        this.contenRectTransform.localPosition = newPosition;

       // Debug.Log(Vector3.Distance(new Vector3(contentPosition.x, spritePos[levelno], contentPosition.z), newPosition));

    }
}
