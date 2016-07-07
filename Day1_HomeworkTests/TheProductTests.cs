using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1_Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day1_Homework.Services;
using Day1_Homework.Models;

namespace Day1_Homework.Tests
{
    [TestClass()]
    public class TheProductTests
    {
        List<Product> products = new ProductService().GetProducts();

        [TestMethod()]
        public void ProcessSum_Cost_Three_Items_One_Group_Result_6_15_24_21()
        {
            //arrange
            var target = new TheProduct();

            //act
            var actual = target.ProcessSum(products, "Cost", 3);

            //assert
            var expected = new int[] { 6, 15, 24, 21 };

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void ProcessSum_Revenue_Four_Items_One_Group_Result_50_66_60()
        {
            //arrange
            var target = new TheProduct();

            //act
            var actual = target.ProcessSum(products, "Revenue", 4);

            //assert
            var expected = new int[] { 50, 66, 60 };

            CollectionAssert.AreEqual(expected, actual);

        }




    }
}