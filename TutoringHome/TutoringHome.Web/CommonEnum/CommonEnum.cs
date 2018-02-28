using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringHome.Web.CommonEnum
{
    public enum SubjectEnum
    {
        [SelectDisplayName("语文")]
        Chinese = 1,
        [SelectDisplayName("数学")]
        Maths = 2,
        [SelectDisplayName("外语")]
        English = 3,
        [SelectDisplayName("物理")]
        Physics = 4,
        [SelectDisplayName("化学")]
        Chemistry = 5,
        [SelectDisplayName("政治")]
        Politics = 6,
        [SelectDisplayName("历史")]
        History = 7,
        [SelectDisplayName("地理")]
        Geography = 8,
        [SelectDisplayName("生物")]
        Biology = 9,
        [SelectDisplayName("音乐")]
        Music = 10,
        [SelectDisplayName("形体")]
        Form = 11,//形体
        [SelectDisplayName("书法")]
        Calligraphy = 12,//书法
        [SelectDisplayName("美术")]
        Arts = 13,//美术
        [SelectDisplayName("科学")]
        Science = 14,//科学
        [SelectDisplayName("体育")]
        PE = 15//体育
    }
    public enum SexEnum
    {
        [SelectDisplayName("男")]
        Male = 1,
        [SelectDisplayName("女")]
        Female = 2
    }

    public enum ClassNameEnum
    {
        [SelectDisplayName("一年级")]
        Class1 = 1,
        [SelectDisplayName("二年级")]
        Class2 = 2,
        [SelectDisplayName("三年级")]
        Class3 = 3,
        [SelectDisplayName("四年级")]
        Class4 = 4,
        [SelectDisplayName("五年级")]
        Class5 = 5,
        [SelectDisplayName("六年级")]
        Class6 = 6,
        [SelectDisplayName("七年级")]
        Class7 = 7,
        [SelectDisplayName("八年级")]
        Class8 = 8,
        [SelectDisplayName("九年级")]
        Class9 = 9,
        [SelectDisplayName("高一")]
        Class10 = 10,
        [SelectDisplayName("高二")]
        Class11 = 11,
        [SelectDisplayName("高三")]
        Class12 = 12
    }
}