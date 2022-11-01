using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;


#region
/* User Manual
 1.Выход exit
*/
#endregion





namespace StudentDB
{


    internal class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["StudentsDB"].ConnectionString;
        public static SqlConnection sqlConnection = null;

        static void Main(string[] args)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("StudentsApp");
            SqlDataReader sqlDataReader = null;

            string command = string.Empty;
            while (true)
            {
                try
                {
                    Console.Write("> ");
                    //считывание команды
                    command = Console.ReadLine();
                    #region Exit
                    //если пользователь вводит команду exit, то программа закрывается
                    if (command.ToLower().Equals("exit"))
                    {
                        //закрытие подключение с БД
                        if (sqlConnection.State == ConnectionState.Open)
                        {
                            sqlConnection.Close();
                        }
                        if (sqlDataReader != null)
                        {
                            sqlDataReader.Close();
                        }
                        break;
                    }

                    #endregion
                    #region Clear
                    if (command.ToLower().Equals("clear"))
                    {
                        Console.Clear();
                        continue;
                    }
                    #endregion
                    //разобьем команду на подстроки
                    SqlCommand sqlCommand = null;
                    string[] commandArray = command.ToLower().Split(' ');

                    switch (commandArray[0])
                    {

                        case "insert":
                            sqlCommand = new SqlCommand(command, sqlConnection);
                            //выввод данных
                            Console.WriteLine($"Добавлено: {sqlCommand.ExecuteNonQuery()} строк(а)");
                            break;
                        case "update":
                            sqlCommand = new SqlCommand(command, sqlConnection);
                            //обновление данных
                            Console.WriteLine($"Изменено: {sqlCommand.ExecuteNonQuery()} строк(а)");
                            break;


                        case "delete":
                            sqlCommand = new SqlCommand(command, sqlConnection);
                            //удаление данных
                            Console.WriteLine($"Удалено: {sqlCommand.ExecuteNonQuery()} строк(а)");
                            break;
                        case "search":
                            //поиск по фамилии
                            if (commandArray[1].Equals("fio"))
                            {
                                sqlCommand = new SqlCommand($"SELECT * FROM [Students] WHERE FIO LIKE N'%{commandArray[2]}%'", sqlConnection);
                            }
                            //поиск по дате рождения
                            else if (commandArray[1].Equals("birthday"))
                            {
                                sqlCommand = new SqlCommand($"SELECT * FROM [Students] WHERE BIRTHDAY = '{commandArray[2]}'", sqlConnection);
                            }
                            else
                            {
                                Console.WriteLine($"Аргумент {commandArray[1]} некорректен!");
                            }
                            try
                            {
                                sqlDataReader = sqlCommand.ExecuteReader();
                                while (sqlDataReader.Read())
                                {
                                    //вывод данных из таблицы
                                    Console.WriteLine($"{sqlDataReader["Id"]} {sqlDataReader["FIO"]}" +
                                    $"{sqlDataReader["Birthday"]} {sqlDataReader["University"]}" +
                                    $"{sqlDataReader["Group_number"]} {sqlDataReader["Course"]}{sqlDataReader["Average_score"]}");
                                    Console.WriteLine(new string('-', 30));
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                            finally
                            {
                                //закрытие sqlDataReader
                                if (sqlDataReader != null)
                                {
                                    sqlDataReader.Close();
                                }
                            }
                            break;
                        case "min":
                            sqlCommand = new SqlCommand("SELECT MIN(Average_score) FROM [Students]", sqlConnection);
                            Console.WriteLine($"Минимальный средний балл: {sqlCommand.ExecuteScalar()}");
                            break;
                        case "max":
                            sqlCommand = new SqlCommand("SELECT MAX(Average_score) FROM [Students]", sqlConnection);
                            Console.WriteLine($"Максимальный средний балл: {sqlCommand.ExecuteScalar()}");
                            break;
                        case "avg":
                            sqlCommand = new SqlCommand("SELECT AVG(Average_score) FROM [Students]", sqlConnection);
                            Console.WriteLine($"Среднее значение по колонке 'Средний балл': {sqlCommand.ExecuteScalar()}");
                            break;
                        case "sum":
                            sqlCommand = new SqlCommand("SELECT MIN(Average_score) FROM [Students]", sqlConnection);
                            Console.WriteLine($"Сумма всех баллов: {sqlCommand.ExecuteScalar()}");
                            break;

                        case "sortby":
                            // sortby fio asc
                            sqlCommand = new SqlCommand($"SELECT * FROM [Students] ORDER BY fio", sqlConnection);
                            sqlDataReader = sqlCommand.ExecuteReader();
                            while (sqlDataReader.Read())
                            {
                                //вывод данных из таблицы
                                Console.WriteLine($"{sqlDataReader["Id"]} {sqlDataReader["FIO"]}" +
                                $"{sqlDataReader["Birthday"]} {sqlDataReader["University"]}" +
                                $"{sqlDataReader["Group_number"]} {sqlDataReader["Course"]}{sqlDataReader["Average_score"]}");
                                //отделение ----------- после каждой записи
                                Console.WriteLine(new string('-', 30));
                            }
                            //закрытие sqlDataReader
                            if (sqlDataReader != null)
                            {
                                sqlDataReader.Close();
                            }
                            break;

                        case "select":
                            sqlCommand = new SqlCommand(command, sqlConnection);
                            sqlDataReader = sqlCommand.ExecuteReader();
                            while (sqlDataReader.Read())
                            {
                                //вывод данных из таблицы
                                Console.WriteLine($"{sqlDataReader["Id"]} {sqlDataReader["FIO"]}" +
                                $"{sqlDataReader["Birthday"]} {sqlDataReader["University"]}" + $"{sqlDataReader["Group_number"]} {sqlDataReader["Course"]}{sqlDataReader["Average_score"]}");
                                //отделение ----------- после каждой записи
                                Console.WriteLine(new string('-', 30));
                            }
                            //закрытие sqlDataReader
                            if (sqlDataReader != null)
                            {
                                sqlDataReader.Close();
                            }
                            break;

                        default:
                            Console.WriteLine($"Команда {command} некорректна!");
                            break;

                    }
                

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

            }
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
                } 
    }




 


        
         



