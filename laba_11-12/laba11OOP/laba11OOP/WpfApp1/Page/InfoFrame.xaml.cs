﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Repository;
using System.Data.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for InfoFrame.xaml
    /// </summary>
    public partial class InfoFrame : Page
    {
        public InfoFrame()
        {
            InitializeComponent();
            UnitOfWork db = new UnitOfWork();
            OrderGrid.ItemsSource = db.Orders.GetItemList().ToList();
        }

        public async Task GetObjects()
        {
            using (ShopBase db = new ShopBase())
            {
                await db.Customers.ForEachAsync(p =>
                {
                    OrderGrid.ItemsSource = db.Customers.ToList();
                });
            }
        }
    }
}
