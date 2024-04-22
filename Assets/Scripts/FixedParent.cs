using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class FixedParent : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("For any Queries Contact Us Gmail id: dollar99games@gmail.com ")]
    [Header("For any Queries Contact Us Skyid: dollar99games@outlook.com ")]
    [SerializeField]
    public string Contact_us_on_Gmail = "dollar99games@gmail.com";
    public string Contact_us_on_Skype = "dollar99games@outlook.com";


    public List<GameObject> sameObject = new List<GameObject>();
    public List<GameObject> sameObject1 = new List<GameObject>();
    public List<GameObject> sameObject2 = new List<GameObject>();
    public List<GameObject> sameObject3 = new List<GameObject>();
    public bool hide = false;
    public int count = 0;
    public int number,number1,number2,number3;

    void Start()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            this.transform.GetChild(i).GetChild(0).GetComponent<MeshCollider>().enabled = false;
        }
        if(count==4)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number == int.Parse(transform.GetChild(i).name))
                {
                    sameObject.Add(transform.GetChild(i).gameObject);
                }
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number1 == int.Parse(transform.GetChild(i).name))
                {
                    sameObject1.Add(transform.GetChild(i).gameObject);
                }
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number2 == int.Parse(transform.GetChild(i).name))
                {
                    sameObject2.Add(transform.GetChild(i).gameObject);
                }
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number3 == int.Parse(transform.GetChild(i).name))
                {
                    sameObject3.Add(transform.GetChild(i).gameObject);
                }
            }

        }
        else if(count==2)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number == int.Parse(transform.GetChild(i).name))
                {
                    sameObject.Add(transform.GetChild(i).gameObject);
                }
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number1 == int.Parse(transform.GetChild(i).name))
                {
                    sameObject1.Add(transform.GetChild(i).gameObject);
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (number == int.Parse(transform.GetChild(i).name))
                {
                    sameObject.Add(transform.GetChild(i).gameObject);
                }
            }
        }
       
        // this.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 1f).From().SetEase(Ease.OutElastic);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateselectobjectcollider(int selected)
    {
        if (!hide)
        {
            this.transform.GetChild(selected - 1).GetChild(0).GetComponent<MeshCollider>().enabled = true;
        }
        else
        {
            if(count==1)
            {
                for (int i = 0; i < sameObject.Count; i++)
                {
                    sameObject[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;
                }
            }else if(count==2)
            {
                for (int i = 0; i < sameObject1.Count; i++)
                {
                    sameObject1[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;
                }
            }
            else if (count == 3)
            {
                for (int i = 0; i < sameObject2.Count; i++)
                {
                    sameObject2[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;
                }
            }
            else if (count == 4)
            {
                for (int i = 0; i < sameObject3.Count; i++)
                {
                    sameObject3[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;
                }
            }

        }
    }
    public void decactivateselectedcollider(int selected)
    {
        if (!hide)
        {
            this.transform.GetChild(selected - 1).GetChild(0).GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            if (count == 1)
            {
                for (int i = 0; i < sameObject.Count; i++)
                {
                    sameObject[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
                }
            }
            else if (count == 2)
            {
                for (int i = 0; i < sameObject1.Count; i++)
                {
                    sameObject1[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
                }
            }
            else if (count == 3)
            {
                for (int i = 0; i < sameObject2.Count; i++)
                {
                    sameObject2[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
                }
            }
            else if (count == 4)
            {
                for (int i = 0; i < sameObject3.Count; i++)
                {
                    sameObject3[i].transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
                }
            }
        }
    }
}
