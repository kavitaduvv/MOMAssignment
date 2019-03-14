using Newtonsoft.Json;
using MOMAssignment.Constants;
using MOMAssignment.RequestHandlers;
using MOMAssignment.Model;
using System;
using System.Net;

namespace MOMAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "";
            string m = "";
            string y = "";
            DateTime a = new DateTime();
            DateTime b = new DateTime();
            decimal avg_banks = 0;
            decimal avg_fc = 0;
            Console.WriteLine("Input Range Date in the Format mmm-yyyy. Range 1");
            try
            {
                a = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {

                Console.WriteLine("Improper Date Format. Please enter valid date format as specified mm-yyyy  " + ex.Message.ToString());
                Console.ReadLine();
            }

            Console.WriteLine("Input Range Date in the Format mmm-yyyy. Range 2");
            try
            {
                b = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex1)
            {

                Console.WriteLine("Improper Date Format. Please enter valid date format as specified mm-yyyy  " + ex1.Message.ToString());
                Console.ReadLine();
            }

            if (a >= b)
            {
                Console.WriteLine("***********-- Range 1 Date must be less than Range 2--************");
                Console.WriteLine("Input Range Date in the Format mmm-yyyy. Range 1");
                try
                {
                    a = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Improper Date Format. Please enter valid date format as specified mm-yyyy  " + ex.Message.ToString());
                    Console.ReadLine();
                }

                Console.WriteLine("Input Range Date in the Format mmm-yyyy. Range 2");
                try
                {
                    b = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception ex1)
                {

                    Console.WriteLine("Improper Date Format. Please enter valid date format as specified mm-yyyy  " + ex1.Message.ToString());
                    Console.ReadLine();
                }

            }
            //These are the ways to consume RESTful APIs as described in the blog post
            IRequestHandler httpWebRequestHandler = new HttpWebRequestHandler();

            var response = GetData(httpWebRequestHandler);

            string json = @"{'records':[{'end_of_month':'1983-01','prime_lending_rate':'9.53','banks_fixed_deposits_3m':'6.75','banks_fixed_deposits_6m':'6.80','banks_fixed_deposits_12m':'7.13','banks_savings_deposits':'6.50','fc_hire_purchase_motor_3y':'12.67','fc_housing_loans_15y':'12.42','fc_fixed_deposits_3m':'7.15','fc_fixed_deposits_6m':'7.30','fc_fixed_deposits_12m':'7.70','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1983-02','prime_lending_rate':'9.25','banks_fixed_deposits_3m':'6.40','banks_fixed_deposits_6m':'6.70','banks_fixed_deposits_12m':'6.93','banks_savings_deposits':'6.40','fc_hire_purchase_motor_3y':'12.58','fc_housing_loans_15y':'12.21','fc_fixed_deposits_3m':'6.70','fc_fixed_deposits_6m':'7.03','fc_fixed_deposits_12m':'7.33','fc_savings_deposits':'7.08','timestamp':'1552565664'},{'end_of_month':'1983-03','prime_lending_rate':'9.10','banks_fixed_deposits_3m':'6.18','banks_fixed_deposits_6m':'6.48','banks_fixed_deposits_12m':'6.83','banks_savings_deposits':'6.30','fc_hire_purchase_motor_3y':'12.36','fc_housing_loans_15y':'11.97','fc_fixed_deposits_3m':'6.48','fc_fixed_deposits_6m':'6.78','fc_fixed_deposits_12m':'7.18','fc_savings_deposits':'7.00','timestamp':'1552565664'},{'end_of_month':'1983-04','prime_lending_rate':'9.03','banks_fixed_deposits_3m':'6.10','banks_fixed_deposits_6m':'6.35','banks_fixed_deposits_12m':'6.73','banks_savings_deposits':'6.15','fc_hire_purchase_motor_3y':'12.19','fc_housing_loans_15y':'11.92','fc_fixed_deposits_3m':'6.38','fc_fixed_deposits_6m':'6.65','fc_fixed_deposits_12m':'7.13','fc_savings_deposits':'7.00','timestamp':'1552565664'},{'end_of_month':'1983-05','prime_lending_rate':'9.03','banks_fixed_deposits_3m':'6.10','banks_fixed_deposits_6m':'6.35','banks_fixed_deposits_12m':'6.73','banks_savings_deposits':'6.13','fc_hire_purchase_motor_3y':'12.14','fc_housing_loans_15y':'11.84','fc_fixed_deposits_3m':'6.50','fc_fixed_deposits_6m':'6.75','fc_fixed_deposits_12m':'7.18','fc_savings_deposits':'7.00','timestamp':'1552565664'},{'end_of_month':'1983-06','prime_lending_rate':'8.88','banks_fixed_deposits_3m':'6.05','banks_fixed_deposits_6m':'6.30','banks_fixed_deposits_12m':'6.63','banks_savings_deposits':'6.08','fc_hire_purchase_motor_3y':'12.00','fc_housing_loans_15y':'11.57','fc_fixed_deposits_3m':'6.50','fc_fixed_deposits_6m':'6.75','fc_fixed_deposits_12m':'7.15','fc_savings_deposits':'7.00','timestamp':'1552565664'},{'end_of_month':'1983-07','prime_lending_rate':'9.00','banks_fixed_deposits_3m':'6.18','banks_fixed_deposits_6m':'6.40','banks_fixed_deposits_12m':'6.65','banks_savings_deposits':'6.13','fc_hire_purchase_motor_3y':'12.00','fc_housing_loans_15y':'11.38','fc_fixed_deposits_3m':'6.70','fc_fixed_deposits_6m':'6.95','fc_fixed_deposits_12m':'7.25','fc_savings_deposits':'7.00','timestamp':'1552565664'},{'end_of_month':'1983-08','prime_lending_rate':'9.00','banks_fixed_deposits_3m':'6.30','banks_fixed_deposits_6m':'6.48','banks_fixed_deposits_12m':'6.73','banks_savings_deposits':'6.23','fc_hire_purchase_motor_3y':'12.00','fc_housing_loans_15y':'11.26','fc_fixed_deposits_3m':'6.75','fc_fixed_deposits_6m':'6.98','fc_fixed_deposits_12m':'7.28','fc_savings_deposits':'7.00','timestamp':'1552565664'},{'end_of_month':'1983-09','prime_lending_rate':'8.95','banks_fixed_deposits_3m':'6.38','banks_fixed_deposits_6m':'6.50','banks_fixed_deposits_12m':'6.73','banks_savings_deposits':'6.23','fc_hire_purchase_motor_3y':'11.91','fc_housing_loans_15y':'10.92','fc_fixed_deposits_3m':'6.75','fc_fixed_deposits_6m':'7.00','fc_fixed_deposits_12m':'7.33','fc_savings_deposits':'7.17','timestamp':'1552565664'},{'end_of_month':'1983-10','prime_lending_rate':'8.93','banks_fixed_deposits_3m':'6.35','banks_fixed_deposits_6m':'6.48','banks_fixed_deposits_12m':'6.70','banks_savings_deposits':'6.20','fc_hire_purchase_motor_3y':'11.65','fc_housing_loans_15y':'10.74','fc_fixed_deposits_3m':'6.78','fc_fixed_deposits_6m':'7.00','fc_fixed_deposits_12m':'7.30','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1983-11','prime_lending_rate':'8.93','banks_fixed_deposits_3m':'6.45','banks_fixed_deposits_6m':'6.48','banks_fixed_deposits_12m':'6.70','banks_savings_deposits':'6.20','fc_hire_purchase_motor_3y':'11.51','fc_housing_loans_15y':'10.58','fc_fixed_deposits_3m':'6.80','fc_fixed_deposits_6m':'7.00','fc_fixed_deposits_12m':'7.33','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1983-12','prime_lending_rate':'8.98','banks_fixed_deposits_3m':'6.53','banks_fixed_deposits_6m':'6.55','banks_fixed_deposits_12m':'6.75','banks_savings_deposits':'6.30','fc_hire_purchase_motor_3y':'11.38','fc_housing_loans_15y':'10.56','fc_fixed_deposits_3m':'6.90','fc_fixed_deposits_6m':'7.08','fc_fixed_deposits_12m':'7.38','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1984-01','prime_lending_rate':'9.05','banks_fixed_deposits_3m':'6.63','banks_fixed_deposits_6m':'6.63','banks_fixed_deposits_12m':'6.83','banks_savings_deposits':'6.38','fc_hire_purchase_motor_3y':'11.38','fc_housing_loans_15y':'10.46','fc_fixed_deposits_3m':'7.03','fc_fixed_deposits_6m':'7.18','fc_fixed_deposits_12m':'7.43','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1984-02','prime_lending_rate':'9.00','banks_fixed_deposits_3m':'6.63','banks_fixed_deposits_6m':'6.60','banks_fixed_deposits_12m':'6.80','banks_savings_deposits':'6.38','fc_hire_purchase_motor_3y':'11.30','fc_housing_loans_15y':'10.46','fc_fixed_deposits_3m':'7.03','fc_fixed_deposits_6m':'7.18','fc_fixed_deposits_12m':'7.43','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1984-03','prime_lending_rate':'9.20','banks_fixed_deposits_3m':'6.78','banks_fixed_deposits_6m':'6.75','banks_fixed_deposits_12m':'6.95','banks_savings_deposits':'6.48','fc_hire_purchase_motor_3y':'11.30','fc_housing_loans_15y':'10.43','fc_fixed_deposits_3m':'7.10','fc_fixed_deposits_6m':'7.20','fc_fixed_deposits_12m':'7.45','fc_savings_deposits':'7.21','timestamp':'1552565664'},{'end_of_month':'1984-04','prime_lending_rate':'9.63','banks_fixed_deposits_3m':'7.18','banks_fixed_deposits_6m':'7.13','banks_fixed_deposits_12m':'7.18','banks_savings_deposits':'6.96','fc_hire_purchase_motor_3y':'11.34','fc_housing_loans_15y':'10.53','fc_fixed_deposits_3m':'7.48','fc_fixed_deposits_6m':'7.50','fc_fixed_deposits_12m':'7.73','fc_savings_deposits':'7.33','timestamp':'1552565664'},{'end_of_month':'1984-05','prime_lending_rate':'9.98','banks_fixed_deposits_3m':'7.35','banks_fixed_deposits_6m':'7.33','banks_fixed_deposits_12m':'7.35','banks_savings_deposits':'7.16','fc_hire_purchase_motor_3y':'11.38','fc_housing_loans_15y':'10.63','fc_fixed_deposits_3m':'7.68','fc_fixed_deposits_6m':'7.70','fc_fixed_deposits_12m':'7.88','fc_savings_deposits':'7.46','timestamp':'1552565664'},{'end_of_month':'1984-06','prime_lending_rate':'10.08','banks_fixed_deposits_3m':'7.35','banks_fixed_deposits_6m':'7.33','banks_fixed_deposits_12m':'7.35','banks_savings_deposits':'7.26','fc_hire_purchase_motor_3y':'11.47','fc_housing_loans_15y':'10.76','fc_fixed_deposits_3m':'7.73','fc_fixed_deposits_6m':'7.75','fc_fixed_deposits_12m':'7.93','fc_savings_deposits':'7.57','timestamp':'1552565664'},{'end_of_month':'1984-07','prime_lending_rate':'10.10','banks_fixed_deposits_3m':'7.35','banks_fixed_deposits_6m':'7.33','banks_fixed_deposits_12m':'7.35','banks_savings_deposits':'7.26','fc_hire_purchase_motor_3y':'11.52','fc_housing_loans_15y':'10.84','fc_fixed_deposits_3m':'7.90','fc_fixed_deposits_6m':'7.90','fc_fixed_deposits_12m':'8.08','fc_savings_deposits':'7.79','timestamp':'1552565664'},{'end_of_month':'1984-08','prime_lending_rate':'10.10','banks_fixed_deposits_3m':'7.35','banks_fixed_deposits_6m':'7.33','banks_fixed_deposits_12m':'7.35','banks_savings_deposits':'7.26','fc_hire_purchase_motor_3y':'11.61','fc_housing_loans_15y':'10.89','fc_fixed_deposits_3m':'7.95','fc_fixed_deposits_6m':'8.00','fc_fixed_deposits_12m':'8.15','fc_savings_deposits':'7.82','timestamp':'1552565664'},{'end_of_month':'1984-09','prime_lending_rate':'10.33','banks_fixed_deposits_3m':'7.58','banks_fixed_deposits_6m':'7.60','banks_fixed_deposits_12m':'7.58','banks_savings_deposits':'7.49','fc_hire_purchase_motor_3y':'11.70','fc_housing_loans_15y':'10.91','fc_fixed_deposits_3m':'8.05','fc_fixed_deposits_6m':'8.15','fc_fixed_deposits_12m':'8.23','fc_savings_deposits':'7.86','timestamp':'1552565664'},{'end_of_month':'1984-10','prime_lending_rate':'10.08','banks_fixed_deposits_3m':'7.10','banks_fixed_deposits_6m':'7.28','banks_fixed_deposits_12m':'7.43','banks_savings_deposits':'7.14','fc_hire_purchase_motor_3y':'11.70','fc_housing_loans_15y':'10.91','fc_fixed_deposits_3m':'7.64','fc_fixed_deposits_6m':'7.85','fc_fixed_deposits_12m':'8.00','fc_savings_deposits':'7.61','timestamp':'1552565664'},{'end_of_month':'1984-11','prime_lending_rate':'9.68','banks_fixed_deposits_3m':'6.40','banks_fixed_deposits_6m':'6.65','banks_fixed_deposits_12m':'6.98','banks_savings_deposits':'6.78','fc_hire_purchase_motor_3y':'11.64','fc_housing_loans_15y':'10.86','fc_fixed_deposits_3m':'6.85','fc_fixed_deposits_6m':'7.10','fc_fixed_deposits_12m':'7.38','fc_savings_deposits':'7.04','timestamp':'1552565664'},{'end_of_month':'1984-12','prime_lending_rate':'9.40','banks_fixed_deposits_3m':'6.00','banks_fixed_deposits_6m':'6.35','banks_fixed_deposits_12m':'6.80','banks_savings_deposits':'6.53','fc_hire_purchase_motor_3y':'11.51','fc_housing_loans_15y':'10.83','fc_fixed_deposits_3m':'6.48','fc_fixed_deposits_6m':'6.75','fc_fixed_deposits_12m':'7.18','fc_savings_deposits':'6.93','timestamp':'1552565664'},{'end_of_month':'1985-01','prime_lending_rate':'9.08','banks_fixed_deposits_3m':'5.78','banks_fixed_deposits_6m':'6.10','banks_fixed_deposits_12m':'6.55','banks_savings_deposits':'6.30','fc_hire_purchase_motor_3y':'11.51','fc_housing_loans_15y':'10.69','fc_fixed_deposits_3m':'6.00','fc_fixed_deposits_6m':'6.30','fc_fixed_deposits_12m':'6.93','fc_savings_deposits':'6.71','timestamp':'1552565664'},{'end_of_month':'1985-02','prime_lending_rate':'9.03','banks_fixed_deposits_3m':'5.70','banks_fixed_deposits_6m':'6.03','banks_fixed_deposits_12m':'6.50','banks_savings_deposits':'6.28','fc_hire_purchase_motor_3y':'11.48','fc_housing_loans_15y':'10.64','fc_fixed_deposits_3m':'6.03','fc_fixed_deposits_6m':'6.33','fc_fixed_deposits_12m':'6.93','fc_savings_deposits':'6.64','timestamp':'1552565664'},{'end_of_month':'1985-03','prime_lending_rate':'9.03','banks_fixed_deposits_3m':'5.73','banks_fixed_deposits_6m':'6.03','banks_fixed_deposits_12m':'6.50','banks_savings_deposits':'6.28','fc_hire_purchase_motor_3y':'11.48','fc_housing_loans_15y':'10.57','fc_fixed_deposits_3m':'6.03','fc_fixed_deposits_6m':'6.33','fc_fixed_deposits_12m':'6.93','fc_savings_deposits':'6.64','timestamp':'1552565664'},{'end_of_month':'1985-04','prime_lending_rate':'8.73','banks_fixed_deposits_3m':'5.38','banks_fixed_deposits_6m':'5.68','banks_fixed_deposits_12m':'6.15','banks_savings_deposits':'6.13','fc_hire_purchase_motor_3y':'11.21','fc_housing_loans_15y':'10.39','fc_fixed_deposits_3m':'5.68','fc_fixed_deposits_6m':'5.95','fc_fixed_deposits_12m':'6.60','fc_savings_deposits':'6.34','timestamp':'1552565664'},{'end_of_month':'1985-05','prime_lending_rate':'8.48','banks_fixed_deposits_3m':'5.15','banks_fixed_deposits_6m':'5.40','banks_fixed_deposits_12m':'5.83','banks_savings_deposits':'5.90','fc_hire_purchase_motor_3y':'11.08','fc_housing_loans_15y':'10.29','fc_fixed_deposits_3m':'5.28','fc_fixed_deposits_6m':'5.53','fc_fixed_deposits_12m':'6.15','fc_savings_deposits':'5.94','timestamp':'1552565664'},{'end_of_month':'1985-06','prime_lending_rate':'8.28','banks_fixed_deposits_3m':'5.03','banks_fixed_deposits_6m':'5.28','banks_fixed_deposits_12m':'5.65','banks_savings_deposits':'5.68','fc_hire_purchase_motor_3y':'11.08','fc_housing_loans_15y':'10.21','fc_fixed_deposits_3m':'5.18','fc_fixed_deposits_6m':'5.43','fc_fixed_deposits_12m':'6.05','fc_savings_deposits':'5.84','timestamp':'1552565664'},{'end_of_month':'1985-07','prime_lending_rate':'8.03','banks_fixed_deposits_3m':'4.63','banks_fixed_deposits_6m':'4.90','banks_fixed_deposits_12m':'5.23','banks_savings_deposits':'5.43','fc_hire_purchase_motor_3y':'10.99','fc_housing_loans_15y':'10.10','fc_fixed_deposits_3m':'4.90','fc_fixed_deposits_6m':'5.15','fc_fixed_deposits_12m':'5.60','fc_savings_deposits':'5.63','timestamp':'1552565664'},{'end_of_month':'1985-08','prime_lending_rate':'7.28','banks_fixed_deposits_3m':'4.38','banks_fixed_deposits_6m':'4.63','banks_fixed_deposits_12m':'4.90','banks_savings_deposits':'5.18','fc_hire_purchase_motor_3y':'10.72','fc_housing_loans_15y':'10.00','fc_fixed_deposits_3m':'4.78','fc_fixed_deposits_6m':'5.03','fc_fixed_deposits_12m':'5.40','fc_savings_deposits':'5.47','timestamp':'1552565664'},{'end_of_month':'1985-09','prime_lending_rate':'7.20','banks_fixed_deposits_3m':'4.38','banks_fixed_deposits_6m':'4.60','banks_fixed_deposits_12m':'4.85','banks_savings_deposits':'5.15','fc_hire_purchase_motor_3y':'10.48','fc_housing_loans_15y':'9.62','fc_fixed_deposits_3m':'4.73','fc_fixed_deposits_6m':'4.98','fc_fixed_deposits_12m':'5.35','fc_savings_deposits':'5.44','timestamp':'1552565664'},{'end_of_month':'1985-10','prime_lending_rate':'7.23','banks_fixed_deposits_3m':'4.60','banks_fixed_deposits_6m':'4.73','banks_fixed_deposits_12m':'4.88','banks_savings_deposits':'5.18','fc_hire_purchase_motor_3y':'10.44','fc_housing_loans_15y':'9.49','fc_fixed_deposits_3m':'4.88','fc_fixed_deposits_6m':'5.08','fc_fixed_deposits_12m':'5.35','fc_savings_deposits':'5.47','timestamp':'1552565664'},{'end_of_month':'1985-11','prime_lending_rate':'7.20','banks_fixed_deposits_3m':'4.58','banks_fixed_deposits_6m':'4.70','banks_fixed_deposits_12m':'4.88','banks_savings_deposits':'5.18','fc_hire_purchase_motor_3y':'10.39','fc_housing_loans_15y':'9.39','fc_fixed_deposits_3m':'4.88','fc_fixed_deposits_6m':'5.03','fc_fixed_deposits_12m':'5.30','fc_savings_deposits':'5.41','timestamp':'1552565664'},{'end_of_month':'1985-12','prime_lending_rate':'7.20','banks_fixed_deposits_3m':'4.58','banks_fixed_deposits_6m':'4.70','banks_fixed_deposits_12m':'4.88','banks_savings_deposits':'5.18','fc_hire_purchase_motor_3y':'10.39','fc_housing_loans_15y':'9.39','fc_fixed_deposits_3m':'4.88','fc_fixed_deposits_6m':'5.03','fc_fixed_deposits_12m':'5.30','fc_savings_deposits':'5.41','timestamp':'1552565664'},{'end_of_month':'1986-01','prime_lending_rate':'7.20','banks_fixed_deposits_3m':'4.55','banks_fixed_deposits_6m':'4.68','banks_fixed_deposits_12m':'4.88','banks_savings_deposits':'5.03','fc_hire_purchase_motor_3y':'10.35','fc_housing_loans_15y':'9.36','fc_fixed_deposits_3m':'4.88','fc_fixed_deposits_6m':'5.00','fc_fixed_deposits_12m':'5.30','fc_savings_deposits':'5.38','timestamp':'1552565664'},{'end_of_month':'1986-02','prime_lending_rate':'7.20','banks_fixed_deposits_3m':'4.55','banks_fixed_deposits_6m':'4.68','banks_fixed_deposits_12m':'4.88','banks_savings_deposits':'5.03','fc_hire_purchase_motor_3y':'10.32','fc_housing_loans_15y':'9.36','fc_fixed_deposits_3m':'4.75','fc_fixed_deposits_6m':'4.90','fc_fixed_deposits_12m':'5.15','fc_savings_deposits':'5.31','timestamp':'1552565664'},{'end_of_month':'1986-03','prime_lending_rate':'7.18','banks_fixed_deposits_3m':'4.45','banks_fixed_deposits_6m':'4.63','banks_fixed_deposits_12m':'4.83','banks_savings_deposits':'5.00','fc_hire_purchase_motor_3y':'10.08','fc_housing_loans_15y':'9.36','fc_fixed_deposits_3m':'4.73','fc_fixed_deposits_6m':'4.88','fc_fixed_deposits_12m':'5.13','fc_savings_deposits':'5.28','timestamp':'1552565664'},{'end_of_month':'1986-04','prime_lending_rate':'7.15','banks_fixed_deposits_3m':'4.43','banks_fixed_deposits_6m':'4.58','banks_fixed_deposits_12m':'4.75','banks_savings_deposits':'4.80','fc_hire_purchase_motor_3y':'9.99','fc_housing_loans_15y':'9.19','fc_fixed_deposits_3m':'4.75','fc_fixed_deposits_6m':'4.93','fc_fixed_deposits_12m':'5.15','fc_savings_deposits':'5.19','timestamp':'1552565664'},{'end_of_month':'1986-05','prime_lending_rate':'7.15','banks_fixed_deposits_3m':'4.43','banks_fixed_deposits_6m':'4.55','banks_fixed_deposits_12m':'4.73','banks_savings_deposits':'4.78','fc_hire_purchase_motor_3y':'9.90','fc_housing_loans_15y':'9.08','fc_fixed_deposits_3m':'4.75','fc_fixed_deposits_6m':'4.93','fc_fixed_deposits_12m':'5.15','fc_savings_deposits':'5.19','timestamp':'1552565664'},{'end_of_month':'1986-06','prime_lending_rate':'7.15','banks_fixed_deposits_3m':'4.43','banks_fixed_deposits_6m':'4.55','banks_fixed_deposits_12m':'4.73','banks_savings_deposits':'4.78','fc_hire_purchase_motor_3y':'9.77','fc_housing_loans_15y':'9.06','fc_fixed_deposits_3m':'4.75','fc_fixed_deposits_6m':'4.88','fc_fixed_deposits_12m':'5.08','fc_savings_deposits':'5.16','timestamp':'1552565664'},{'end_of_month':'1986-07','prime_lending_rate':'7.05','banks_fixed_deposits_3m':'4.10','banks_fixed_deposits_6m':'4.33','banks_fixed_deposits_12m':'4.40','banks_savings_deposits':'4.40','fc_hire_purchase_motor_3y':'9.63','fc_housing_loans_15y':'8.98','fc_fixed_deposits_3m':'4.56','fc_fixed_deposits_6m':'4.73','fc_fixed_deposits_12m':'4.85','fc_savings_deposits':'4.88','timestamp':'1552565664'},{'end_of_month':'1986-08','prime_lending_rate':'6.83','banks_fixed_deposits_3m':'3.90','banks_fixed_deposits_6m':'4.03','banks_fixed_deposits_12m':'4.18','banks_savings_deposits':'4.13','fc_hire_purchase_motor_3y':'9.45','fc_housing_loans_15y':'8.93','fc_fixed_deposits_3m':'4.14','fc_fixed_deposits_6m':'4.33','fc_fixed_deposits_12m':'4.51','fc_savings_deposits':'4.53','timestamp':'1552565664'},{'end_of_month':'1986-09','prime_lending_rate':'6.45','banks_fixed_deposits_3m':'3.33','banks_fixed_deposits_6m':'3.45','banks_fixed_deposits_12m':'3.68','banks_savings_deposits':'3.63','fc_hire_purchase_motor_3y':'9.14','fc_housing_loans_15y':'8.85','fc_fixed_deposits_3m':'3.65','fc_fixed_deposits_6m':'3.79','fc_fixed_deposits_12m':'3.98','fc_savings_deposits':'4.00','timestamp':'1552565664'},{'end_of_month':'1986-10','prime_lending_rate':'6.28','banks_fixed_deposits_3m':'3.00','banks_fixed_deposits_6m':'3.13','banks_fixed_deposits_12m':'3.35','banks_savings_deposits':'3.28','fc_hire_purchase_motor_3y':'9.00','fc_housing_loans_15y':'8.42','fc_fixed_deposits_3m':'3.28','fc_fixed_deposits_6m':'3.39','fc_fixed_deposits_12m':'3.64','fc_savings_deposits':'3.75','timestamp':'1552565664'},{'end_of_month':'1986-11','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.03','banks_fixed_deposits_12m':'3.30','banks_savings_deposits':'3.10','fc_hire_purchase_motor_3y':'8.91','fc_housing_loans_15y':'8.27','fc_fixed_deposits_3m':'3.18','fc_fixed_deposits_6m':'3.29','fc_fixed_deposits_12m':'3.55','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1986-12','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.03','banks_fixed_deposits_12m':'3.30','banks_savings_deposits':'3.05','fc_hire_purchase_motor_3y':'8.91','fc_housing_loans_15y':'8.09','fc_fixed_deposits_3m':'3.19','fc_fixed_deposits_6m':'3.29','fc_fixed_deposits_12m':'3.60','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1987-01','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.03','banks_fixed_deposits_12m':'3.30','banks_savings_deposits':'3.05','fc_hire_purchase_motor_3y':'8.91','fc_housing_loans_15y':'7.74','fc_fixed_deposits_3m':'3.16','fc_fixed_deposits_6m':'3.26','fc_fixed_deposits_12m':'3.58','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1987-02','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.03','banks_fixed_deposits_12m':'3.30','banks_savings_deposits':'3.05','fc_hire_purchase_motor_3y':'8.87','fc_housing_loans_15y':'7.74','fc_fixed_deposits_3m':'3.16','fc_fixed_deposits_6m':'3.29','fc_fixed_deposits_12m':'3.65','fc_savings_deposits':'3.50','timestamp':'1552565664'},{'end_of_month':'1987-03','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.85','banks_fixed_deposits_6m':'3.00','banks_fixed_deposits_12m':'3.28','banks_savings_deposits':'3.03','fc_hire_purchase_motor_3y':'8.78','fc_housing_loans_15y':'7.66','fc_fixed_deposits_3m':'3.16','fc_fixed_deposits_6m':'3.29','fc_fixed_deposits_12m':'3.65','fc_savings_deposits':'3.50','timestamp':'1552565664'},{'end_of_month':'1987-04','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.85','banks_fixed_deposits_6m':'3.00','banks_fixed_deposits_12m':'3.28','banks_savings_deposits':'3.03','fc_hire_purchase_motor_3y':'8.46','fc_housing_loans_15y':'7.59','fc_fixed_deposits_3m':'3.16','fc_fixed_deposits_6m':'3.29','fc_fixed_deposits_12m':'3.65','fc_savings_deposits':'3.50','timestamp':'1552565664'},{'end_of_month':'1987-05','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.85','banks_fixed_deposits_6m':'3.05','banks_fixed_deposits_12m':'3.38','banks_savings_deposits':'3.03','fc_hire_purchase_motor_3y':'8.42','fc_housing_loans_15y':'7.46','fc_fixed_deposits_3m':'3.21','fc_fixed_deposits_6m':'3.34','fc_fixed_deposits_12m':'3.70','fc_savings_deposits':'3.50','timestamp':'1552565664'},{'end_of_month':'1987-06','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.08','banks_fixed_deposits_12m':'3.45','banks_savings_deposits':'3.03','fc_hire_purchase_motor_3y':'8.24','fc_housing_loans_15y':'7.38','fc_fixed_deposits_3m':'3.30','fc_fixed_deposits_6m':'3.45','fc_fixed_deposits_12m':'3.86','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1987-07','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.08','banks_fixed_deposits_12m':'3.48','banks_savings_deposits':'3.03','fc_hire_purchase_motor_3y':'8.06','fc_housing_loans_15y':'7.36','fc_fixed_deposits_3m':'3.33','fc_fixed_deposits_6m':'3.48','fc_fixed_deposits_12m':'3.90','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1987-08','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.08','banks_fixed_deposits_12m':'3.48','banks_savings_deposits':'3.03','fc_hire_purchase_motor_3y':'7.88','fc_housing_loans_15y':'7.28','fc_fixed_deposits_3m':'3.33','fc_fixed_deposits_6m':'3.50','fc_fixed_deposits_12m':'3.93','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1987-09','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.90','banks_fixed_deposits_6m':'3.15','banks_fixed_deposits_12m':'3.60','banks_savings_deposits':'3.05','fc_hire_purchase_motor_3y':'7.88','fc_housing_loans_15y':'7.25','fc_fixed_deposits_3m':'3.35','fc_fixed_deposits_6m':'3.55','fc_fixed_deposits_12m':'3.98','fc_savings_deposits':'3.53','timestamp':'1552565664'},{'end_of_month':'1987-10','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.98','banks_fixed_deposits_6m':'3.23','banks_fixed_deposits_12m':'3.76','banks_savings_deposits':'3.08','fc_hire_purchase_motor_3y':'7.88','fc_housing_loans_15y':'7.20','fc_fixed_deposits_3m':'3.40','fc_fixed_deposits_6m':'3.60','fc_fixed_deposits_12m':'4.08','fc_savings_deposits':'3.56','timestamp':'1552565664'},{'end_of_month':'1987-11','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.95','banks_fixed_deposits_6m':'3.23','banks_fixed_deposits_12m':'3.74','banks_savings_deposits':'3.08','fc_hire_purchase_motor_3y':'7.76','fc_housing_loans_15y':'7.18','fc_fixed_deposits_3m':'3.33','fc_fixed_deposits_6m':'3.53','fc_fixed_deposits_12m':'4.05','fc_savings_deposits':'3.56','timestamp':'1552565664'},{'end_of_month':'1987-12','prime_lending_rate':'6.10','banks_fixed_deposits_3m':'2.85','banks_fixed_deposits_6m':'3.11','banks_fixed_deposits_12m':'3.53','banks_savings_deposits':'2.98','fc_hire_purchase_motor_3y':'7.76','fc_housing_loans_15y':'7.13','fc_fixed_deposits_3m':'3.20','fc_fixed_deposits_6m':'3.48','fc_fixed_deposits_12m':'3.98','fc_savings_deposits':'3.50','timestamp':'1552565664'},{'end_of_month':'1988-01','prime_lending_rate':'5.98','banks_fixed_deposits_3m':'2.66','banks_fixed_deposits_6m':'2.91','banks_fixed_deposits_12m':'3.31','banks_savings_deposits':'2.75','fc_hire_purchase_motor_3y':'7.61','fc_housing_loans_15y':'7.06','fc_fixed_deposits_3m':'3.03','fc_fixed_deposits_6m':'3.35','fc_fixed_deposits_12m':'3.84','fc_savings_deposits':'3.25','timestamp':'1552565664'},{'end_of_month':'1988-02','prime_lending_rate':'5.93','banks_fixed_deposits_3m':'2.61','banks_fixed_deposits_6m':'2.86','banks_fixed_deposits_12m':'3.26','banks_savings_deposits':'2.70','fc_hire_purchase_motor_3y':'7.37','fc_housing_loans_15y':'6.86','fc_fixed_deposits_3m':'2.85','fc_fixed_deposits_6m':'3.12','fc_fixed_deposits_12m':'3.67','fc_savings_deposits':'3.14','timestamp':'1552565664'},{'end_of_month':'1988-03','prime_lending_rate':'5.85','banks_fixed_deposits_3m':'2.58','banks_fixed_deposits_6m':'2.85','banks_fixed_deposits_12m':'3.25','banks_savings_deposits':'2.68','fc_hire_purchase_motor_3y':'7.08','fc_housing_loans_15y':'6.81','fc_fixed_deposits_3m':'2.84','fc_fixed_deposits_6m':'3.08','fc_fixed_deposits_12m':'3.62','fc_savings_deposits':'3.06','timestamp':'1552565664'},{'end_of_month':'1988-04','prime_lending_rate':'5.85','banks_fixed_deposits_3m':'2.58','banks_fixed_deposits_6m':'2.85','banks_fixed_deposits_12m':'3.25','banks_savings_deposits':'2.68','fc_hire_purchase_motor_3y':'6.79','fc_housing_loans_15y':'6.67','fc_fixed_deposits_3m':'2.81','fc_fixed_deposits_6m':'3.05','fc_fixed_deposits_12m':'3.60','fc_savings_deposits':'3.06','timestamp':'1552565664'},{'end_of_month':'1988-05','prime_lending_rate':'5.85','banks_fixed_deposits_3m':'2.58','banks_fixed_deposits_6m':'2.85','banks_fixed_deposits_12m':'3.28','banks_savings_deposits':'2.68','fc_hire_purchase_motor_3y':'6.65','fc_housing_loans_15y':'6.36','fc_fixed_deposits_3m':'2.84','fc_fixed_deposits_6m':'3.04','fc_fixed_deposits_12m':'3.58','fc_savings_deposits':'3.00','timestamp':'1552565664'},{'end_of_month':'1988-06','prime_lending_rate':'5.85','banks_fixed_deposits_3m':'2.60','banks_fixed_deposits_6m':'2.98','banks_fixed_deposits_12m':'3.45','banks_savings_deposits':'2.65','fc_hire_purchase_motor_3y':'6.65','fc_housing_loans_15y':'6.18','fc_fixed_deposits_3m':'2.89','fc_fixed_deposits_6m':'3.19','fc_fixed_deposits_12m':'3.75','fc_savings_deposits':'3.00','timestamp':'1552565664'},{'end_of_month':'1988-07','prime_lending_rate':'5.85','banks_fixed_deposits_3m':'2.70','banks_fixed_deposits_6m':'3.00','banks_fixed_deposits_12m':'3.51','banks_savings_deposits':'2.65','fc_hire_purchase_motor_3y':'6.65','fc_housing_loans_15y':'6.16','fc_fixed_deposits_3m':'2.99','fc_fixed_deposits_6m':'3.29','fc_fixed_deposits_12m':'3.85','fc_savings_deposits':'3.05','timestamp':'1552565664'},{'end_of_month':'1988-08','prime_lending_rate':'6.05','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.18','banks_fixed_deposits_12m':'3.75','banks_savings_deposits':'2.75','fc_hire_purchase_motor_3y':'6.67','fc_housing_loans_15y':'6.13','fc_fixed_deposits_3m':'3.22','fc_fixed_deposits_6m':'3.50','fc_fixed_deposits_12m':'4.12','fc_savings_deposits':'3.17','timestamp':'1552565664'},{'end_of_month':'1988-09','prime_lending_rate':'6.05','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.23','banks_fixed_deposits_12m':'3.78','banks_savings_deposits':'2.75','fc_hire_purchase_motor_3y':'6.57','fc_housing_loans_15y':'6.13','fc_fixed_deposits_3m':'3.27','fc_fixed_deposits_6m':'3.59','fc_fixed_deposits_12m':'4.25','fc_savings_deposits':'3.20','timestamp':'1552565664'},{'end_of_month':'1988-10','prime_lending_rate':'6.05','banks_fixed_deposits_3m':'2.88','banks_fixed_deposits_6m':'3.23','banks_fixed_deposits_12m':'3.86','banks_savings_deposits':'2.75','fc_hire_purchase_motor_3y':'6.62','fc_housing_loans_15y':'6.13','fc_fixed_deposits_3m':'3.27','fc_fixed_deposits_6m':'3.59','fc_fixed_deposits_12m':'4.25','fc_savings_deposits':'3.20','timestamp':'1552565664'},{'end_of_month':'1988-11','prime_lending_rate':'6.13','banks_fixed_deposits_3m':'2.95','banks_fixed_deposits_6m':'3.33','banks_fixed_deposits_12m':'3.98','banks_savings_deposits':'2.83','fc_hire_purchase_motor_3y':'6.64','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'3.39','fc_fixed_deposits_6m':'3.74','fc_fixed_deposits_12m':'4.43','fc_savings_deposits':'3.30','timestamp':'1552565664'},{'end_of_month':'1988-12','prime_lending_rate':'6.13','banks_fixed_deposits_3m':'2.95','banks_fixed_deposits_6m':'3.33','banks_fixed_deposits_12m':'4.03','banks_savings_deposits':'2.83','fc_hire_purchase_motor_3y':'6.64','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'3.41','fc_fixed_deposits_6m':'3.78','fc_fixed_deposits_12m':'4.48','fc_savings_deposits':'3.30','timestamp':'1552565664'},{'end_of_month':'1989-01','prime_lending_rate':'6.13','banks_fixed_deposits_3m':'2.99','banks_fixed_deposits_6m':'3.36','banks_fixed_deposits_12m':'4.03','banks_savings_deposits':'2.83','fc_hire_purchase_motor_3y':'6.73','fc_housing_loans_15y':'6.16','fc_fixed_deposits_3m':'3.58','fc_fixed_deposits_6m':'3.85','fc_fixed_deposits_12m':'4.56','fc_savings_deposits':'3.43','timestamp':'1552565664'},{'end_of_month':'1989-02','prime_lending_rate':'6.15','banks_fixed_deposits_3m':'3.03','banks_fixed_deposits_6m':'3.39','banks_fixed_deposits_12m':'4.00','banks_savings_deposits':'2.85','fc_hire_purchase_motor_3y':'6.73','fc_housing_loans_15y':'6.16','fc_fixed_deposits_3m':'3.58','fc_fixed_deposits_6m':'3.85','fc_fixed_deposits_12m':'4.58','fc_savings_deposits':'3.46','timestamp':'1552565664'},{'end_of_month':'1989-03','prime_lending_rate':'6.18','banks_fixed_deposits_3m':'3.05','banks_fixed_deposits_6m':'3.41','banks_fixed_deposits_12m':'4.03','banks_savings_deposits':'2.88','fc_hire_purchase_motor_3y':'6.78','fc_housing_loans_15y':'6.16','fc_fixed_deposits_3m':'3.58','fc_fixed_deposits_6m':'3.85','fc_fixed_deposits_12m':'4.59','fc_savings_deposits':'3.46','timestamp':'1552565664'},{'end_of_month':'1989-04','prime_lending_rate':'6.20','banks_fixed_deposits_3m':'3.18','banks_fixed_deposits_6m':'3.66','banks_fixed_deposits_12m':'4.48','banks_savings_deposits':'2.93','fc_hire_purchase_motor_3y':'6.97','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'3.88','fc_fixed_deposits_6m':'4.18','fc_fixed_deposits_12m':'4.94','fc_savings_deposits':'3.49','timestamp':'1552565664'},{'end_of_month':'1989-05','prime_lending_rate':'6.23','banks_fixed_deposits_3m':'3.25','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.58','banks_savings_deposits':'2.95','fc_hire_purchase_motor_3y':'6.98','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'3.95','fc_fixed_deposits_6m':'4.25','fc_fixed_deposits_12m':'4.96','fc_savings_deposits':'3.52','timestamp':'1552565664'},{'end_of_month':'1989-06','prime_lending_rate':'6.23','banks_fixed_deposits_3m':'3.28','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.60','banks_savings_deposits':'2.95','fc_hire_purchase_motor_3y':'6.98','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'4.03','fc_fixed_deposits_6m':'4.25','fc_fixed_deposits_12m':'4.99','fc_savings_deposits':'3.58','timestamp':'1552565664'},{'end_of_month':'1989-07','prime_lending_rate':'6.23','banks_fixed_deposits_3m':'3.28','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.60','banks_savings_deposits':'2.95','fc_hire_purchase_motor_3y':'6.98','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'4.03','fc_fixed_deposits_6m':'4.30','fc_fixed_deposits_12m':'5.04','fc_savings_deposits':'3.64','timestamp':'1552565664'},{'end_of_month':'1989-08','prime_lending_rate':'6.23','banks_fixed_deposits_3m':'3.28','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.53','banks_savings_deposits':'2.95','fc_hire_purchase_motor_3y':'6.98','fc_housing_loans_15y':'6.11','fc_fixed_deposits_3m':'4.03','fc_fixed_deposits_6m':'4.30','fc_fixed_deposits_12m':'4.98','fc_savings_deposits':'3.64','timestamp':'1552565664'},{'end_of_month':'1989-09','prime_lending_rate':'6.23','banks_fixed_deposits_3m':'3.28','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.53','banks_savings_deposits':'2.98','fc_hire_purchase_motor_3y':'7.00','fc_housing_loans_15y':'6.17','fc_fixed_deposits_3m':'4.10','fc_fixed_deposits_6m':'4.38','fc_fixed_deposits_12m':'5.00','fc_savings_deposits':'3.64','timestamp':'1552565664'},{'end_of_month':'1989-10','prime_lending_rate':'6.23','banks_fixed_deposits_3m':'3.28','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.53','banks_savings_deposits':'2.98','fc_hire_purchase_motor_3y':'7.00','fc_housing_loans_15y':'6.12','fc_fixed_deposits_3m':'4.13','fc_fixed_deposits_6m':'4.38','fc_fixed_deposits_12m':'5.00','fc_savings_deposits':'3.67','timestamp':'1552565664'},{'end_of_month':'1989-11','prime_lending_rate':'6.25','banks_fixed_deposits_3m':'3.30','banks_fixed_deposits_6m':'3.79','banks_fixed_deposits_12m':'4.53','banks_savings_deposits':'2.98','fc_hire_purchase_motor_3y':'7.00','fc_housing_loans_15y':'6.15','fc_fixed_deposits_3m':'4.13','fc_fixed_deposits_6m':'4.38','fc_fixed_deposits_12m':'4.98','fc_savings_deposits':'3.64','timestamp':'1552565664'},{'end_of_month':'1989-12','prime_lending_rate':'6.25','banks_fixed_deposits_3m':'3.35','banks_fixed_deposits_6m':'3.86','banks_fixed_deposits_12m':'4.55','banks_savings_deposits':'2.98','fc_hire_purchase_motor_3y':'7.00','fc_housing_loans_15y':'6.15','fc_fixed_deposits_3m':'4.15','fc_fixed_deposits_6m':'4.38','fc_fixed_deposits_12m':'4.98','fc_savings_deposits':'3.64','timestamp':'1552565664'},{'end_of_month':'1990-01','prime_lending_rate':'6.28','banks_fixed_deposits_3m':'3.55','banks_fixed_deposits_6m':'4.04','banks_fixed_deposits_12m':'4.65','banks_savings_deposits':'2.98','fc_hire_purchase_motor_3y':'7.03','fc_housing_loans_15y':'6.15','fc_fixed_deposits_3m':'4.20','fc_fixed_deposits_6m':'4.44','fc_fixed_deposits_12m':'4.95','fc_savings_deposits':'3.64','timestamp':'1552565664'},{'end_of_month':'1990-02','prime_lending_rate':'6.60','banks_fixed_deposits_3m':'3.83','banks_fixed_deposits_6m':'4.30','banks_fixed_deposits_12m':'4.93','banks_savings_deposits':'3.00','fc_hire_purchase_motor_3y':'7.20','fc_housing_loans_15y':'6.15','fc_fixed_deposits_3m':'4.35','fc_fixed_deposits_6m':'4.66','fc_fixed_deposits_12m':'5.09','fc_savings_deposits':'3.66','timestamp':'1552565664'},{'end_of_month':'1990-03','prime_lending_rate':'6.65','banks_fixed_deposits_3m':'3.93','banks_fixed_deposits_6m':'4.33','banks_fixed_deposits_12m':'4.93','banks_savings_deposits':'3.00','fc_hire_purchase_motor_3y':'7.42','fc_housing_loans_15y':'6.22','fc_fixed_deposits_3m':'4.43','fc_fixed_deposits_6m':'4.75','fc_fixed_deposits_12m':'5.16','fc_savings_deposits':'3.66','timestamp':'1552565664'},{'end_of_month':'1990-04','prime_lending_rate':'7.03','banks_fixed_deposits_3m':'4.45','banks_fixed_deposits_6m':'4.88','banks_fixed_deposits_12m':'5.20','banks_savings_deposits':'3.18','fc_hire_purchase_motor_3y':'7.82','fc_housing_loans_15y':'6.59','fc_fixed_deposits_3m':'4.85','fc_fixed_deposits_6m':'5.15','fc_fixed_deposits_12m':'5.58','fc_savings_deposits':'3.91','timestamp':'1552565664'},{'end_of_month':'1990-05','prime_lending_rate':'7.23','banks_fixed_deposits_3m':'4.50','banks_fixed_deposits_6m':'5.00','banks_fixed_deposits_12m':'5.28','banks_savings_deposits':'3.28','fc_hire_purchase_motor_3y':'7.87','fc_housing_loans_15y':'6.59','fc_fixed_deposits_3m':'4.93','fc_fixed_deposits_6m':'5.24','fc_fixed_deposits_12m':'5.68','fc_savings_deposits':'3.94','timestamp':'1552565664'},{'end_of_month':'1990-06','prime_lending_rate':'7.60','banks_fixed_deposits_3m':'4.95','banks_fixed_deposits_6m':'5.45','banks_fixed_deposits_12m':'5.70','banks_savings_deposits':'3.58','fc_hire_purchase_motor_3y':'8.30','fc_housing_loans_15y':'6.93','fc_fixed_deposits_3m':'5.41','fc_fixed_deposits_6m':'5.76','fc_fixed_deposits_12m':'6.05','fc_savings_deposits':'4.16','timestamp':'1552565664'},{'end_of_month':'1990-07','prime_lending_rate':'7.65','banks_fixed_deposits_3m':'5.08','banks_fixed_deposits_6m':'5.50','banks_fixed_deposits_12m':'5.76','banks_savings_deposits':'3.65','fc_hire_purchase_motor_3y':'8.41','fc_housing_loans_15y':'7.02','fc_fixed_deposits_3m':'5.48','fc_fixed_deposits_6m':'5.85','fc_fixed_deposits_12m':'6.13','fc_savings_deposits':'4.19','timestamp':'1552565664'},{'end_of_month':'1990-08','prime_lending_rate':'7.90','banks_fixed_deposits_3m':'5.18','banks_fixed_deposits_6m':'5.63','banks_fixed_deposits_12m':'6.06','banks_savings_deposits':'3.85','fc_hire_purchase_motor_3y':'8.48','fc_housing_loans_15y':'7.21','fc_fixed_deposits_3m':'5.65','fc_fixed_deposits_6m':'6.06','fc_fixed_deposits_12m':'6.36','fc_savings_deposits':'4.38','timestamp':'1552565664'},{'end_of_month':'1990-09','prime_lending_rate':'7.90','banks_fixed_deposits_3m':'5.20','banks_fixed_deposits_6m':'5.63','banks_fixed_deposits_12m':'6.08','banks_savings_deposits':'3.88','fc_hire_purchase_motor_3y':'8.58','fc_housing_loans_15y':'7.26','fc_fixed_deposits_3m':'5.65','fc_fixed_deposits_6m':'6.03','fc_fixed_deposits_12m':'6.33','fc_savings_deposits':'4.47','timestamp':'1552565664'},{'end_of_month':'1990-10','prime_lending_rate':'7.90','banks_fixed_deposits_3m':'5.20','banks_fixed_deposits_6m':'5.63','banks_fixed_deposits_12m':'6.08','banks_savings_deposits':'3.88','fc_hire_purchase_motor_3y':'8.58','fc_housing_loans_15y':'7.36','fc_fixed_deposits_3m':'5.65','fc_fixed_deposits_6m':'6.03','fc_fixed_deposits_12m':'6.33','fc_savings_deposits':'4.50','timestamp':'1552565664'},{'end_of_month':'1990-11','prime_lending_rate':'7.88','banks_fixed_deposits_3m':'5.14','banks_fixed_deposits_6m':'5.56','banks_fixed_deposits_12m':'5.97','banks_savings_deposits':'3.85','fc_hire_purchase_motor_3y':'8.63','fc_housing_loans_15y':'7.36','fc_fixed_deposits_3m':'5.54','fc_fixed_deposits_6m':'5.91','fc_fixed_deposits_12m':'6.21','fc_savings_deposits':'4.41','timestamp':'1552565664'},{'end_of_month':'1990-12','prime_lending_rate':'7.73','banks_fixed_deposits_3m':'5.05','banks_fixed_deposits_6m':'5.37','banks_fixed_deposits_12m':'5.48','banks_savings_deposits':'3.83','fc_hire_purchase_motor_3y':'8.67','fc_housing_loans_15y':'7.36','fc_fixed_deposits_3m':'5.20','fc_fixed_deposits_6m':'5.50','fc_fixed_deposits_12m':'5.80','fc_savings_deposits':'4.35','timestamp':'1552565664'},{'end_of_month':'1991-01','prime_lending_rate':'7.45','banks_fixed_deposits_3m':'4.55','banks_fixed_deposits_6m':'4.86','banks_fixed_deposits_12m':'5.02','banks_savings_deposits':'3.73','fc_hire_purchase_motor_3y':'8.63','fc_housing_loans_15y':'7.34','fc_fixed_deposits_3m':'4.60','fc_fixed_deposits_6m':'4.94','fc_fixed_deposits_12m':'5.15','fc_savings_deposits':'4.22','timestamp':'1552565664'},{'end_of_month':'1991-02','prime_lending_rate':'7.43','banks_fixed_deposits_3m':'4.55','banks_fixed_deposits_6m':'4.86','banks_fixed_deposits_12m':'5.02','banks_savings_deposits':'3.73','fc_hire_purchase_motor_3y':'8.56','fc_housing_loans_15y':'7.34','fc_fixed_deposits_3m':'4.56','fc_fixed_deposits_6m':'4.84','fc_fixed_deposits_12m':'5.08','fc_savings_deposits':'4.10','timestamp':'1552565664'},{'end_of_month':'1991-03','prime_lending_rate':'7.43','banks_fixed_deposits_3m':'4.52','banks_fixed_deposits_6m':'4.85','banks_fixed_deposits_12m':'4.99','banks_savings_deposits':'3.73','fc_hire_purchase_motor_3y':'8.56','fc_housing_loans_15y':'7.34','fc_fixed_deposits_3m':'4.58','fc_fixed_deposits_6m':'4.85','fc_fixed_deposits_12m':'5.08','fc_savings_deposits':'4.03','timestamp':'1552565664'},{'end_of_month':'1991-04','prime_lending_rate':'7.43','banks_fixed_deposits_3m':'4.52','banks_fixed_deposits_6m':'4.85','banks_fixed_deposits_12m':'4.99','banks_savings_deposits':'3.73','fc_hire_purchase_motor_3y':'8.54','fc_housing_loans_15y':'7.34','fc_fixed_deposits_3m':'4.56','fc_fixed_deposits_6m':'4.80','fc_fixed_deposits_12m':'5.03','fc_savings_deposits':'4.02','timestamp':'1552565664'}]}";

            RootObj root = JsonConvert.DeserializeObject<RootObj>(json);
            bool flag = false;
            foreach (var release in root.records)
            {


                s = release.end_of_month.ToString().Substring(0, 4);

                int s1 = Convert.ToInt16(s);
                int year1 = a.Year;
                int year2 = b.Year;

                if ((s1 >= year1) && (s1 <= year2))
                {
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine(" Banks Fixed Deposists Intrest Rate for 3 months for the period {1}-{2},= {0}", release.banks_fixed_deposits_3m, year1, year2);
                    Console.WriteLine(" Banks Fixed Deposists Intrest Rate for 6 months for the period {1}-{2},= {0}", release.banks_fixed_deposits_6m, year1, year2);
                    Console.WriteLine(" Banks Fixed Deposists Intrest Rate for 12 months for ther period {1}-{2},= {0}", release.banks_fixed_deposits_12m, year1, year2);
                    Console.WriteLine(" Banks Savings Deposits Intrest Rate for the period {1}-{2}, :{0}", release.banks_savings_deposits, year1, year2);
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine(" Financial Companies Fixed Deposists Intrest Rate for 3 months for the period {1}-{2},= {0}", release.fc_fixed_deposits_3m, year1, year2);
                    Console.WriteLine(" Financial Companies Fixed Deposists Intrest Rate for 6 months for the period {1}-{2},= {0}", release.fc_fixed_deposits_6m, year1, year2);
                    Console.WriteLine(" Financial Companies Fixed Deposists Intrest Rate for 12 months for the period {1}-{2},= {0}", release.fc_fixed_deposits_12m, year1, year2);
                    Console.WriteLine(" Financial Companies Savings Deposits Intrest Rate: {1}-{2},{0}", release.fc_savings_deposits, year1, year2);
                    // break;

                }
                else
                    flag = true;
            }
            if (flag)
            {
                Console.WriteLine("No Data Found for the input Date range.");
            }
            Console.WriteLine("Press Enter to execute further");
            Console.ReadLine();
            foreach (var release in root.records)
            {

                m = release.end_of_month.ToString().Substring(5, 2);
                y = release.end_of_month.ToString().Substring(0, 4);
                switch (m)
                {
                    case "01":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of January {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of January {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of January {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "02":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of February {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of February {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of February {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "03":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of March {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of March {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of March {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "04":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of April {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of April {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of April {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "05":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of May {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of May {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of May {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "06":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of June {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of June {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of June {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "07":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of July {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of July {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of July {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "08":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of August {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of August {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of August {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "09":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of September {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of September {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of September {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "10":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of October {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of October {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of October {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "11":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of November {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of November {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of November {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                    case "12":
                        if (Convert.ToDecimal(release.fc_fixed_deposits_3m) >= Convert.ToDecimal(release.banks_fixed_deposits_3m))
                        {
                            Console.WriteLine("For month of December {2} , fixed deposit Intrest rate for 3 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 3 months in Banks {1}", release.fc_fixed_deposits_3m, release.banks_fixed_deposits_3m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_6m) >= Convert.ToDecimal(release.banks_fixed_deposits_6m))
                        {
                            Console.WriteLine("For month of December {2}, fixed deposit Intrest rate for 6 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 6 months in Banks {1} ", release.fc_fixed_deposits_6m, release.banks_fixed_deposits_6m, y);

                        }
                        if (Convert.ToDecimal(release.fc_fixed_deposits_12m) >= Convert.ToDecimal(release.banks_fixed_deposits_12m))
                        {
                            Console.WriteLine("For month of December {2} , fixed deposit Intrest rate for 12 months in Financal companies {0}, is greater fixed deposit Intresrt rates for 12 months in Banks ", release.fc_fixed_deposits_12m, release.banks_fixed_deposits_12m, y);

                        }
                        break;
                }
            }
            Console.WriteLine("Press Enter to execute further");
            Console.ReadLine();
            int count = 0;
            foreach (var release in root.records)
            {
                avg_banks = avg_banks + Convert.ToDecimal(release.banks_fixed_deposits_3m) +
                     Convert.ToDecimal(release.banks_fixed_deposits_6m) + Convert.ToDecimal(release.banks_fixed_deposits_12m);
                avg_fc = avg_fc + Convert.ToDecimal(release.fc_fixed_deposits_3m) + Convert.ToDecimal(release.fc_fixed_deposits_6m) +
                    Convert.ToDecimal(release.fc_fixed_deposits_12m);
                count = count + 1;
            }

            decimal Average_banks = avg_banks / count;
            decimal Average_FC = avg_fc / count;

            Console.WriteLine("OverAll Average Intrest Rates for Banks : {0}", Average_banks);
            Console.WriteLine("OverAll Average Intrest Rates for Financial Companies : {0}", Average_FC);
            Console.ReadLine();

        }

        public static string GetData(IRequestHandler requestHandler)
        {
            return requestHandler.GetData(RequestConstants.Url);
        }
    }
}
