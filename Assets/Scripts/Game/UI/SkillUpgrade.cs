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

    public void ChangeSkills()  //새로고침 버튼을 누르면 스킬 랜덤 교체
    {
        List<int> indexList = new List<int>();
        indexList.AddRange(Managers.Game.skillIndex);
        //SkillManager에서 랜덤으로 3개 스킬 skills배열로 가져오고
        for(int i = 0; i < skills.Length; i++)
        {
            int random = UnityEngine.Random.Range(0, indexList.Count);
            int index = indexList[random];
            skills[i] = Managers.Skill.SkillDictionary[index];
            indexList.Remove(index);
        }
        //skills 배열에 있는 스킬들 순서대로 스킬 버튼에 할당해야됨
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

    public void HideUI()    //UI숨기기 버튼을 누르면 스킬 설명 UI가 숨겨져 필드 확인 가능
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
