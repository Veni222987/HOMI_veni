using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullView : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] outLineMaterials;
    private GameObject HomeBotton,SquareBotton,MineBotton;
    private Image HomeImg, SquareImg, MineImg;
    void Start()
    {
        HomeBotton=GameObject.Find("Home");
        SquareBotton=GameObject.Find("Square");
        MineBotton=GameObject.Find("Mine");
        HomeImg = HomeBotton.GetComponent<Image>();
        SquareImg = SquareBotton.GetComponent<Image>();
        MineImg = MineBotton.GetComponent<Image>();
        outLineMaterials = new Material[3];
        outLineMaterials[0] = HomeImg.material;
        outLineMaterials[1] = SquareImg.material;
        outLineMaterials[2] = MineImg.material;

        foreach (var mat in outLineMaterials)
        {
            HideOutline(mat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    
    //2D图片边框材质
    
    
    private void ShowOutline(Material outLineMat)
    {
        outLineMat.SetFloat("_Thickness", 2);
    }

    private void HideOutline(Material outLineMat)
    {
        outLineMat.SetFloat("_Thickness", 0);
    }

    public void ClickHome()
    {
        ShowOutline(outLineMaterials[0]);
        //HideOutline(outLineMaterials[1]);
        //(outLineMaterials[2]);
    }
    public void ClickSquare()
    {
        ShowOutline(outLineMaterials[1]);
        //HideOutline(outLineMaterials[0]);
        //HideOutline(outLineMaterials[2]);
    }

    public void ClickMine()
    {
        ShowOutline(outLineMaterials[2]);
        //HideOutline(outLineMaterials[0]);
        //HideOutline(outLineMaterials[1]);
    }
}
