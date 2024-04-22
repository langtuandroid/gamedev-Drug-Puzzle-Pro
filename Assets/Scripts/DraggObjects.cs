using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DraggObjects : MonoBehaviour
{

    [Header("For any Queries Contact Us Gmail id: dollar99games@gmail.com ")]
    [Header("For any Queries Contact Us Skyid: dollar99games@outlook.com ")]
    [SerializeField]
    public string Contact_us_on_Gmail = "dollar99games@gmail.com";
    public string Contact_us_on_Skype = "dollar99games@outlook.com";


    // Start is called before the first frame update
    public GameObject constantObjectParent;
    void Start()
    {
        SettingPosition();
    }

    // Update is called once per frame
    public void SettingPosition()
    {
        for(int i = 0; i < constantObjectParent.transform.childCount; i++)
        {
            constantObjectParent.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(i).DOMove(constantObjectParent.transform.GetChild(i).position, 1f).From().SetEase(Ease.InOutBack);
            transform.GetChild(i).DOLocalRotate(new Vector3(-90, 0, Random.Range(0, 360)), 1f).From().SetEase(Ease.Linear);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
