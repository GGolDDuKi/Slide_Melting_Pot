using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class SkillManager : MonoBehaviour
{
    //���⼭ ���ֺ� ��ų �ε����� DoSkill�� ��ų ���
    private Dictionary<int, Skill> skillDictionary = new Dictionary<int, Skill>();
    public Dictionary<int, Skill> SkillDictionary { get { return skillDictionary; } }

    public void Init()
    {
        SetSkillList();
    }

    void SetSkillList()
    {
        foreach(SkillData skill in Managers.Data.SkillData.Values)
        {
            Type type = Type.GetType(skill.skillName);
            Skill newSkill = (Skill)Activator.CreateInstance(type);
            newSkill.skillData = skill;
            skillDictionary.Add(newSkill.skillData.index, newSkill);
        }
    }
}
