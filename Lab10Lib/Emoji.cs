using System;
using Input;
using System.Collections;

namespace Lab10Lib 
{
    public class IdNumber
    {
        public int number;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                if (number < 0)
                {
                    number = 0;
                }

            }
        }

        public IdNumber()
        {
            Number = 0;
        }
        public IdNumber(int n)
        {
            Number = n;
        }
        public override bool Equals(object obj)
        {
            return Number == ((IdNumber)obj).Number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }

    public class Emoji : IInit, IComparable, ICloneable
    {
        protected string name;
        protected string tag;
        public IdNumber id = new IdNumber();
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }
        public int Id
        {
            get
            {
                return id.Number;
            }
            set
            {
                id.Number = value;
            }
        }

        public Emoji()  // empty constructor
        {
            Name = "Пустая эмоция";
            Tag = "Empty";
        }
        public Emoji(string name, string tag)  // constructor w/ attributes
        {
            Name = name;
            Tag = tag;
        }
        public Emoji(Emoji emoji)  // copy constructor
        {
            Name = emoji.Name;
            Tag = emoji.Tag;
        }
        public Emoji(int idn, string name, string tag)  // constructor w/ id
        {
            id.Number = idn;
            Name = name;
            Tag = tag;
        }

        virtual public void Show()
        {
            Console.WriteLine($"Эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}");
        }
        public void SShow()
        {
            Console.WriteLine($"Эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}");
        }

        virtual public void Init()
        {
            Console.WriteLine("Введите название эмодзи:");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Введите тэг:");
            string tagInput = Console.ReadLine();

            Name = nameInput;
            Tag = tagInput;
        }

        virtual public void RandomInit()
        {
            Random rnd = new Random();
            int nameSize = rnd.Next(5, 15);
            string nameInput = "";
            for (int i = 0; i < nameSize; i++)
            {
                char letter = (char)rnd.Next(65, 123);
                nameInput += letter;
            }
            int tagSize = rnd.Next(5, 15);
            string tagInput = "";
            for (int i = 0; i < tagSize; i++)
            {
                char letter = (char)rnd.Next(1040, 1104);
                tagInput += letter;
            }

            Name = nameInput;
            Tag = tagInput;
        }

        override public bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not Emoji)
            {
                return false;
            }
            return Name == ((Emoji)obj).Name &&
                   Tag == ((Emoji)obj).Tag;
        }

        virtual public int CompareTo(object obj)
        {
            return String.Compare(Name, ((Emoji)obj).Name);
        }

        virtual public object Clone()
        {
            return new Emoji(this.id.Number, this.Name, this.Tag);
        }

        virtual public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

    }

    public class FaceEmoji: Emoji
    {
        protected string desc;
        protected int str;

        public string Desc
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }
        public int Str
        {
            get
            {
                return str;
            }
            set
            {
                if (str > 10)
                {
                    str = 10;
                }
                else if (str < 0)
                {
                    str = 0;
                }
                str = value;
            }
        }

        public FaceEmoji()
            : base()  // empty constructor
        {
            Desc = "-_-";
            Str = 0;
        }
        public FaceEmoji(string name, string tag, string desc, int str)
            : base(name, tag) // constructor w/ attributes
        {
            Desc = desc;
            Str = str;
        }
        public FaceEmoji(FaceEmoji emoji)
            : base(emoji)  // copy constructor
        {
            Desc = emoji.Desc;
            Str = emoji.Str;
        }
        public FaceEmoji(int idn, string name, string tag, string desc, int str)
            : base(idn, name, tag) // constructor w/ id
        {
            Desc = desc;
            Str = str;
        }

        override public void Show()
        {
            Console.WriteLine($"Лицевое эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}; описание: {Desc}; сила: {Str}");
        }
        public new void SShow()
        {
            Console.WriteLine($"Лицевое эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}; описание: {Desc}; сила: {Str}");
        }

        override public void Init()
        {
            Console.WriteLine("Введите название эмодзи:");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Введите тэг:");
            string tagInput = Console.ReadLine();
            Console.WriteLine("Введите описание эмодзи:");
            string descInput = Console.ReadLine();
            int strInput = CustomInput.IntInput(
                "Введите силу эмодзи (от 0 до 10):",
                lowerBoundary: -1,
                upperBoundary: 11);

            Name = nameInput;
            Tag = tagInput;
            Desc = descInput;
            Str = strInput;
        }

        override public void RandomInit()
        {
            Random rnd = new Random();
            char letter;
            int nameSize = rnd.Next(5, 15);
            string nameInput = "";
            for (int i = 0; i < nameSize; i++)
            {
                letter = (char)rnd.Next(65, 123);
                nameInput += letter;
            }

            int tagSize = rnd.Next(5, 15);
            string tagInput = "";
            for (int i = 0; i < tagSize; i++)
            {
                letter = (char)rnd.Next(1040, 1104);
                tagInput += letter;
            }

            int descSize = rnd.Next(1, 5);
            string descInput = "";
            for (int i = 0; i < descSize; i++)
            {
                letter = (char)rnd.Next(25, 41);
                descInput += letter;
            }

            int strInput = rnd.Next(0, 11);

            Name = nameInput;
            Tag = tagInput;
            Desc = descInput;
            Str = strInput;
        }

        override public bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not FaceEmoji)
            {
                return false;
            }
            return Name == ((FaceEmoji)obj).Name &&
                   Tag == ((FaceEmoji)obj).Tag &&
                   Desc == ((FaceEmoji)obj).Desc &&
                   Str == ((FaceEmoji)obj).Str;
        }
        override public object Clone()
        {
            return new FaceEmoji(this.id.Number, this.Name, this.Tag, this.Desc, this.Str);
        }
    }

    public class SmileEmoji : FaceEmoji
    {
        protected string reason;

        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                reason = value;
            }
        }

        public SmileEmoji()
            : base()  // empty constructor
        {
            Reason = "Нет причины";
        }
        public SmileEmoji(string name, string tag, string desc, int str, string reason)
            : base(name, tag, desc, str) // constructor w/ attributes
        {
            Reason = reason;
        }
        public SmileEmoji(SmileEmoji emoji)
            : base(emoji)  // copy constructor
        {
            Reason = emoji.Reason;
        }
        public SmileEmoji(int idn, string name, string tag, string desc, int str, string reason)
            : base(idn, name, tag, desc, str) // constructor w/ attributes
        {
            Reason = reason;
        }

        override public void Show()
        {
            Console.WriteLine($"Улыбающееся эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}; описание: {Desc}; сила: {Str}; причина улыбки: {Reason}");
        }
        public new void SShow()
        {
            Console.WriteLine($"Улыбающееся эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}; описание: {Desc}; сила: {Str}; причина улыбки: {Reason}");
        }

        override public void Init()
        {
            Console.WriteLine("Введите название эмодзи:");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Введите тэг:");
            string tagInput = Console.ReadLine();
            Console.WriteLine("Введите описание эмодзи:");
            string descInput = Console.ReadLine();
            int strInput = CustomInput.IntInput(
                "Введите силу эмодзи (от 0 до 10):",
                lowerBoundary: -1,
                upperBoundary: 11);
            Console.WriteLine("Введите причину улыбки:");
            string reasonInput = Console.ReadLine();

            Name = nameInput;
            Tag = tagInput;
            Desc = descInput;
            Str = strInput;
            Reason = reasonInput;
        }

        override public void RandomInit()
        {
            Random rnd = new Random();
            char letter;
            int nameSize = rnd.Next(5, 15);
            string nameInput = "";
            for (int i = 0; i < nameSize; i++)
            {
                letter = (char)rnd.Next(65, 123);
                nameInput += letter;
            }

            int tagSize = rnd.Next(5, 15);
            string tagInput = "";
            for (int i = 0; i < tagSize; i++)
            {
                letter = (char)rnd.Next(1040, 1104);
                tagInput += letter;
            }

            int descSize = rnd.Next(1, 5);
            string descInput = "";
            for (int i = 0; i < descSize; i++)
            {
                letter = (char)rnd.Next(65, 123);
                descInput += letter;
            }

            int strInput = rnd.Next(0, 11);

            int reasonSize = rnd.Next(10, 20);
            string reasonInput = "";
            for (int i = 0; i < reasonSize; i++)
            {
                letter = (char)rnd.Next(1040, 1104);
                reasonInput += letter;
            }


            Name = nameInput;
            Tag = tagInput;
            Desc = descInput;
            Str = strInput;
            Reason = reasonInput;
        }

        override public bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not SmileEmoji)
            {
                return false;
            }
            return Name == ((SmileEmoji)obj).Name &&
                   Tag == ((SmileEmoji)obj).Tag &&
                   Desc == ((SmileEmoji)obj).Desc &&
                   Str == ((SmileEmoji)obj).Str &&
                   Reason == ((SmileEmoji)obj).Reason;
        }

        override public object Clone()
        {
            return new SmileEmoji(this.id.Number, this.Name, this.Tag, this.Desc, this.Str, this.Reason);
        }
    }

    public class AnimalEmoji : Emoji
    {
        protected string animal;

        public string Animal
        {
            get
            {
                return animal;
            }
            set
            {
                animal = value;
            }
        }

        public AnimalEmoji()
            : base()  // empty constructor
        {
            Animal = "Ктулху";
        }
        public AnimalEmoji(string name, string tag, string animal)
            : base(name, tag) // constructor w/ attributes
        {
            Animal = animal;
        }
        public AnimalEmoji(AnimalEmoji emoji)
            : base(emoji)  // copy constructor
        {
            Animal = emoji.Animal;
        }
        public AnimalEmoji(int idn, string name, string tag, string animal)
            : base(idn, name, tag) // constructor w/ attributes
        {
            Animal = animal;
        }

        override public void Show()
        {
            Console.WriteLine($"Животное эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}; животное: {Animal}");
        }
        public new void SShow()
        {
            Console.WriteLine($"Животное эмодзи| Id: {Id}; название: {Name}; тэг: {Tag}; животное: {Animal}");
        }

        override public void Init()
        {
            Console.WriteLine("Введите название эмодзи:");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Введите тэг:");
            string tagInput = Console.ReadLine();
            Console.WriteLine("Введите животное, изображённое на эмодзи:");
            string animalInput = Console.ReadLine();;

            Name = nameInput;
            Tag = tagInput;
            Animal = animalInput;
        }

        override public void RandomInit()
        {
            Random rnd = new Random();
            char letter;
            int nameSize = rnd.Next(5, 15);
            string nameInput = "";
            for (int i = 0; i < nameSize; i++)
            {
                letter = (char)rnd.Next(65, 123);
                nameInput += letter;
            }
            int tagSize = rnd.Next(5, 15);
            string tagInput = "";
            for (int i = 0; i < tagSize; i++)
            {
                letter = (char)rnd.Next(1040, 1104);
                tagInput += letter;
            }
            int animalSize = rnd.Next(5, 15);
            string animalInput = "";
            for (int i = 0; i < animalSize; i++)
            {
                letter = (char)rnd.Next(1040, 1104);
                animalInput += letter;
            }

            int strInput = rnd.Next(0, 11);

            Name = nameInput;
            Tag = tagInput;
            Animal = animalInput;
        }

        override public bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not AnimalEmoji)
            {
                return false;
            }
            return Name == ((AnimalEmoji)obj).Name &&
                   Tag == ((AnimalEmoji)obj).Tag &&
                   Animal == ((AnimalEmoji)obj).Animal;
        }

        override public object Clone()
        {
            return new AnimalEmoji(this.id.Number, this.Name, this.Tag, this.Animal);
        }
    }

    public class Pokemon : IInit, IComparable
    {
        //  Constants for min/max Pokemon stats
        public const int minAttack = 17;
        public const int maxAttack = 414;
        public const int minDefense = 32;
        public const int maxDefense = 396;
        public const int minStamina = 1;
        public const int maxStamina = 496;

        private int attack;  // from 17 to 414
        private int defense;  // from 32 to 396
        private int stamina;  // from 1 to 496
        private static int pokemonCount = 0;  // amount of created Pokemon objects

        public int Attack  // attack property
        {
            get
            {
                return attack;
            }
            set
            {
                if (value < minAttack)
                {
                    attack = minAttack;
                    Console.WriteLine("Атака покемона стала ниже минимальной, округляем до минимальной");
                }
                else if (value > maxAttack)
                {
                    attack = maxAttack;
                    Console.WriteLine("Атака покемона превысила максимальную, округляем до максимальной");
                }
                else
                {
                    attack = value;
                }
            }
        }

        public int Defense // defense property
        {
            get
            {
                return defense;
            }
            set
            {
                if (value < minDefense)
                {
                    defense = minDefense;
                    Console.WriteLine("Защита покемона стала ниже минимальной, округляем до минимальной");
                }
                else if (value > maxDefense)
                {
                    defense = maxDefense;
                    Console.WriteLine("Защита покемона превысила максимальную, округляем до максимальной");
                }
                else
                {
                    defense = value;
                }
            }
        }

        public int Stamina  // stamina property
        {
            get
            {
                return stamina;
            }
            set
            {
                if (value < minStamina)
                {
                    stamina = minStamina;
                    Console.WriteLine("Выносливость покемона стала ниже минимальной, округляем до минимальной");
                }
                else if (value > maxStamina)
                {
                    stamina = maxStamina;
                    Console.WriteLine("Выносливость покемона превысила максимальную, округляем до максимальной");
                }
                else
                {
                    stamina = value;
                }
            }
        }
        public static int GetCount => pokemonCount;  // returns amount of created Pokemon objects

        public Pokemon()  // empty constructor
        {
            Attack = minAttack;
            Defense = minDefense;
            Stamina = minStamina;
            pokemonCount++;
        }

        public Pokemon(int attack, int defense, int stamina)    // constructor w/ attributes
        {
            Attack = attack;
            Defense = defense;
            Stamina = stamina;
            pokemonCount++;
        }

        public Pokemon(Pokemon pok)    // copy constructor
        {
            Attack = pok.Attack;
            Defense = pok.Defense;
            Stamina = pok.Stamina;
            pokemonCount++;
        }
        public static double operator ~(Pokemon pok)  // returns Pokemon power
        {
            return Math.Round(Math.Sqrt(pok.Stamina) * pok.Attack * Math.Sqrt(pok.Defense) / 10, 2);
        }
        public static Pokemon operator --(Pokemon pok)  // reduces stamina by 1
        {
            pok.Stamina--;
            return pok;
        }
        public static explicit operator int(Pokemon pok)  // returns sum of Pokemon stats
        {
            return pok.Attack + pok.Defense + pok.Stamina;
        }
        public static implicit operator double(Pokemon pok)  // returns the average of Pokemon stats
        {
            return Math.Round((double)(pok.Attack + pok.Defense + pok.Stamina) / 3, 2);
        }

        public static Pokemon operator >>(Pokemon pok, int num)  // Increases stamina by specified amount
        {
            pok.AddStats(0, 0, num);
            return pok;
        }
        public static Pokemon operator >(Pokemon pok, int num)  // Increases defense by specified amount
        {
            pok.AddStats(0, num, 0);
            return pok;
        }
        public static Pokemon operator <(Pokemon pok, int num)  // Increases attack by specified amount
        {
            pok.AddStats(num, 0, 0);
            return pok;
        }
        public Pokemon AddStats(int attack = 0, int defense = 0, int stamina = 0)  // Increases stamina by specified amount
        {
            Attack += attack;
            Defense += defense;
            Stamina += stamina;
            return this;
        }
        public override bool Equals(object? obj)
        {  // Checks if Pokemons have the same stats
            if (obj == null)
            {
                return false;
            }
            if (obj is not Pokemon)
            {
                return false;
            }
            return Attack == ((Pokemon)obj).Attack &&
                   Defense == ((Pokemon)obj).Defense &&
                   Stamina == ((Pokemon)obj).Stamina;
        }

        public void Show()  // Prints Pokemon stat summary
        {
            Console.WriteLine($"Покемон: Атака: {Attack}; Защита: {Defense}; Выносливость: {Stamina}");
        }

        public void Init()
        {
            int atk = CustomInput.IntInput($"Введите атаку покемона от {Pokemon.minAttack} до {Pokemon.maxAttack})",
                        lowerBoundary: Pokemon.minAttack,
                        upperBoundary: Pokemon.maxAttack);
            int def = CustomInput.IntInput($"Введите защиту покемона (от {Pokemon.minDefense} до {Pokemon.maxDefense})",
                lowerBoundary: Pokemon.minDefense,
                upperBoundary: Pokemon.maxDefense);
            int sta = CustomInput.IntInput($"Введите выносливость покемона (от {Pokemon.minStamina} до {Pokemon.maxStamina})",
                lowerBoundary: Pokemon.minStamina,
                upperBoundary: Pokemon.maxStamina);
            Attack = atk;
            Defense = def;
            Stamina = sta;
        }
        public void RandomInit()
        {
            Random rnd = new Random();
            int atk = rnd.Next(Pokemon.minAttack, Pokemon.maxAttack);
            int def = rnd.Next(Pokemon.minDefense, Pokemon.maxDefense);
            int sta = rnd.Next(Pokemon.minStamina, Pokemon.maxStamina);
            Attack = atk;
            Defense = def;
            Stamina = sta;
        }

        virtual public int CompareTo(object obj)
        {
            int stats = Attack + Defense + Stamina;
            int stats2 = ((Pokemon)obj).Attack + ((Pokemon)obj).Defense + ((Pokemon)obj).Stamina;
            if (stats < stats2)
            {
                return -1;
            }
            if (stats > stats2)
            {
                return 1;
            }
            return 0;
        }

        
    }

    public class SortByTag: IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            Emoji e1 = (Emoji)obj1;
            Emoji e2 = (Emoji)obj2;
            return String.Compare(e1.Tag, e2.Tag);
        }
    }


}
