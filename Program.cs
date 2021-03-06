using System;
using System.Collections;

namespace Collections_Case_Study
{
    public class Customer
    {
        public string cust_name;
        public string cust_email;
        public string cust_shipadd;
        public string cust_billadd;

        public Customer(string n, string e, string add1, string add2)
        {
            cust_name = n;
            cust_email = e;
            cust_shipadd = add1;
            cust_billadd = add2;
        }
        public void ShowCustomer()
        {
            Console.WriteLine("Name:" + cust_name);
            Console.WriteLine("Email:" + cust_email);
            Console.WriteLine("Shipping Address:" + cust_shipadd);
            Console.WriteLine("Billing Address:" + cust_billadd);
        }
    }

    public class Product
    {
        public string prod_name;
        public float prod_price;
        public int quantity;

        public Product(string n, float p, int q)
        {
            prod_name = n;
            prod_price = p;
            quantity = q;
        }
        public void showProducts()
        {
            Console.WriteLine("Product Name:" + prod_name);
            Console.WriteLine("Product Price:" + prod_price);
        }
    }

    public class Cart
    {
        Customer cart_customer;
        ArrayList cart_products = new ArrayList();
        public int total_amount;
        public bool confirmstatus;


        public Cart(Customer c, ArrayList a, bool status)
        {
            cart_customer = c;
            cart_products = a;
            confirmstatus = status;

            for(int i=0;i<cart_products.Count;i++)
            {
                Product p = (Product)cart_products[i];
                total_amount += (int)p.prod_price * p.quantity;
            }
        }
        public void ShowCart()
        {
            Console.WriteLine(" Customer Name:" + cart_customer.cust_name);
            Console.WriteLine(" Customer Email:" + cart_customer.cust_email);
            Console.WriteLine(" Customer Shipping Address:" + cart_customer.cust_shipadd);

            for(int num=0;num<cart_products.Count;num++)
            {
                Product newproduct = (Product)cart_products[num];
                newproduct.showProducts();
            }
        }
    }

    public class Order
    {
        public ArrayList orders = new ArrayList();

        public void addorder(Cart c)
        {
            orders.Add(c);
            c.ShowCart();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("Anant","anant@gmail.com","New Delhi","New Delhi");
            Customer customer2 = new Customer("Rishab", "rishab@gmail.com", "Varanasi", "varanasi");

            Product product1 = new Product("Cornflakes", 20, 10);
            Product product2 = new Product("Tea", 200, 5);
            Product product3 = new Product("Apple", 150, 10);
            Product product4 = new Product("Cofee", 120, 8);

            ArrayList order1 = new ArrayList();
            order1.Add(product1);
            order1.Add(product3);

            int confirm_order = 0;

            Console.WriteLine("Confirm the order?(1 for yes and 2 for no):");
            confirm_order = Convert.ToInt32(Console.ReadLine());

            Order mainorder = new Order();

            if(confirm_order == 1)
            {
                Cart cart = new Cart(customer1, order1, true);
                mainorder.addorder(cart);
            }
            else
            {
                Cart cart = new Cart(customer1, order1, false);
            }
            Console.WriteLine(mainorder.ToString());
        }
    }
}
