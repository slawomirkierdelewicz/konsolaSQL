using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace baza_danych
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection polaczenie = new SqlConnection("Data Source = LENOVO-PC\\SQLEXPRESS; Initial Catalog = uzytkownicy; Integrated Security = True"/*-ścieżka polączenia z serwerem*/);


            try
            {
                polaczenie.Open();
                Console.WriteLine("jest połaczenie");
                SqlCommand komenda = new SqlCommand();

                komenda.Connection = polaczenie;
                komenda.CommandText = "select * from /*tutaj nazwa tabeli*/";

                SqlDataReader wyswietlenie = komenda.ExecuteReader();
                

                while (wyswietlenie.Read())
                {

                    Console.WriteLine(wyswietlenie["/*nazwa kolumny */"].ToString()+ wyswietlenie["/*nazwa drugiej kolumny*/"].ToString() + wyswietlenie["/*nazwa trzeciej kolumny*/"].ToString()/*(...)*/);

                }
                
                Console.WriteLine("wykonano polecenie");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("Błąd:" + ex.Message);
            }


            finally
            {
                if (polaczenie.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("zamknięto połaczenie");
                    polaczenie.Close();
                }
            }
            Console.ReadKey();
        }
    }
}

