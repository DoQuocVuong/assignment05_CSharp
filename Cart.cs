using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleApplication2.Properties;

namespace ConsoleApplication2
{
    public delegate void Notification(string s);
    public class Cart
    {
        public int id;
        public int customer;
        public int grandtotal;
        public List<Products> ProductList;
        public string city;
        public string country;


        public event Notification NotifyWhenAddProduct;
        
        public static void ShowNotification(string s)
        {
            Console.WriteLine(s);
        }
        public bool AddToCart(Products p)
        {
            if (ProductList.Contains(p) && p.CheckQty())
            {
                if (NotifyWhenAddProduct==null)
                {
                    NotifyWhenAddProduct += ShowNotification;
                }
                ProductList.Add(p);
                p.qty--;
                grandtotal += p.price;
                NotifyWhenAddProduct("Sản phẩm đã thêm vào giỏ hàng.");
                return true;
            }
            Console.WriteLine("In cart.");
            return false;
        }
        public bool DeleteFromCart(Products p)
        {
            if (ProductList.Contains(p))
            {
                ProductList.Remove(p);
                p.qty++;
                grandtotal -= p.price;
                return true;
            }
            Console.WriteLine("Product has been removed");
            return false;
        }

        public decimal GetGrandTotal()
        {
            decimal finalTotal = 0;
            if (country == "VN")
            {
                if (city == "HN" || city == "HCM")
                {
                    finalTotal = grandtotal * (decimal) 1.01;
                }
                else
                {
                    finalTotal = grandtotal * (decimal) 1.02;
                }
            }
            else
            {
                finalTotal = grandtotal * (decimal) 1.05;
            }

            return finalTotal;
        }

        public static void ShowNotification()
        {
            throw new NotImplementedException();
        }
    }
}