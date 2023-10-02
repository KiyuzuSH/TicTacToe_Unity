using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    // Բ���ľ���
    public Sprite maru;     public Sprite batu;
    // �Ź����ͼ��
    public Image picPos1;   public Image picPos2;   public Image picPos3;
    public Image picPos4;   public Image picPos5;   public Image picPos6;
    public Image picPos7;   public Image picPos8;   public Image picPos9;
    // �Ź���İ�ť
    public Button btnPos1;  public Button btnPos2;  public Button btnPos3;
    public Button btnPos4;  public Button btnPos5;  public Button btnPos6;
    public Button btnPos7;  public Button btnPos8;  public Button btnPos9;
    // ��Ӯ�����ָʾ������
    public Image imgWin;    public Text txtWin;
    public Image imgWho;    public Text txtWho;
    public Button btnRST;
    public Text txtLose;
    // ����˭����
    private int nWho;  // batu = 0; maru = 1;
    // �ڲ��������̵�״̬
    private int [,] s;
    // ��ֵ���Ӯ״̬
    private int win;

    void Start() { Initialization(); }

    // ��ʼ��
    public void Initialization() {
        nWho = 0;
        win = -1;
        s = new int [3, 3] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };  // ������ÿ���������̴洢�����λ��
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

    // ��1����9����ť�ĸ�����Ӧ
    public void btn1() {
        if(picPos1.sprite != null)  return; // �ж�Ϊ�ǿ�
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
    
    // ��Ӯ�ж������
    // ÿ�������Ӻ󶼻ᱻ����
    // ��ˣ���һ�����Ϊ��Ϸ�������Ҫƿ���������Ż�
    void WinCheck()
    {
        // һ��� if ��ƿ���Ĺؼ�
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

        // ������Ӯ״̬���벻ͬ�ĸı�ӿ�
        if(win == -1) ControlExchanger();   // -1 δ��
        else if(win == 0) {   
            imgWin.sprite = batu;
            Win();
        }// 0 �� ��ʤ
        else if(win == 1) { 
            imgWin.sprite = maru;
            Win();
        }// 1 Բ ��ʤ
        else if(win == -2) Lose();  // -2 ���˻�ʤ
    }

    // ��������ֻ������ʾ�Ͳ���Ȩ�޵ı仯
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

    // �����İ�ť�����Ե���
    void ButtonTransStart() {
        btnRST.transform.Translate(new Vector3(500, 0, 0), Space.Self);
        btnRST.interactable = false;
        btnPos1.interactable = true;    btnPos2.interactable = true;    btnPos3.interactable = true;
        btnPos4.interactable = true;    btnPos5.interactable = true;    btnPos6.interactable = true;
        btnPos7.interactable = true;    btnPos8.interactable = true;    btnPos9.interactable = true;
    }

    // �����İ�ť�����Ե���
    void ButtonTransEnd() {
        btnRST.transform.Translate(new Vector3(-500, 0, 0), Space.Self);
        btnRST.interactable = true;
        btnPos1.interactable = false;   btnPos2.interactable = false;   btnPos3.interactable = false;
        btnPos4.interactable = false;   btnPos5.interactable = false;   btnPos6.interactable = false;
        btnPos7.interactable = false;   btnPos8.interactable = false;   btnPos9.interactable = false;
    }

    // ÿ��ʼ�µ�һ��ʱ����������ʾ
    // �������̵ľ���������� Initialization() �����
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

    // ÿ������󽻻�����
    void ControlExchanger() {
        if(nWho == 0)       nWho = 1;
        else if(nWho == 1)  nWho = 0;
        ControllerUpdate();
    }

    // �Կ���Ȩ������ͼ���ʾ������
    void ControllerUpdate() {
		switch(nWho) {
            case 0:imgWho.sprite = batu; break;
            case 1:imgWho.sprite = maru; break;
		}
    }
}
