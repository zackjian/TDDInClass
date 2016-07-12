using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    //任何型別的集合
    public class ProductSumCalculatorTests_v2
    {
        [TestMethod]
        public void Test_Pagesize_is_3_Sum_by_Cost_Should_Be_6_15_24_21()
        {
            //arrange
            var products = GetProducts();

            //act
            var actual = products.GetSum(3, x => x.Cost).ToList();

            //assert
            var expected = new List<int> { 6, 15, 24, 21 };

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Test_Pagesize_is_4_Sum_by_Revenue_Should_Be_50_66_60()
        {
            //arrange
            var target = GetProducts();

            //act
            var actual = target.GetSum(4, x => x.Revenue).ToList();

            //assert
            var expected = new List<int> { 50, 66, 60 };

            CollectionAssert.AreEqual(expected, actual);

        }

        private IEnumerable<Product> GetProducts()
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
        
    }


    public static class EnumerableExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageSize"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetSum<TSource>(this IEnumerable<TSource> source, int pageSize, Func<TSource, int> selector)
        {
            var index = 0;
            while (index <= source.Count())
            {
                yield return source.Skip(index).Take(pageSize).Sum(selector);
                index += pageSize;
            }
        }
    }

}