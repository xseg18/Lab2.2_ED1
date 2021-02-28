﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_ED1.Models.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public E_Arboles.Binary<string> Index;
        private readonly static Singleton _instance1 = new Singleton();
        public Client NewClient;
        private readonly static Singleton _instance2 = new Singleton();
        public ELineales.Lista<Medicine> ReStock;
        private readonly static Singleton _instance3 = new Singleton();
        public ELineales.Lista<Medicine> Medicine;
        private readonly static Singleton _instance4 = new Singleton();
        public ELineales.Lista<Medicine> Order;
        private Singleton()
        {
            Index = new E_Arboles.Binary<string>();
            NewClient = new Client();
            ReStock = new ELineales.Lista<Medicine>();
            Medicine = new ELineales.Lista<Medicine>();
        }
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
        public static Singleton Instance1
        {
            get
            {
                return _instance1;
            }
        }
        public static Singleton Instance2
        {
            get
            {
                return _instance2;
            }
        }
        public static Singleton Instance3
        {
            get
            {
                return _instance3;
            }
        }
        public static Singleton Instance4
        {
            get
            {
                return _instance4;
            }
        }
    }
}
