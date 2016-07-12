﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1_Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day1_Homework.Models;

namespace Day1_Homework.Tests
{
    [TestClass()]
    public class ProductSumCalculatorTests
    {
        #region MySelf version
        //[TestMethod()]
        //public void Test_Pagesize_is_3_Sum_by_Cost_Result_Should_Be_6_15_24_21()
        //{
        //    //此範例是 PageSize 的意思

        //    //arrange
        //    var target = new ProductSumCalculator();

        //    //act
        //    var products = GetProducts();
        //    var actual = target.ProductSumCalculate(products, "Cost", 3);

        //    //assert
        //    var expected = new List<int> { 6, 15, 24, 21 };

        //    CollectionAssert.AreEqual(expected, actual);

        //}

        //[TestMethod()]
        //public void Test_Pagesize_is_4_Sum_by_Revenue_Result_Should_Be_50_66_60()
        //{
        //    //arrange
        //    var target = new ProductSumCalculator();

        //    //act
        //    var actual = target.ProductSumCalculate(GetProducts(), "Revenue", 4);

        //    //assert
        //    var expected = new List<int> { 50, 66, 60 };

        //    CollectionAssert.AreEqual(expected, actual);

        //}


        //public List<Product> GetProducts()
        //{
        //    var products = new List<Product>
        //    {
        //        new Product { Id=1,  Cost=1,  Revenue=11, SellPrice=21},
        //        new Product { Id=2,  Cost=2,  Revenue=12, SellPrice=22},
        //        new Product { Id=3,  Cost=3,  Revenue=13, SellPrice=23},
        //        new Product { Id=4,  Cost=4,  Revenue=14, SellPrice=24},
        //        new Product { Id=5,  Cost=5,  Revenue=15, SellPrice=25},
        //        new Product { Id=6,  Cost=6,  Revenue=16, SellPrice=26},
        //        new Product { Id=7,  Cost=7,  Revenue=17, SellPrice=27},
        //        new Product { Id=8,  Cost=8,  Revenue=18, SellPrice=28},
        //        new Product { Id=9,  Cost=9,  Revenue=19, SellPrice=29},
        //        new Product { Id=10, Cost=10, Revenue=20, SellPrice=30},
        //        new Product { Id=11, Cost=11, Revenue=21, SellPrice=31},
        //    };
        //    return products;
        //}

        #endregion


        #region Teacher version

        [TestMethod()]
        public void Test_Pagesize_is_3_Sum_by_Cost_Result_Should_Be_6_15_24_21()
        {
            //target 
            var target = new ProductsInfo();

            //act 
            var actual = target.GetSum(3, x => x.Cost).ToList();

            //assert
            var expected = new List<int> { 6, 15, 24, 21 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_Pagesize_is_4_Sum_by_Revenue_Result_Should_Be_50_66_60()
        {
            //arrange
            var target = new ProductsInfo();

            //act
            var actual = target.GetSum(4, x => x.Revenue).ToList();

            //assert
            var expected = new List<int> { 50, 66, 60 };

            CollectionAssert.AreEqual(expected, actual);
        }

        public class ProductsInfo
        {
            public IEnumerable<int> GetSum(int pagesize, Func<Product, int> selector)
            {
                //Func<TSource,TResult>

                var products = GetProducts().ToList();

                var index = 0;
                while (index <= pagesize)
                {
                    //Skip + Take 可以做分頁
                    yield return products.Skip(index).Take(pagesize).Sum(selector);
                    index += pagesize;
                }
            }

            public IEnumerable<Product> GetProducts()
            {
                var products = new List<Product>()
                {
                    new Product() { Id=1 ,Cost=1 ,Revenue=11,SellPrice=21 },
                    new Product() { Id=2 ,Cost=2 ,Revenue=12,SellPrice=22 },
                    new Product() { Id=3 ,Cost=3 ,Revenue=13,SellPrice=23 },
                    new Product() { Id=4 ,Cost=4 ,Revenue=14,SellPrice=24 },
                    new Product() { Id=5 ,Cost=5 ,Revenue=15,SellPrice=25 },
                    new Product() { Id=6 ,Cost=6 ,Revenue=16,SellPrice=26 },
                    new Product() { Id=7 ,Cost=7 ,Revenue=17,SellPrice=27 },
                    new Product() { Id=8 ,Cost=8 ,Revenue=18,SellPrice=28 },
                    new Product() { Id=9 ,Cost=9 ,Revenue=19,SellPrice=29 },
                    new Product() { Id=10,Cost=10,Revenue=20,SellPrice=30 },
                    new Product() { Id=11,Cost=11,Revenue=21,SellPrice=31 }
                };
                return products;
            }

        #endregion 
    }
}