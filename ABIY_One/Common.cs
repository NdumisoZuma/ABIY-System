using ABIY_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABIY_One
{
    public class Common
    {
        public List<Answer>GetAnswers()
        {
            List<Answer> list = new List<Answer>();
            list.Add(new Answer() { Ans_ID = 4, Name = "Excellent", Css = "check w3" });
            list.Add(new Answer() { Ans_ID = 3, Name = "Good", Css = "check w3ls" });
            list.Add(new Answer() { Ans_ID = 2, Name = "Neutral", Css = "check wthree" });
            list.Add(new Answer() { Ans_ID = 1, Name = "Poor", Css = "check w3_agileits" });
            return list;
        }
    }
}