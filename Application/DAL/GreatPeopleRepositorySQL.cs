using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Application
{
    class GreatPeopleRepositorySQL : IGreatPeopleRepository
    {


        private IEnumerable<GreatPeople> _greatPeople = new List<GreatPeople>();

        private IEnumerable<GreatPeople> ReadAllGreatPeople()
        {
            IList<GreatPeople> greatPeople = new List<GreatPeople>();

            string connString = GetConnectionString();
            string sqlCommandString = "SELECT * from GreatPeoples";

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                GreatPeople greatPerson = new GreatPeople();   //// used greatPerson instead
                                greatPerson.ID = Convert.ToInt32(reader["ID"]);
                                greatPerson.Name = reader["Name"].ToString();
                                greatPerson.KnownFor = reader["KnownFor"].ToString();
                                greatPerson.Occupation = reader["Occupation"].ToString();
                                greatPerson.NetWorth = reader["NetWorth"].ToString();
                                greatPerson.BirthYear = reader["BirthYear"].ToString();
                                greatPerson.Description = reader["Description"].ToString();

                                greatPeople.Add(greatPerson);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }

            return greatPeople;
        }

        public GreatPeopleRepositorySQL()
        {
            _greatPeople = ReadAllGreatPeople();
        }

        /// <summary>
        /// returns list of Great People
        /// </summary>
        /// <returns></returns>
        public List<GreatPeople> SelectAll()
        {
            return _greatPeople as List<GreatPeople>;
        }

        /// <summary>
        /// Returns great person by ID
        /// 

        public GreatPeople SelectById(int Id)
        {
            return _greatPeople.Where(sr => sr.ID == Id).FirstOrDefault();
        }


        /// method to add a new great person

        public void Insert(GreatPeople greatPeople)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("INSERT INTO GreatPeoples");
            sb.Append(" ([ID],[Name],[KnownFor], [Occupation], [NetWorth], [BirthYear])");
            sb.Append(" Values (");
            sb.Append("'").Append(greatPeople.ID).Append("',");
            sb.Append("'").Append(greatPeople.Name).Append("',");
            sb.Append("'").Append(greatPeople.KnownFor).Append("',");
            sb.Append("'").Append(greatPeople.Occupation).Append("',");
            sb.Append("'").Append(greatPeople.NetWorth).Append("',");
            sb.Append("'").Append(greatPeople.BirthYear).Append("')");
            //sb.Append("'").Append(greatPeople.Description).Append ("')");
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.InsertCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        /// <summary>
        /// method to delete a Great Person by ID
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(int ID)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("DELETE FROM GreatPeoples");
            sb.Append(" WHERE ID = ").Append(ID);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        /// <summary>
        /// Update Great Person
        /// </summary>
        /// <param name="greatPeople">ski run object</param>
        public void Update(GreatPeople greatPeople)
        {
            string connString = GetConnectionString();

            // build out SQL command
            var sb = new StringBuilder("UPDATE GreatPeoples SET ");
            sb.Append("Name = '").Append(greatPeople.Name).Append("', ");
            sb.Append("KnownFor = '").Append(greatPeople.KnownFor).Append("', ");
            sb.Append("Occupation = '").Append(greatPeople.Occupation).Append("', ");
            sb.Append("NetWorth = '").Append(greatPeople.NetWorth).Append("', ");
            sb.Append("BirthYear = ").Append(greatPeople.BirthYear).Append(" ");
            //sb.Append("Description = ").Append(greatPeople.Description).Append(" ");
            sb.Append("WHERE ");
            sb.Append("ID = ").Append(greatPeople.ID);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connString))
            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
            {
                try
                {
                    sqlConn.Open();
                    sqlAdapter.UpdateCommand = new SqlCommand(sqlCommandString, sqlConn);
                    sqlAdapter.UpdateCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("SQL Exception: {0}", sqlEx.Message);
                    Console.WriteLine(sqlCommandString);
                }
            }
        }

        /// <summary>
        /// get the connection string by name
        /// </summary>
        /// <returns>string connection string</returns>
        private static string GetConnectionString()
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            var settings = ConfigurationManager.ConnectionStrings["GreatPeople_Local"];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public void Dispose()
        {
            _greatPeople = null;
        }

        public IEnumerable<GreatPeople> QueryByDateBorn(int minimumDate, int maximumDate)
        {
            return _greatPeople.Where(sr => int.Parse(sr.BirthYear) >= minimumDate && int.Parse(sr.BirthYear) <= maximumDate);
            
        }
    }
}
