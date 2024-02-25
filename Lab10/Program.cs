using System;
using Lab10Lib;
using Input;
using System.Text.RegularExpressions;

namespace Lab10
{
    class Program
    {
        static void StrongestEmoji(Emoji[] emojiArr)
        {
            int maxStr = 0;
            Emoji ans = emojiArr[0];
            bool smileFound = false;
            foreach (var emoji in emojiArr)
            {
                if (emoji is FaceEmoji && ((FaceEmoji)emoji).Str > maxStr)
                {
                    maxStr = ((FaceEmoji)emoji).Str;
                    ans = (FaceEmoji)emoji;
                    smileFound = true;
                }
            }
            if (smileFound)
            {
                ans.Show();
            }
            else
            {
                Console.WriteLine("Эмоцию с показателем силы найти не удалось. Возвращен первый элемент массива");
            }
        }

        static void AnimalEmojiTags(Emoji[] emojiArr)
        {
            string[] tags = new string[emojiArr.Length];
            int index = 0;
            bool animalFound = false;
            foreach (Emoji emoji in emojiArr)
            {
                AnimalEmoji animal = emoji as AnimalEmoji;
                if (animal != null)
                {
                    tags[index] = animal.Tag;
                    index++;
                    animalFound = true;
                }
            }
            Console.WriteLine("Теги животных:");
            if (animalFound)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (tags[i] != null)
                    {
                        Console.WriteLine(tags[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Эмодзи-животные не были найдены");
            }
        }

        static void SmilingReasons(Emoji[] emojiArr, int str)
        {
            string[] reasons = new string[emojiArr.Length];
            int index = 0;
            bool smileFound = false;
            foreach (Emoji emoji in emojiArr)
            {
                if (typeof(SmileEmoji) == emoji.GetType() && ((SmileEmoji)emoji).Str >= str)
                {
                    reasons[index] = ((SmileEmoji)emoji).Reason;
                    index++;
                    smileFound = true;
                }
            }
            Console.WriteLine("Причины:");
            if (smileFound)
            {
                for (int i = 0; i < reasons.Length; i++)
                {
                    if (reasons[i] != null)
                    {
                        Console.WriteLine(reasons[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Смайлы с соответствующим уровнем силы не были найдены");
            }
        }

        static void FillArray(Emoji[] emojiArr, int cnt1, int cnt2, int cnt3, int cnt4)
        {
            // Filling array

            for (int i = 0; i < emojiArr.Length; i++)
            {
                if (i < cnt1)
                {
                    emojiArr[i] = new Emoji();
                    emojiArr[i].RandomInit();
                }
                else if (i - cnt1 < cnt2)
                {
                    emojiArr[i] = new FaceEmoji();
                    emojiArr[i].RandomInit();
                }
                else if (i - cnt1 - cnt2 < cnt3)
                {
                    emojiArr[i] = new SmileEmoji();
                    emojiArr[i].RandomInit();
                }
                else if (i - cnt1 - cnt2 - cnt3 < cnt4)
                {
                    emojiArr[i] = new AnimalEmoji();
                    emojiArr[i].RandomInit();
                }
                else
                {
                    emojiArr[i] = new Emoji();
                    emojiArr[i].RandomInit();
                }
            }
        }

        static void PrintMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(menu[i]);
            }
        }
        static void Main(string[] args)
        {
            string[] mainMenu = {
                "----------------------------------------------------------------------",
                "Выберите действие:",
                "1  Создать массив эмодзи (20 элементов)",
                "2  Напечатать массив",
                "3  Выбрать эмодзи из массива",
                "4  Самое сильное эмодзи",
                "5  Теги всех животных эмодзи",
                "6  Причины улыбающихся эмодзи с силой не менее заданной",
                "7  Отсортировать массив по имени",
                "8  Сформировать массив интерфейса (25 элементов)",
                "9  Разпечатать массив интерфейса",
                "10  Бинарный поиск 1",
                "11  Отсортировать по тэгу",
                "12  Бинарный поиск 2",
                "13  Глубокое копирование",
                "14  Поверхностное копирование",
                "0  Выход"
            };
            string[] functionMenu = {
                "----------------------------------------------------------------------",
                "Выберите действие:",
                "1  Метод",
                "2  Функция",
                "0  Назад"
            };
            string[] emojiMenu = {
                "----------------------------------------------------------------------",
                "Выберите действие:",
                "1  Напечатать информацию об эмодзи",
                "2  Ввести параметры эмодзи с клавиатуры",
                "3  Ввести параметры эмодзи с помощью ГСЧ",
                "0  Назад"
            };
            Emoji[] emojiArray = new Emoji[20];
            Emoji chosenEmoji;
            Emoji input;
            bool arrayCreated = false;
            bool interfaceArrayCreated = false;
            string menuInput = "-1";
            IInit[] interfaceArr = new IInit[25];
            while (menuInput != "0")
            {
                PrintMenu(mainMenu);
                menuInput = Console.ReadLine();
                if ((Regex.IsMatch(menuInput, "^[2-6]$") || Regex.IsMatch(menuInput, "^[1][1-2]$")) && !arrayCreated)
                {
                    Console.WriteLine("Массив эмодзи не создан");
                }
                else if (Regex.IsMatch(menuInput, "^[9]$") && !interfaceArrayCreated)
                {
                    Console.WriteLine("Массив интерфейса не создан");
                }
                else
                {
                    switch (menuInput)
                    {
                        case "1":
                            int cnt1 = CustomInput.IntInput(
                                "Сколько Emoji в массиве? (от 0 до 20)",
                                lowerBoundary: -1,
                                upperBoundary: 21);
                            int cnt2 = CustomInput.IntInput(
                                "Сколько FaceEmoji в массиве? (от 0 до 20)",
                                lowerBoundary: -1,
                                upperBoundary: 21);
                            int cnt3 = CustomInput.IntInput(
                                "Сколько SmileEmoji в массиве? (от 0 до 20)",
                                lowerBoundary: -1,
                                upperBoundary: 21);
                            int cnt4 = CustomInput.IntInput(
                                "Сколько AnimalEmoji в массиве? (от 0 до 20)",
                                lowerBoundary: -1,
                                upperBoundary: 21);
                            FillArray(emojiArray, cnt1, cnt2, cnt3, cnt4);
                            arrayCreated = true;
                            break;

                        case "2":
                            // Printing array
                            for (int i = 0; i < 20; i++)
                            {
                                Console.Write($"[{i + 1}] ");
                                emojiArray[i].Show();
                            }
                            break;

                        case "3":
                            int index = CustomInput.IntInput(
                                "Введите номер эмодзи (от 1 до 20)",
                                lowerBoundary: 0,
                                upperBoundary: 21) - 1;
                            Emoji chosenEmo = emojiArray[index];
                            Console.WriteLine("Выбранное эмодзи:");
                            chosenEmo.Show();
                            bool showFinished;
                            while (menuInput != "0")
                            {
                                PrintMenu(emojiMenu);
                                menuInput = Console.ReadLine();
                                switch (menuInput)
                                {
                                    case "1":
                                        showFinished = false;
                                        while (menuInput != "0" && !showFinished)
                                        {
                                            PrintMenu(functionMenu);
                                            menuInput = Console.ReadLine();
                                            switch (menuInput)
                                            {
                                                case "1":
                                                    chosenEmo.Show();
                                                    showFinished = true;
                                                    break;

                                                case "2":
                                                    chosenEmo.SShow();
                                                    showFinished = true;
                                                    break;

                                                case "0":
                                                    break;
                                                default:
                                                    Console.WriteLine("Ошибка: такого пункта меню не существует");
                                                    break;
                                            }
                                        }
                                        menuInput = "-1";
                                        break;

                                    case "2":
                                        chosenEmo.Init();
                                        break;

                                    case "3":
                                        chosenEmo.RandomInit();
                                        break;

                                    case "0":
                                        break;

                                    default:
                                        Console.WriteLine("Ошибка: такого пункта меню не существует");
                                        break;

                                }
                            }
                            menuInput = "-1";
                            break;  

                        case "4":
                            StrongestEmoji(emojiArray);
                            break;

                        case "5":
                            AnimalEmojiTags(emojiArray);
                            break;

                        case "6":
                            int str = CustomInput.IntInput(
                                "Введите нужную силу (от 0 до 10)",
                                lowerBoundary: -1,
                                upperBoundary: 11);
                            SmilingReasons(emojiArray, str);
                            break;

                        case "7":

                            Array.Sort(emojiArray);
                            break;

                        case "8":
                            for (int i = 0; i < 5; i++)
                            {
                                interfaceArr[i] = new Emoji();
                                interfaceArr[i].RandomInit();
                            }
                            for (int i = 5; i < 10; i++)
                            {
                                interfaceArr[i] = new FaceEmoji();
                                interfaceArr[i].RandomInit();
                            }
                            for (int i = 10; i < 15; i++)
                            {
                                interfaceArr[i] = new SmileEmoji();
                                interfaceArr[i].RandomInit();
                            }
                            for (int i = 15; i < 20; i++)
                            {
                                interfaceArr[i] = new AnimalEmoji();
                                interfaceArr[i].RandomInit();
                            }
                            for (int i = 20; i < 25; i++)
                            {
                                interfaceArr[i] = new Pokemon();
                                interfaceArr[i].RandomInit();
                            }
                            interfaceArrayCreated = true;
                            break;

                        case "9":
                            int cntEmoji = 0;
                            int cntFace = 0;
                            int cntSmile = 0;
                            int cntAnimal = 0;
                            int cntPokemon = 0;
                            for (int i = 0; i < interfaceArr.Length; i++)
                            {
                                if (interfaceArr[i] is Pokemon)
                                {
                                    ((Pokemon)interfaceArr[i]).Show();
                                    cntPokemon++;
                                }
                                else if (interfaceArr[i] is AnimalEmoji)
                                {
                                    ((AnimalEmoji)interfaceArr[i]).Show();
                                    cntAnimal++;
                                }
                                else if (interfaceArr[i] is SmileEmoji)
                                {
                                    ((SmileEmoji)interfaceArr[i]).Show();
                                    cntSmile++;
                                }
                                else if (interfaceArr[i] is FaceEmoji)
                                {
                                    ((FaceEmoji)interfaceArr[i]).Show();
                                    cntFace++;
                                }
                                else if (interfaceArr[i] is Emoji)
                                {
                                    ((Emoji)interfaceArr[i]).Show();
                                    cntEmoji++;
                                }
                            }
                            Console.WriteLine($"Количество объектов Emoji: " +
                                    $"{cntEmoji}; FaceEmoji: {cntFace}; SmileEmoji: {cntSmile}; Pokemon: {cntPokemon}");
                            break;

                        case "10":
                            Array.Sort(emojiArray);
                            input = emojiArray[6];
                            int res = Array.BinarySearch(emojiArray, input);
                            if (res >= 0)
                            {
                                Console.WriteLine($"Элемент найден на позиции {res}");
                            }
                            else
                            {
                                Console.WriteLine($"Элемент не найден");
                            }
                            break;

                        case "11":
                            Array.Sort(emojiArray, new SortByTag());
                            break;

                        case "12":
                            Array.Sort(emojiArray, new SortByTag());
                            input = emojiArray[8];
                            int res2 = Array.BinarySearch(emojiArray, input, new SortByTag());
                            if (res2 >= 0)
                            {
                                Console.WriteLine($"Элемент найден на позиции {res2}");
                            }
                            else
                            {
                                Console.WriteLine($"Элемент не найден");
                            }
                            break;

                        case "13":
                            Emoji e1 = new Emoji(1, "abc", "123");
                            FaceEmoji e2 = new FaceEmoji(2, "a", "123", "qwerty", 5);
                            SmileEmoji e3 = new SmileEmoji(-5, "b", "123", "qwerty", 5, "");
                            AnimalEmoji e4 = new AnimalEmoji(3, "b", "123", "bear");
                            Emoji re1 = (Emoji)e1.Clone();
                            FaceEmoji re2 = (FaceEmoji)e2.Clone();
                            SmileEmoji re3 = (SmileEmoji)e3.Clone();
                            AnimalEmoji re4 = (AnimalEmoji)e4.Clone();

                            e1.Id = 100;
                            e2.Id = 200;
                            e3.Id = 300;
                            e4.Id = 400;

                            Console.WriteLine("Emoji оригинал:");
                            e1.Show();
                            Console.WriteLine("Emoji копия:");
                            re1.Show();
                            Console.WriteLine("FaceEmoji оригинал:");
                            e2.Show();
                            Console.WriteLine("FaceEmoji копия:");
                            re2.Show();
                            Console.WriteLine("SmileEmoji оригинал:");
                            e3.Show();
                            Console.WriteLine("SmileEmoji копия:");
                            re3.Show();
                            Console.WriteLine("AnimalEmoji оригинал:");
                            e4.Show();
                            Console.WriteLine("AnimalEmoji копия:");
                            re4.Show();




                            break;

                        case "14":
                            Emoji se1 = new Emoji(1, "abc", "123");
                            FaceEmoji se2 = new FaceEmoji(2, "a", "123", "qwerty", 5);
                            SmileEmoji se3 = new SmileEmoji(-5, "b", "123", "qwerty", 5, "");
                            AnimalEmoji se4 = new AnimalEmoji(3, "b", "123", "bear");
                            Emoji sre1 = (Emoji)se1.ShallowCopy();
                            FaceEmoji sre2 = (FaceEmoji)se2.ShallowCopy();
                            SmileEmoji sre3 = (SmileEmoji)se3.ShallowCopy();
                            AnimalEmoji sre4 = (AnimalEmoji)se4.ShallowCopy();

                            se1.Id = 100;
                            se2.Id = 200;
                            se3.Id = 300;
                            se4.Id = 400;

                            Console.WriteLine("Emoji оригинал:");
                            se1.Show();
                            Console.WriteLine("Emoji копия:");
                            sre1.Show();
                            Console.WriteLine("FaceEmoji оригинал:");
                            se2.Show();
                            Console.WriteLine("FaceEmoji копия:");
                            sre2.Show();
                            Console.WriteLine("SmileEmoji оригинал:");
                            se3.Show();
                            Console.WriteLine("SmileEmoji копия:");
                            sre3.Show();
                            Console.WriteLine("AnimalEmoji оригинал:");
                            se4.Show();
                            Console.WriteLine("AnimalEmoji копия:");
                            sre4.Show();
                            break;


                        case "0":
                            break;

                        default:
                            Console.WriteLine("Ошибка: такого пункта меню не существует");
                            break;
                    }
                }
            }
        }
    }
}
