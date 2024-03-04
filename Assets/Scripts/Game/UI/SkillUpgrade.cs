using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour
{
    [SerializeField] private Skill[] skills = new Skill[3];
    [SerializeField] private bool hideOn = false;

    public void GetSkill()
    {
        int childCound = transform.childCount;
        for (int i = 0; i < childCound; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ChangeSkills()  //���ΰ�ħ ��ư�� ������ ��ų ���� ��ü
    {
        List<int> indexList = new List<int>();
        indexList.AddRange(Managers.Game.skillIndex);
        //SkillManager���� �������� 3�� ��ų skills�迭�� ��������
        for(int i = 0; i < skills.Length; i++)
        {
            int random = UnityEngine.Random.Range(0, indexList.Count);
            int index = indexList[random];
            skills[i] = Managers.Skill.SkillDictionary[index];
            indexList.Remove(index);
        }
        //skills �迭�� �ִ� ��ų�� ������� ��ų ��ư�� �Ҵ��ؾߵ�
        int skillCount = skills.Length;
        for (int i = 0; i < skillCount; i++)
        {
            Transform skillButton = transform.GetChild(1).GetChild(i);
            skillButton.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/SkillIcons/{skills[i].skillData.skillUser}");
            skillButton.GetChild(1).GetComponent<Text>().text = skills[i].skillData.skillInfo;

            skillButton.GetComponent<Button>().onClick.RemoveAllListeners();
            skillButton.GetComponent<Button>().onClick.AddListener(skills[i].DoSkill);
        }
    }

    public void HideUI()    //UI����� ��ư�� ������ ��ų ���� UI�� ������ �ʵ� Ȯ�� ����
    {
        if(hideOn == false)
        {
            hideOn = true;
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            hideOn = false;
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
