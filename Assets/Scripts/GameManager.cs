using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using FunGames.Sdk.Analytics;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("For any Queries Contact Us Gmail id: dollar99games@gmail.com ")]
    [Header("For any Queries Contact Us Skyid: dollar99games@outlook.com ")]
    [SerializeField]
    public string Contact_us_on_Gmail = "dollar99games@gmail.com";
    public string Contact_us_on_Skype = "dollar99games@outlook.com";

    public static GameManager instance;
    int totalBricksInAlevel;
    public int bricksCount;
    public Animator dragAnim;
    public Animator lastSprite;
    public GameObject BgImage;
    public GameObject DragObj;
    public GameObject lastEffect,peiceEffect;
    public Material mat;
    public List<Color> randomColors = new List<Color>();
    public MeshRenderer ground;

    public Material transparenteffect;

    public List<GameObject> allBricks = new List<GameObject>();

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        ground = GameObject.Find("Ground").GetComponent<MeshRenderer>();
        dragAnim = FindObjectOfType<DraggObjects>().GetComponent<Animator>();
        for (int i = 0; i < dragAnim.transform.childCount; i++)
        {
            allBricks.Add(dragAnim.transform.GetChild(i).GetChild(0).gameObject);
        }

    }
    private void Start()
    {
        totalBricksInAlevel = FindObjectOfType<FixedParent>().transform.childCount;
        DragObj = dragAnim.gameObject;
        lastSprite = GameObject.Find("lastSpriite").GetComponent<Animator>();
        BgImage = GameObject.Find("images").gameObject;
        dragAnim.enabled = false;
        int randomNo = Random.Range(0, randomColors.Count);
       // ground.material.SetColor("_BaseColor", randomColors[randomNo]);

       
            
    }

    public void CheckLevelUp()
    {
        bricksCount++;
        if (totalBricksInAlevel == bricksCount)
        {
            canvasmanager.Instance.thankYouPanel.SetActive(true);
            canvasmanager.Instance.startTimer = false;
            Debug.Log("Level Completed");
            Invoke("delayObj", 1.5f);
            BgImage.SetActive(false);
            dragAnim.enabled = true;
            lastSprite.enabled = true;
            Invoke("LevelCompletePanel", 5f);
            soundmanager.instance.playmysound(soundmanager.instance.smallwin);

        }
    }
    void delayObj()
    {
        DragObj.SetActive(false);
    }

    void LevelCompletePanel()
    {
        canvasmanager.Instance.PlayParticels();
        Invoke("particle", 1.80f);
        canvasmanager.Instance.buttonPanel.SetActive(false);
        canvasmanager.Instance.LevelCompletePanel.SetActive(true);
        soundmanager.instance.playmysound(soundmanager.instance.levelcomplete);
       // FunGamesAnalytics.NewProgressionEvent("Complete", canvasmanager.Instance.levelNo.ToString(),"", canvasmanager.Instance.coins);
    }
   

    void particle()
    {
        lastEffect.SetActive(true);
    }
}
