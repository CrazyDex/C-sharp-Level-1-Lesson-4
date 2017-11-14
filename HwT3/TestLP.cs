using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;

namespace HwT3
{
    // ниже код подзасран лишними комментами с нерабочими частями кода
    // оставил их специально чтоб было понятней что я пытался сделать, и как...


    class TestLP
    {
        private static string ruser = "root";
        private static string rpassword = "GeekBrains";
        private static string[] lp = new string[2];
        private static string sessionLPFile = null;

        /// <summary>
        /// Real start
        /// </summary>
        public static void Start()
        {
            Console.Clear();
            short tryes = 3;
            string trystr = "";
            //string ruser = "1", rpassword = "1"; // "правильные" юзер и пас
            Console.Write("You try enter to the Forbidden Directory...\n");

            do
            {
                #region Проверка юзера
                Console.WriteLine(trystr);
                Console.Write("Input path to acces key: ");
                string path = Console.ReadLine();
                bool fileExistTest = true;
                try
                {
                    do
                    {
                        // проверка: существует ли файл
                        if (File.Exists(path))
                        {
                            FileInfo fi = new FileInfo(path);
                            // проверка: формат файла ключа
                            if (fi.Name.EndsWith(".myLPKey"))
                            {
                                lp = File.ReadAllLines(path);
                                // проверка: совпадение пары юзера и пассворда
                                if (lp[0] == ruser && lp[1] == rpassword)
                                {
                                    Loading();
                                    Console.WriteLine($"Hi \"{lp[0]}\"\n");
                                    System.Threading.Thread.Sleep(1000);
                                    sessionLPFile = path;
                                    Level1();
                                }
                                else
                                {
                                    fileExistTest = false;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("This file not a key. Try once again...\n");
                                Console.Write("Input path to acces key: ");
                                path = Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The key does not exist or the path is incorrectly entered. Try once again...\n");
                            Console.Write("Input path to acces key: ");
                            path = Console.ReadLine();
                        }
                    } while (fileExistTest);
                }
                catch (Exception) { }
                Console.Clear();
                trystr = $"Incorrect key. You have {--tryes} tryes\n";
                #endregion

                

                #region При проваленном входе
            } while (tryes != 0);
            if (tryes == 0)
            {
                Console.Beep(10000, 5000);
                while (true)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    System.Threading.Thread.Sleep(20);
                    Console.Write("WARNING!!!   ");
                }
            }
            #endregion
        }

        /// <summary>
        /// имитация загрузки
        /// </summary>
        private static void Loading()
        {
            Console.WriteLine("Loading...");
            System.Threading.Thread.Sleep(1000);
            Random random = new Random();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('\x2588');
                System.Threading.Thread.Sleep(random.Next(5, 300));
            }
            Console.Clear();
        }

        /// <summary>
        /// 1. Terminate system
        /// </summary>
        private static void TermSyst()
        {
            Random random = new Random();
            for (int i = 0; i < (Console.BufferHeight - 6); i++)
            {
                System.Threading.Thread.Sleep(20);
                Console.MoveBufferArea(0, i, random.Next(0, Console.BufferWidth), 2, random.Next(6), random.Next(20));

            }
            Console.Beep(10000, 3000);
            Environment.Exit(0);
        }

        /// <summary>
        /// 2. Spam world
        /// </summary>
        private static void SpW()
        {
            int i = 0;
            for (int k = 0; k < 25; k++)
            {
                Console.Clear();
                Console.WriteLine("| Start sending virus XdheH4.sa.45(0a) to everybody on the planet");
                System.Threading.Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine("/ Start sending virus XdheH4.sa.45(0a) to everybody on the planet");
                System.Threading.Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine("- Start sending virus XdheH4.sa.45(0a) to everybody on the planet");
                System.Threading.Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine("\\ Start sending virus XdheH4.sa.45(0a) to everybody on the planet");
                System.Threading.Thread.Sleep(30);
            }
            Random random = new Random();
            while (random.Next(100) != 0)
            {
                i++;
                Console.Clear();
                Console.WriteLine("| Sent succesful {0}", i);
                System.Threading.Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine("/ Sent succesful {0}", i);
                System.Threading.Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine("- Sent succesful {0}", i);
                System.Threading.Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine("\\ Sent succesful {0}", i);
                System.Threading.Thread.Sleep(30);
            }
            Console.WriteLine("Something going wrong!\n\n1. For extrim terminate system\nAny another to return");
            if (Console.ReadLine() == "1") { TermSyst(); }
            else { Level1(); }
        }

        /// <summary>
        /// 3. Humor
        /// </summary>
        private static void Hum()
        {
            Console.Clear();
            Console.WriteLine("If you're having a bad day, don't be sad. Be like an unsigned integer...");
            Console.ReadKey();
            Console.WriteLine("\n...Stay positive.");
            System.Threading.Thread.Sleep(5000);
            Console.Write("\nPress any key to return and start working!");
            Console.ReadKey();
            Level1();
        }

        /// <summary>
        /// 4. Profile
        /// </summary>
        private static void Prof()
        {
            bool b = true;
            string s = "";
            Console.Clear();
            Console.WriteLine("1. Change username\n2. Return");
            while (b)
            {
                s = Console.ReadLine();
                b = (s == "1") || (s == "2") ? false : true;
            }
            if (s == "1")
            {
                Console.Clear();
                Console.Write("New username: ");
                ruser = lp[0] = Console.ReadLine();
                //lp[0] = ruser;
                char[] ch = { '.', 'm', 'y', 'L', 'P', 'K', 'e', 'y' };
                string temp = sessionLPFile.TrimEnd(ch);
                //File.Move(sessionLPFile, temp + ".txt");
                //File.WriteAllLines(temp + ".txt", lp);
                //File.Move(temp + ".txt", sessionLPFile);
                //StreamWriter streamWriter = new StreamWriter(sessionLPFile);
                //streamWriter.WriteLineAsync(lp[0]);
                //streamWriter.Close();
                //File.WriteAllLines (sessionLPFile, lp);
                Console.Clear();
                ChangeKeyFile();
                Console.WriteLine("Username change succesful");
                Console.WriteLine("Key file change succesful");
                Console.ReadLine();
                Prof();
            }
            else { Level1(); }
        }

        private static void ChangeKeyFile()
        {
            //try
            //{
                File.Delete(sessionLPFile);
                File.WriteAllLines(sessionLPFile, lp);
            //    //File.WriteAllLines(@"C:\testsharp\1.myLPKe", lp);
            //    //File.Move(@"C:\testsharp\1.myLPKe", @"C:\testsharp\1.myLPKey");
            //    //File.WriteAllLines(sessionLPFile, lp);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(File.GetAttributes(sessionLPFile));
            //    Console.WriteLine();
            //    Console.WriteLine(File.GetAccessControl(sessionLPFile));
            //    Console.WriteLine();
            //    Console.WriteLine(e.Message);
            //    Console.ReadLine();
            //}
            //finally
            //{
            //    Console.WriteLine("\nfinally\n");
                
            //    //File.SetAccessControl(sessionLPFile, FileSecurity)
            //    //File.SetAttributes(sessionLPFile, FileAttributes.Normal);
            //    Console.WriteLine(File.GetAttributes(sessionLPFile));
            //    Console.WriteLine();
            //    Console.WriteLine(File.GetAccessControl(sessionLPFile));
            //    Console.WriteLine();
            //    Console.ReadLine();

            //}

        }

        /// <summary>
        /// 5. Security
        /// </summary>
        private static void Sec()
        {
            bool b = true;
            string s = "";
            Console.Clear();
            Console.WriteLine("1. Change password\n2. Return");
            while (b)
            {
                s = Console.ReadLine();
                b = (s == "1") || (s == "2") ? false : true;
            }
            if (s == "1")
            {
                Console.Clear();
                Console.Write("New password: ");
                Console.ForegroundColor = ConsoleColor.Black;
                rpassword = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
                ChangeKeyFile();
                Console.WriteLine("Password change succesful");
                Console.WriteLine("Key file change succesful");
                Console.ReadLine();
                Sec();
            }
            else { Level1(); }
        }

        /// <summary>
        /// 6. Exit
        /// </summary>
        private static void Ex()
        {
            Start();
        }

        /// <summary>
        /// Main menu
        /// </summary>
        private static void Level1()
        {
            Console.Clear();
            short switchBut = 0;
            Console.WriteLine("1. Terminate system\n2. Spam world\n3. Humor\n4. Profile\n5. Security\n6. Exit");
            short.TryParse(Console.ReadLine(), out switchBut);
            switch (switchBut)
            {
                case 1: TermSyst(); break;
                case 2: SpW(); break;
                case 3: Hum(); break;
                case 4: Prof(); break;
                case 5: Sec(); break;
                case 6: Ex(); break;
                default: Level1(); break;
            }
        }
    }
}
