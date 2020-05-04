using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public GameObject charselect, selection, prevapa, prevdema, prevfgitis, prevfoma, prevrino, prevfarin, 
        prevdift, prevbron, prevgast, prevhemo, prevcolit, prevcalc, prevles, prevartr, prevesclr, prevane, LoadPanel;
    public GameObject asp, par, amox, clox, borz, lena, vor, clav, penl, eritr, flox, neco, mclr, feno, zina, lona, sol, 
        alna, pipe, tazo, mlona, quina, hzina, xsona, b;
    private Image imgone, imgtwo, imgthree;
    private Text lblone, lbltwo, lblthree, nameboss, descboss;
    private Text cantasp, cantpar, cantamox, cantclox, cantborz, cantlena, cantvor, cantclav, cantpenl, canteritr,
        cantflox, cantneco, cantmclr, cantfeno, cantzina, cantlona, cantsol, cantalna, cantpipe, canttazo, cantmlona,
        cantquina, canthzina, cantxsona, cantb;
    private int[] cant;
    private int slot, boss, id_charone, id_chartwo, id_charthree, id_slot_one, id_slot_two, id_slot_three;
    Archivos archivo_organismo;

    void Start()
    {
        archivo_organismo = GameObject.Find("BossSelection").GetComponent<Archivos>();        
        cant = new int[26];
        cant = archivo_organismo.GetTotalChar();        
        imgone = GameObject.Find("FirstChar").GetComponent<Image>();
        imgtwo = GameObject.Find("SecChar").GetComponent<Image>();
        imgthree = GameObject.Find("ThirdChar").GetComponent<Image>();
        imgone.sprite = Resources.Load<Sprite>("none");
        imgtwo.sprite = Resources.Load<Sprite>("none");
        imgthree.sprite = Resources.Load<Sprite>("none");
        lblone = GameObject.Find("lbl_Charone").GetComponent<Text>();
        lbltwo = GameObject.Find("lbl_Chartwo").GetComponent<Text>();
        lblthree = GameObject.Find("lbl_Charthree").GetComponent<Text>();
        lblone.text = "Seleccionar...";
        lbltwo.text = "Seleccionar...";
        lblthree.text = "Seleccionar...";
        nameboss = GameObject.Find("NameBoss").GetComponent<Text>();
        descboss = GameObject.Find("DescBoss").GetComponent<Text>();
        boss = archivo_organismo.LevelBoss();
        nameboss.text = archivo_organismo.NameBoss(boss);
        descboss.text = archivo_organismo.descBoss(boss);
        
        switch (boss)
        {
            case 1:
                prevapa.SetActive(true);
                break;
            case 2:
                prevdema.SetActive(true);
                break;
            case 3:
                prevfgitis.SetActive(true);
                break;
            case 4:
                prevfoma.SetActive(true);
                break;
            case 5:
                prevrino.SetActive(true);
                break;
            case 6:
                prevfarin.SetActive(true);
                break;
            case 7:
                prevdift.SetActive(true);
                break;
            case 8:
                prevbron.SetActive(true);
                break;
            case 9:
                prevgast.SetActive(true);
                break;
            case 10:
                prevhemo.SetActive(true);
                break;
            case 11:
                prevcolit.SetActive(true);
                break;
            case 12:
                prevcalc.SetActive(true);
                break;
            case 13:
                prevles.SetActive(true);
                break;
            case 14:
                prevartr.SetActive(true);
                break;
            case 15:
                prevesclr.SetActive(true);
                break;
            case 16:
                prevane.SetActive(true);
                break;
        }
    }
    
    void Update()
    {
        
    }

    private void ViewCharacters()
    {
        if (cant[0] < 1)
        {
            asp.SetActive(false);
        }
        else
        {
            asp.SetActive(true);
            cantasp= GameObject.Find("cant_asp").GetComponent<Text>();
            cantasp.text = (cant[0]).ToString();
        }
    }

    public void Back()
    {
        HidePrevBoss();
        LoadScene.sceneToLoad = "Mapajuego";
        LoadPanel.SetActive(true);
    }

    public void HideChar()
    {
        charselect.SetActive(false);
    }

    private void PutSlot(string character, int id)
    {
        switch (slot)
        {
            case 1:
                imgone.sprite = Resources.Load<Sprite>(character);
                lblone.text = archivo_organismo.NameCharacter(id);
                cant[id]--;
                id_slot_one = id;
                break;
            case 2:
                imgtwo.sprite = Resources.Load<Sprite>(character);
                lbltwo.text = archivo_organismo.NameCharacter(id);
                cant[id]--;
                id_slot_two = id;
                break;
            case 3:
                imgthree.sprite = Resources.Load<Sprite>(character);
                lblthree.text = archivo_organismo.NameCharacter(id);
                cant[id]--;
                id_slot_three = id;
                break;
        }
    }

    private void HidePrevBoss()
    {
        prevapa.SetActive(false);
        prevdema.SetActive(false);
        prevfgitis.SetActive(false);
        prevfoma.SetActive(false);
        prevrino.SetActive(false);
        prevfarin.SetActive(false);
        prevdift.SetActive(false);
        prevbron.SetActive(false);
        prevgast.SetActive(false);
        prevhemo.SetActive(false);
        prevcolit.SetActive(false);
        prevcalc.SetActive(false);
        prevles.SetActive(false);
        prevartr.SetActive(false);
        prevesclr.SetActive(false);
        prevane.SetActive(false);
    }

    public void SelectOne()
    {
        slot = 1;
        charselect.SetActive(true);
        ViewCharacters();
    }

    public void SelectTwo()
    {
        slot = 2;
        charselect.SetActive(true);
        ViewCharacters();
    }

    public void SelectThree()
    {
        slot = 3;
        charselect.SetActive(true);
        ViewCharacters();
    }

    public void Ready()
    {
        HidePrevBoss();
        LoadScene.sceneToLoad = "Battle";
        LoadPanel.SetActive(true);        
    }

    public void MinusOne()
    {
        imgone.sprite = Resources.Load<Sprite>("none");
        lblone.text = "Seleccionar...";
        cant[id_slot_one]++;        
    }

    public void ActAsp()
    {        
        PutSlot("aspirina", 0);
        charselect.SetActive(false);
    }



}
