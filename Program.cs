using System;

abstract class Transport//создание абстрактного класса
{
    public string marka;
    public string nomer;
    public int skorost;
    public double gruz;

    public abstract void ShowInfo();// создание абстрактного метода
    public virtual double GetGruz()
    {
        return gruz;
    }
    public int Compare(Transport other)
    {
        return this.GetGruz().CompareTo(other.GetGruz());//создания 
    }
}

class Car : Transport
{
    public Car(string m, string n, int s, double g)
    {
        marka = m;
        nomer = n;
        skorost = s;
        gruz = g;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Авто: {marka}, Номер: {nomer}, Скорость: {skorost}, Груз: {GetGruz()} кг");
    }
}

class Motorbike : Transport
{
    public bool kolyaska;

    public Motorbike(string m, string n, int s, double g, bool k)
    {
        marka = m;
        nomer = n;
        skorost = s;
        gruz = g;
        kolyaska = k;
    }

    public override double GetGruz()
    {
        if (!kolyaska) return 0;
        return gruz;
    }

    public override void ShowInfo()
    {
        string k = kolyaska ? "с коляской" : "без коляски";
        Console.WriteLine($"Мото: {marka}, Номер: {nomer}, Скорость: {skorost}, {k}, Груз: {GetGruz()} кг");
    }
}

class Truck : Transport
{
    public bool pricep;

    public Truck(string m, string n, int s, double g, bool p)
    {
        marka = m;
        nomer = n;
        skorost = s;
        gruz = g;
        pricep = p;
    }

    public override double GetGruz()
    {
        if (pricep) return gruz * 2;
        return gruz;
    }

    public override void ShowInfo()
    {
        string p = pricep ? "с прицепом" : "без прицепа";
        Console.WriteLine($"Грузовик: {marka}, Номер: {nomer}, Скорость: {skorost}, {p}, Груз: {GetGruz()} кг");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("База транспорта");
        Console.Write("Сколько транспорта добавить? ");
        int n = int.Parse(Console.ReadLine());

        Transport[] baza = new Transport[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nТранспорт" + (i + 1)+":");

            Console.Write("Тип (1-авто, 2-мото, 3-грузовик): ");
            int tip = int.Parse(Console.ReadLine());

            Console.Write("Марка: ");
            string marka = Console.ReadLine();

            Console.Write("Номер: ");
            string nomer = Console.ReadLine();

            Console.Write("Скорость: ");
            int skorost = int.Parse(Console.ReadLine());

            Console.Write("Грузоподъемность: ");
            double gruz = double.Parse(Console.ReadLine());

            if (tip == 1)
            {
                baza[i] = new Car(marka, nomer, skorost, gruz);
            }
            else if (tip == 2)
            {
                Console.Write("Есть коляска?(1-да, 0-нет): ");
                bool kolyaska = Console.ReadLine() == "1";
                baza[i] = new Motorbike(marka, nomer, skorost, gruz, kolyaska);
            }
            else if (tip == 3)
            {
                Console.Write("Есть прицеп?(1-да, 0-нет): ");
                bool pricep = Console.ReadLine() == "1";
                baza[i] = new Truck(marka, nomer, skorost, gruz, pricep);
            }
        }

        Console.WriteLine("\nВесь транспорт:");
        foreach (Transport t in baza)
        {
            t.ShowInfo();
        }
        for (int i = 0; i < baza.Length - 1; i++)
        {
            for (int j = i + 1; j < baza.Length; j++)
            {
                if (baza[i].Compare(baza[j]) > 0)
                {
                    Transport temp = baza[i];
                    baza[i] = baza[j];
                    baza[j] = temp;
                }
            }
        }
        Console.WriteLine("\nОтсортировано по грузоподъемности:");
        foreach (Transport t in baza)
        {
            t.ShowInfo();
        }
        Console.Write("\nВведите нужную грузоподъемность: ");
        double need = double.Parse(Console.ReadLine());

        Console.WriteLine($"Транспорт с грузоподъемностью >= {need}:");
        bool found = false;
        foreach (Transport t in baza)
        {
            if (t.GetGruz() >= need)
            {
                t.ShowInfo();
                found = true;
            }
        }
        //руцаррораоцрорацоадоцао лцлолаоцлоао

        if (!found)
        {
            Console.WriteLine("Не найдено");
        }
    }
}