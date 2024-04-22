using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Player : MonoBehaviour
{
    // Start is called before the first frame update
#if UNITY_EDITOR
    private float Speed=10;
#else
    private float Speed=5;
#endif
    Vector3 startpos;
    Transform fixPosition;

    public bool IsOnObject = false;

    FixedParent fixedParent;

    float startPosInZ;

    public int count = 1;

    public GameObject sprite;

    public bool tutorial = false;


    private void Awake()
    {
        fixedParent = FindObjectOfType<FixedParent>();
        startpos = this.transform.parent.position;
    }
    void Start()
    {
        Transform _parent = this.transform.parent;
        startPosInZ = _parent.transform.position.z;

    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!IsOnObject)
            {
                this.transform.parent.position = startpos;
            }
            
            if (IsOnObject)
            {

                this.transform.parent.position = fixPosition.position;
                this.transform.parent.transform.DOMoveZ(fixPosition.position.z, 0.1f).SetEase(Ease.OutElastic);
                Vector3 newPos = new Vector3(fixPosition.position.x, fixPosition.position.y, -2f);
                MeshRenderer mesh = GetComponent<MeshRenderer>();
               // mesh.material = GameManager.instance.mat;
                GameObject obj = Instantiate(GameManager.instance.peiceEffect, newPos, this.transform.parent.rotation);
               // obj.transform.position = fixPosition;
                //obj.transform.GetChild(0).GetComponent<MeshRenderer>().material = GameManager.instance.transparenteffect;
                //obj.transform.DOScale(new Vector3(this.transform.parent.localScale.x + 0.15f,
                //    this.transform.parent.localScale.y + 0.15f,
                //    this.transform.parent.localScale.z + 0.15f), 0.1f);//.SetEase(Ease.OutExpo);
                if(fixedParent.sameObject.Contains(fixPosition.gameObject))
                {
                    fixedParent.sameObject.Remove(fixPosition.gameObject);
                   
                }
                else if (fixedParent.sameObject1.Contains(fixPosition.gameObject))
                {
                    fixedParent.sameObject1.Remove(fixPosition.gameObject);
                   
                }
                else if (fixedParent.sameObject2.Contains(fixPosition.gameObject))
                {
                    fixedParent.sameObject2.Remove(fixPosition.gameObject);
                }
                else if (fixedParent.sameObject3.Contains(fixPosition.gameObject))
                {
                    fixedParent.sameObject3.Remove(fixPosition.gameObject);
                    
                }
                Destroy(obj, 1.5f);
              //  Destroy(fixPosition.gameObject);
                GameManager.instance.CheckLevelUp();
                Destroy(this.gameObject.GetComponent<MeshCollider>());
                Destroy(this.gameObject.GetComponent<Rigidbody>());
                Destroy(this.gameObject.GetComponent<Player>());
                soundmanager.instance.playmysound(soundmanager.instance.drop);

            }
            else
            {
                this.transform.parent.transform.DOMoveZ(startPosInZ, 0.3f).SetEase(Ease.OutElastic);
            }
        }

    }
    private void OnMouseDrag()
    {

#if UNITY_EDITOR

     
                float rotX = Input.GetAxis("Mouse X") * Speed * Mathf.Deg2Rad;
                float roty = Input.GetAxis("Mouse Y") * Speed * Mathf.Deg2Rad;
                this.transform.parent.position += new Vector3(rotX, roty,0);
        //  this.transform.parent.position = new Vector3(Mathf.Clamp(this.transform.parent.position.x, -1.69f, 1.69f), Mathf.Clamp(this.transform.parent.position.y, -4f, 4.69f), this.transform.parent.position.z );
#else
        //---------------------------------------------------------------------------------
		if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved )
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			float rotX = touchDeltaPosition.x* Speed/18* Mathf.Deg2Rad;
			float roty = touchDeltaPosition.y* Speed/18* Mathf.Deg2Rad;

            this.transform.parent.position += new Vector3(rotX, roty,0);
              //  this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -1.1f, 1.1f), this.transform.position.y, Mathf.Clamp(this.transform.position.z, -0.8f, 2f));
		}	
        
#endif
    }
    public void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.transform.parent.gameObject.name == this.transform.parent.gameObject.name)
        {
            fixPosition= collision.transform.parent;
            if (Input.GetMouseButtonUp(0))
            {
                if(tutorial)
                sprite.SetActive(false);
                 StartCoroutine(waitforfixit(collision.transform.parent.name));
            }
            IsOnObject = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.parent.gameObject.name == this.transform.parent.gameObject.name)
        { 
            IsOnObject = false;
        }
    }
    public void OnMouseDown()
    {
        fixedParent.count = count;
        if (count==1)
        {
            if (int.Parse(transform.name) == fixedParent.number)
            {
                fixedParent.hide = true;
            }
            else
            {
                fixedParent.hide = false;
            }
        }else if(count==2)
        {
            if (int.Parse(transform.name) == fixedParent.number1)
            {
                fixedParent.hide = true;
            }
            else
            {
                fixedParent.hide = false;
            }
        }
        else if (count == 3)
        {
            if (int.Parse(transform.name) == fixedParent.number2)
            {
                fixedParent.hide = true;
            }
            else
            {
                fixedParent.hide = false;
            }
        }
        else if (count == 4)
        {
            if (int.Parse(transform.name) == fixedParent.number3)
            {
              
                fixedParent.hide = true;
            }
            else
            {
                fixedParent.hide = false;
            }
        }

        //   Transform _parent = this.transform.parent;
        this.transform.parent.transform.DOMoveZ(startPosInZ - 0.2f, 0.1f).SetEase(Ease.OutElastic);
       // _parent.transform.DOScale(
         //   new Vector3(
         //   _parent.localScale.x - 0.5f,
          //  _parent.localScale.y - 0.5f, 
           // _parent.localScale.z - 0.5f), 0.2f).From().SetEase(Ease.OutElastic);

      fixedParent.activateselectobjectcollider(int.Parse(this.transform.parent.gameObject.name));
      soundmanager.instance.playmysound(soundmanager.instance.pick);

    }
    public void OnMouseUp()
    {

        StartCoroutine(waitforfixit(this.transform.parent.gameObject.name));
        if(!IsOnObject)
            soundmanager.instance.playmysound(soundmanager.instance.movetostartposition);

    }

    IEnumerator waitforfixit(string selected)
    {
        fixedParent.decactivateselectedcollider(int.Parse(selected));
        yield return new WaitForSeconds(0);
    }
}


