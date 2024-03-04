using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public enum Rarity
    {
        Normal,
        Rare,
        Unique
    }
    public Rarity rarity;
    public int id;
    public SkillData skillData;
    public Sprite skillIcon;

    public virtual void DoSkill() {
        if(skillData.overlap == 0)
        {
            Managers.Game.skillIndex.Remove(skillData.index);
        }
        Time.timeScale = Managers.Game.GameSpeed;
    }

    public void Init(int index)
    {
        id = index;
        skillData = Managers.Data.SkillData[index];
    }
}
