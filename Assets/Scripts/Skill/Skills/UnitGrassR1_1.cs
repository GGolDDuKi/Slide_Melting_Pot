using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //���þƸ��� ���Ϳ��� ������ ���� �̻����� �߻��Ͽ� �� 500% �������� �����ϴ�. ���� �߻��ϸ�, 3�� ���� ���� ��� �ٽ� �߻��� �� �ֽ��ϴ�.
        unLock = true;
        base.DoSkill();
    }
}
