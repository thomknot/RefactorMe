using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Utility
{
    public static class CompareList
    {
        public static bool ComparingList(List<Product> actual, List<Product> expected)
        {
            bool isEqual = false; ;
            if (actual.Count == expected.Count)
            {
                for (int i = 0; i <= actual.Count - 1; i++)
                {
                    if (actual[i].Id == expected[i].Id && actual[i].Name == expected[i].Name &&  actual[i].Price == expected[i].Price && actual[i].Type == expected[i].Type)
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
            }

            return isEqual;
        }
    }
}
