﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoS_Simulator;
using Scenario_E_Commerce.Agents;
using Scenario_E_Commerce.Objects;

namespace Scenario_E_Commerce
{
    public class ScenarioMain : Simulator
    {
        Amazon _amazon;
        Customer _customer;
        BarnesAndNoble _dell;
        UPS _ups;
        UPSDriver _upsDriver;
        Visa _visa;

        protected override void Initialize()
        {
            // Instantiate constituents
            _amazon = new Amazon(this);
            _customer = new Customer(this);
            _dell = new BarnesAndNoble(this);
            _ups = new UPS(this);
            _upsDriver = new UPSDriver(this);
            _visa = new Visa(this);
        }

        protected override void Run()
        {
            // Reset
            List<Product> productsToBuy;
            Product tempProduct;
            Card creditCard;

            productsToBuy = new List<Product>();

            // Add books
            tempProduct = new Product();
            tempProduct.Name = "Software Engineering (10th Edition)";
            tempProduct.Price = 165.20;
            productsToBuy.Add(tempProduct);

            tempProduct = new Product();
            tempProduct.Name = "Introduction to Programming Using C#";
            tempProduct.Price = 24.95;
            productsToBuy.Add(tempProduct);

            // Add credit card
            creditCard = new Card();
            creditCard.Number = "12345";
            creditCard.Name = "John Doe";
            //creditCard.CreditLimit = 200.00;

            // Begin simulation
            _customer.BuyProduct(productsToBuy.ToArray(), creditCard);
        }

        public override string GetMonitoringText()
        {
            return "Test";
        }
    }
}
