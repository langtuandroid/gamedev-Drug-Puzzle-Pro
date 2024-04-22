using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class Levelselection : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] levelsprites;
    public GameObject Container;
    int numberoflevelunlocked;
    bool isRotated = false,isrotated1 = false;
    int j = 0;
  
    void Start()
    {
       
        numberoflevelunlocked = PlayerPrefs.GetInt("unlocked");

        for(int i = 0; i < Container.transform.childCount; i++)
        {
            Container.transform.GetChild(i).GetChild(3).GetComponent<Text>().text = (i + 1).ToString();
            Container.transform.GetChild(i).GetChild(4).GetChild(1).GetComponent<Image>().sprite = levelsprites[i];
            //Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            //Color newColor1 = new Color(Random.value, Random.value, Random.value, 1.0f);
            //Container.transform.GetChild(i).GetChild(4).GetChild(0).GetComponent<Image>().color = newColor;
            //Container.transform.GetChild(i).GetChild(1).GetComponent<Image>().color = newColor1;
           // Container.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
            Container.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
            if (i < Container.transform.childCount - 1)
            {
                
                 //   randomRotation(Container.transform.GetChild(i).GetChild(3), Container.transform.GetChild(i + 1).GetChild(3));
               
                
            }
        } 
        
        for(int i = 0; i < numberoflevelunlocked; i++)
        {
            
            Container.transform.GetChild(i).GetChild(4).gameObject.SetActive(true);


        }
        randomRotation();

        for (int i = 0; i <= numberoflevelunlocked; i++)
        {
            Container.transform.GetChild(i).GetChild(5).gameObject.SetActive(false);
            Container.transform.GetChild(i).GetComponent<Image>().enabled = false;

            if(i<numberoflevelunlocked)
            {
                Container.transform.GetChild(i).GetChild(3).gameObject.SetActive(false);
                Container.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                Container.transform.GetChild(i).GetChild(1).GetComponent<Image>().enabled = false;
            }else
            {
                Container.transform.GetChild(i).GetChild(3).gameObject.SetActive(true);
                Container.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }
            
            Container.transform.GetChild(i).GetChild(2).GetComponent<Button>().interactable = true;
        }


    }
    int count = 0;
    int test = 0;
    public List<RANDOM> mypattern=new List<RANDOM>();

    public List<GameObject> evennumber = new List<GameObject>();
    public List<GameObject> oddnumber = new List<GameObject>();

    void randomRotation()
    {

        for(int i=0;i< Container.transform.childCount; i++)
        {
            if (i%2==0)
            {
                evennumber.Add(Container.transform.GetChild(i).GetChild(4).gameObject);
            }
            else
            {
                oddnumber.Add(Container.transform.GetChild(i).GetChild(4).gameObject);
            }
            
        }
            
        for(int i = 0; i < evennumber.Count; i++)
        {
            if (i % 2 == 0)
            {
                evennumber[i].transform.DOLocalRotate(new Vector3(0, 0, mypattern[0].pattern[1]), 0.3f);
            }
            else
            {
                evennumber[i].transform.DOLocalRotate(new Vector3(0, 0, mypattern[0].pattern[0]), 0.3f);
            }
        } for(int i = 0; i < oddnumber.Count; i++)
        {
            if (i % 2 == 0)
            {
                oddnumber[i].transform.DOLocalRotate(new Vector3(0, 0, mypattern[0].pattern[0]), 0.3f);
            }
            else
            {
                oddnumber[i].transform.DOLocalRotate(new Vector3(0, 0, mypattern[0].pattern[1]), 0.3f);
            }
        }
    }
        public void levelselected()
        {
            SceneManager.LoadScene(int.Parse(EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(3).GetComponent<Text>().text)+1);
        }
    
}
[System.Serializable]
public class RANDOM
{
    public List<int> pattern = new List<int>();
}
