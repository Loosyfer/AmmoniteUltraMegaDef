using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MemberExcel", menuName = "My Game/Member Excel")]
public class MemberExcel : ScriptableObject
{
    private TextAsset textAssetData;

    [System.Serializable]
    public class Member
    {
        public string trait;
        public string tEffect;
        public bool positive;
        public bool exclusive;
        public bool erudite;
        public bool super;
        public int price;
    }

    [System.Serializable]
    public class MemberList
    {
        public Member[] members;
    }

    public MemberList myMembers = new MemberList();

}