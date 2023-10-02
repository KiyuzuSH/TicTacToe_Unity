using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    // 圆与叉的精灵
    public Sprite maru;     public Sprite batu;
    // 九宫格的图像
    public Image picPos1;   public Image picPos2;   public Image picPos3;
    public Image picPos4;   public Image picPos5;   public Image picPos6;
    public Image picPos7;   public Image picPos8;   public Image picPos9;
    // 九宫格的按钮
    public Button btnPos1;  public Button btnPos2;  public Button btnPos3;
    public Button btnPos4;  public Button btnPos5;  public Button btnPos6;
    public Button btnPos7;  public Button btnPos8;  public Button btnPos9;
    // 输赢和玩家指示的文字
    public Image imgWin;    public Text txtWin;
    public Image imgWho;    public Text txtWho;
    public Button btnRST;
    public Text txtLose;
    // 现在谁在下
    private int nWho;  // batu = 0; maru = 1;
    // 内部储存棋盘的状态
    private int [,] s;
    // 棋局的输赢状态
    private int win;

    void Start() { Initialization(); }

    // 初始化
    public void Initialization() {
        nWho = 0;
        win = -1;
        s = new int [3, 3] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };  // 这里是每次重置棋盘存储矩阵的位置
        imgWin.sprite = null;
        imgWin.color = new Color(255, 255, 255, 0);
        txtWin.color = new Color(255, 62, 62, 0);
        txtLose.color = new Color(255, 0, 255, 0);
        imgWho.color = new Color(255, 255, 255, 255);
        txtWho.color = new Color(255, 255, 255, 255);
        ButtonTransStart();
        PicPosReset();
        ControllerUpdate();
    }

    // 第1到第9个按钮的更新响应
    public void btn1() {
        if(picPos1.sprite != null)  return; // 判定为非空
        else {
            if(nWho == 0)       picPos1.sprite = batu;
            else if(nWho == 1)  picPos1.sprite = maru;
            picPos1.color = new Color(255, 255, 255, 255);
            s [0, 0] = nWho;
            WinCheck();
        }
    }

    public void btn2()     {
        if(picPos2.sprite != null)  return;
        else {
            if(nWho == 0)       picPos2.sprite = batu;
            else if(nWho == 1)  picPos2.sprite = maru;
            picPos2.color = new Color(255, 255, 255, 255);
            s [0, 1] = nWho;
            WinCheck();
        }
    }

    public void btn3() {
        if(picPos3.sprite != null)  return;
        else {
            if(nWho == 0)       picPos3.sprite = batu;
            else if(nWho == 1)  picPos3.sprite = maru;
            picPos3.color = new Color(255, 255, 255, 255);
            s [0, 2] = nWho;
            WinCheck();
        }
    }

    public void btn4() {
        if(picPos4.sprite != null)  return;
        else {
            if(nWho == 0)       picPos4.sprite = batu;
            else if(nWho == 1)  picPos4.sprite = maru;
            picPos4.color = new Color(255, 255, 255, 255);
            s [1, 0] = nWho;
            WinCheck();
        }
    }

    public void btn5() {
        if(picPos5.sprite != null)  return;
        else {
            if(nWho == 0)       picPos5.sprite = batu;
            else if(nWho == 1)  picPos5.sprite = maru;
            picPos5.color = new Color(255, 255, 255, 255);
            s [1, 1] = nWho;
            WinCheck();
        }
    }

    public void btn6() {
        if(picPos6.sprite != null)  return;
        else {
            if(nWho == 0)       picPos6.sprite = batu;
            else if(nWho == 1)  picPos6.sprite = maru;
            picPos6.color = new Color(255, 255, 255, 255);
            s [1, 2] = nWho;
            WinCheck();
        }
    }

    public void btn7() {
        if(picPos7.sprite != null)  return;
        else {
            if(nWho == 0)       picPos7.sprite = batu;
            else if(nWho == 1)  picPos7.sprite = maru;
            picPos7.color = new Color(255, 255, 255, 255);
            s [2, 0] = nWho;
            WinCheck();
        }
    }

    public void btn8() {
        if(picPos8.sprite != null)  return;
        else {
            if(nWho == 0)       picPos8.sprite = batu;
            else if(nWho == 1)  picPos8.sprite = maru;
            picPos8.color = new Color(255, 255, 255, 255);
            s [2, 1] = nWho;
            WinCheck();
        }
    }

    public void btn9() {
        if(picPos9.sprite != null)  return;
        else {
            if(nWho == 0)       picPos9.sprite = batu;
            else if(nWho == 1)  picPos9.sprite = maru;
            picPos9.color = new Color(255, 255, 255, 255);
            s [2, 2] = nWho;
            WinCheck();
        }
    }
    
    // 输赢判定的入口
    // 每次下棋子后都会被调用
    // 因此，这一代码块为游戏程序的主要瓶颈，可以优化
    void WinCheck()
    {
        // 一大块 if 是瓶颈的关键
        for(uint i = 0; i < 3; ++i)
            if(s [i, 0] == 0 && s [i, 1] == 0 && s [i, 2] == 0) win = 0;
        for(uint i = 0; i < 3; ++i)
            if(s [i, 0] == 1 && s [i, 1] == 1 && s [i, 2] == 1) win = 1;
        for(uint i = 0; i < 3; ++i)
            if(s [0, i] == 0 && s [1, i] == 0 && s [2, i] == 0) win = 0;
        for(uint i = 0; i < 3; ++i)
            if(s [0, i] == 1 && s [1, i] == 1 && s [2, i] == 1) win = 1;

        if(s [0, 0] == 0 && s [1, 1] == 0 && s [2, 2] == 0) win = 0;
        if(s [0, 0] == 1 && s [1, 1] == 1 && s [2, 2] == 1) win = 1;

        if(s [0, 2] == 0 && s [1, 1] == 0 && s [2, 0] == 0) win = 0;
        if(s [0, 2] == 1 && s [1, 1] == 1 && s [2, 0] == 1) win = 1;

        if(s [0, 0] != -1 && s [0, 1] != -1 && s [0, 2] != -1
            && s [1, 0] != -1 && s [1, 1] != -1 && s [1, 2] != -1
            && s [2, 0] != -1 && s [2, 1] != -1 && s [2, 2] != -1)
            win = -2;

        // 根据输赢状态进入不同的改变接口
        if(win == -1) ControlExchanger();   // -1 未定
        else if(win == 0) {   
            imgWin.sprite = batu;
            Win();
        }// 0 叉 获胜
        else if(win == 1) { 
            imgWin.sprite = maru;
            Win();
        }// 1 圆 获胜
        else if(win == -2) Lose();  // -2 无人获胜
    }

    // 以下两个只控制显示和操作权限的变化
    void Win() {
        imgWin.color = new Color(255, 255, 255, 255);
        txtWin.color = new Color(255, 62, 62, 255);
        txtLose.color = new Color(255, 0, 255, 0);
        imgWho.color = new Color(255, 255, 255, 0);
        txtWho.color = new Color(255, 255, 255, 0);
        ButtonTransEnd();
    }

    void Lose() {
        imgWho.color = new Color(255, 255, 255, 0);
        txtWho.color = new Color(255, 255, 255, 0);
        txtLose.color = new Color(255, 0, 255, 255);
        imgWho.color = new Color(255, 255, 255, 0);
        txtWho.color = new Color(255, 255, 255, 0);
        ButtonTransEnd();
    }

    // 启动的按钮可用性调整
    void ButtonTransStart() {
        btnRST.transform.Translate(new Vector3(500, 0, 0), Space.Self);
        btnRST.interactable = false;
        btnPos1.interactable = true;    btnPos2.interactable = true;    btnPos3.interactable = true;
        btnPos4.interactable = true;    btnPos5.interactable = true;    btnPos6.interactable = true;
        btnPos7.interactable = true;    btnPos8.interactable = true;    btnPos9.interactable = true;
    }

    // 结束的按钮可用性调整
    void ButtonTransEnd() {
        btnRST.transform.Translate(new Vector3(-500, 0, 0), Space.Self);
        btnRST.interactable = true;
        btnPos1.interactable = false;   btnPos2.interactable = false;   btnPos3.interactable = false;
        btnPos4.interactable = false;   btnPos5.interactable = false;   btnPos6.interactable = false;
        btnPos7.interactable = false;   btnPos8.interactable = false;   btnPos9.interactable = false;
    }

    // 每开始新的一局时重置棋盘显示
    // 保存棋盘的矩阵的重置在 Initialization() 中完成
    void PicPosReset() {
        picPos1.sprite = null;  picPos1.color = new Color(255, 255, 255, 0);
        picPos2.sprite = null;  picPos2.color = new Color(255, 255, 255, 0);
        picPos3.sprite = null;  picPos3.color = new Color(255, 255, 255, 0);
        picPos4.sprite = null;  picPos4.color = new Color(255, 255, 255, 0);
        picPos5.sprite = null;  picPos5.color = new Color(255, 255, 255, 0);
        picPos6.sprite = null;  picPos6.color = new Color(255, 255, 255, 0);
        picPos7.sprite = null;  picPos7.color = new Color(255, 255, 255, 0);
        picPos8.sprite = null;  picPos8.color = new Color(255, 255, 255, 0);
        picPos9.sprite = null;  picPos9.color = new Color(255, 255, 255, 0);
    }

    // 每次下棋后交换控制
    void ControlExchanger() {
        if(nWho == 0)       nWho = 1;
        else if(nWho == 1)  nWho = 0;
        ControllerUpdate();
    }

    // 对控制权交换的图像表示作更新
    void ControllerUpdate() {
		switch(nWho) {
            case 0:imgWho.sprite = batu; break;
            case 1:imgWho.sprite = maru; break;
		}
    }
}
