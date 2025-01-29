using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����״̬����Ĳ���
public class FSM_Parameter
{
    public Estate currentEState;
}


public class FSM
{

    //״̬��ö�ٺ;���״̬�������
    public Dictionary<Estate, BaseState> StateDict;


    //ÿ��״̬����Ĳ���
    public FSM_Parameter parameter;

    //��ǰ״̬
    public BaseState currentState;


    public FSM(FSM_Parameter P)
    {

        parameter = P;
        StateDict = new Dictionary<Estate, BaseState>();
    }



    //���״̬
    public void AddState(Estate estate, BaseState baseState)
    {
        if (!StateDict.ContainsKey(estate))
        {
            StateDict.Add(estate, baseState);
        }
    }


    //�л�״̬
    public void SwitchState(Estate estate)
    {

        //Ŀ��״̬�Ƿ��ѱ����
        if (!StateDict.ContainsKey(estate))
        {
            return;
        }

        //�˳���ǰ״̬
        if (currentState != null)
        {
            currentState.OnExit();
        }

        //�л�״̬
        currentState = StateDict[estate];
        parameter.currentEState = estate;


        currentState?.OnEnter();

    }

    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }

}

