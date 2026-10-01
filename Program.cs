using System;

namespace OOP_Lab6
{
    // Базовий клас
    class Plant
    {
        // Приватні поля
        private string _name;
        private double _height;

        // Публічні властивості
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // Конструктор базового класу
        public Plant(string name, double height)
        {
            Name = name;
            Height = height;
        }

        // Віртуальний метод
        public virtual void Grow()
        {
            Console.WriteLine($"Рослина {Name} росте. Висота: {Height} м.");
        }

        // Метод для демонстрації new
        public string GetPlantType()
        {
            return "Це рослина.";
        }
    }

    // Похідний клас Tree
    class Tree : Plant
    {
        // Унікальна властивість дерева
        public double TrunkDiameter { get; set; }

        // Конструктор Tree викликає конструктор Plant
        public Tree(string name, double height, double trunkDiameter)
            : base(name, height)
        {
            TrunkDiameter = trunkDiameter;
        }

        // Перевизначення virtual-методу
        public override void Grow()
        {
            Console.WriteLine(
                $"Дерево {Name} росте. Висота: {Height} м, " +
                $"діаметр стовбура: {TrunkDiameter} см."
            );
        }

        // Унікальний метод Tree
        public void ShedLeaves()
        {
            Console.WriteLine($"Дерево {Name} скидає листя.");
        }

        // Демонстрація new
        public new string GetPlantType()
        {
            return "Це дерево.";
        }
    }

    // Похідний клас Flower
    class Flower : Plant
    {
        // Унікальна властивість квітки
        public string PetalColor { get; set; }

        // Конструктор Flower викликає конструктор Plant
        public Flower(string name, double height, string petalColor)
            : base(name, height)
        {
            PetalColor = petalColor;
        }

        // Перевизначення virtual-методу
        public override void Grow()
        {
            Console.WriteLine(
                $"Квітка {Name} росте. Висота: {Height} м, " +
                $"колір пелюсток: {PetalColor}."
            );
        }

        // Унікальний метод Flower
        public void Bloom()
        {
            Console.WriteLine(
                $"Квітка {Name} розквітає. Колір пелюсток: {PetalColor}."
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Лабораторна робота №6 ===");
            Console.WriteLine("Ієрархія класів Plant → Tree → Flower");
            Console.WriteLine();

            // Створення об'єкта базового класу
            Plant plant = new Plant("Звичайна рослина", 0.5);

            // Створення об'єктів похідних класів
            Tree tree = new Tree("Дуб", 10.5, 45);
            Flower flower = new Flower("Троянда", 0.8, "червоний");

            // ==========================================
            // 1. Виклик методів об'єкта Plant
            // ==========================================

            Console.WriteLine("--- Базовий клас Plant ---");

            plant.Grow();

            Console.WriteLine(plant.GetPlantType());

            Console.WriteLine();

            // ==========================================
            // 2. Поліморфізм
            // ==========================================

            Console.WriteLine("--- Поліморфізм ---");

            Plant plantTree = tree;
            Plant plantFlower = flower;

            // Викликаються перевизначені методи
            plantTree.Grow();
            plantFlower.Grow();

            Console.WriteLine();

            // ==========================================
            // 3. Унікальні методи похідних класів
            // ==========================================

            Console.WriteLine("--- Унікальні методи ---");

            tree.ShedLeaves();
            flower.Bloom();

            Console.WriteLine();

            // ==========================================
            // 4. Демонстрація override та new
            // ==========================================

            Console.WriteLine("--- Демонстрація override та new ---");

            // Посилання типу Tree
            Console.WriteLine("tree.GetPlantType():");
            Console.WriteLine(tree.GetPlantType());

            // Посилання типу Plant
            Console.WriteLine("\nplantTree.GetPlantType():");
            Console.WriteLine(plantTree.GetPlantType());

            Console.WriteLine();

            // ==========================================
            // 5. Демонстрація властивостей
            // ==========================================

            Console.WriteLine("--- Властивості об'єктів ---");

            Console.WriteLine($"Назва дерева: {tree.Name}");
            Console.WriteLine($"Висота дерева: {tree.Height} м");
            Console.WriteLine($"Діаметр стовбура: {tree.TrunkDiameter} см");

            Console.WriteLine();

            Console.WriteLine($"Назва квітки: {flower.Name}");
            Console.WriteLine($"Висота квітки: {flower.Height} м");
            Console.WriteLine($"Колір пелюсток: {flower.PetalColor}");

            Console.WriteLine();

            Console.WriteLine("=== Завершення програми ===");
        }
    }
}