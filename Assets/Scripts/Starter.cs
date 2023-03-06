using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Starter : MonoBehaviour
{

    public GameObject Help;
    public GameObject Controls;
    public GameObject Title;
    public GameObject helptext;
    public GameObject Controltext;
    public GameObject Starts;
    public GameObject Helps;
    public GameObject Back;
    private Vector3 offset;
    public GameObject Credits;
    public GameObject Credit;
    public GameObject C;
    public GameObject M;
    public GameObject LoreStory;
    public GameObject quit;
    public GameObject quotes;
    public GameObject backtolore;
    public GameObject quotestext;
    public GameObject quotestilte;
    public GameObject helpbtn;
    public GameObject creditstxt;
    public GameObject lorebtn;
    public GameObject betabtn;
    public GameObject betatxt;
    public GameObject beattitle;
    public GameObject eastereggbtn;
    public GameObject eastereggtxt;
    public GameObject eastereggwhytxt;

    // Use this for initialization
    void Start()
    {
        Help.SetActive(false);
        helptext.SetActive(false);
        Controls.SetActive(false);
        Controltext.SetActive(false);
        Title.SetActive(false);
        Starts.SetActive(false);
        Helps.SetActive(false);
        Back.SetActive(true);
        Credits.SetActive(false);
        Credit.SetActive(false);
        C.SetActive(true);
        M.SetActive(true);
        LoreStory.SetActive(true);
        quit.SetActive(true);
        quotes.SetActive(true);
        backtolore.SetActive(false);
        quotestext.SetActive(false);
        quotestilte.SetActive(false);
        helpbtn.SetActive(false);
        creditstxt.SetActive(false);
        lorebtn.SetActive(false);
        beattitle.SetActive(false);
        betatxt.SetActive(false);
        betabtn.SetActive(false);
        eastereggbtn.SetActive(false);
        eastereggtxt.SetActive(false);
        eastereggwhytxt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}


