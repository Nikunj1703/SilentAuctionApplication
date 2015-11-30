using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace FinalProject3
{
    public class DatabaseComponents
    {
        //private readonly string _connectionString = ConfigurationManager.ConnectionStrings["IT485ProjectConnectionString"].ConnectionString;
        string _connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;Integrated Security=true";
        //      "Data Source=itksqlexp8; Initial Catalog=itk485nnrs; Integrated Security=true";
        public IList<UserBidInformation> GetInformation(string name, string phone)
        {
            
            IList<UserBidInformation> informations = new List<UserBidInformation>();

            using (var dbConnection = new SqlConnection(_connectionString))
                try
                {
                    
                    //string query ="SELECT bidId, ItemId, email, paymentStatus, bidAmount FROM TempBidder Where winningStatus = 'winner' and name = '" + name + "' and phoneNum = '" + phone + "'";
                    string query2 = "SELECT bidId, email, ItemId,paymentStatus, bidAmount, phoneNum, name FROM TempBidder Where winningStatus = 'winner' and name = '" + name + "' and phoneNum = '" + phone + "'";
                    SqlCommand command = new SqlCommand(query2, dbConnection);

                    dbConnection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read()) { 
                        do
                        {
                            UserBidInformation userBidInformation = new UserBidInformation();
                            userBidInformation.BidId = Convert.ToInt32(reader["bidId"].ToString());
                            userBidInformation.Email = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            userBidInformation.ItemId = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            userBidInformation.PaymentStatus = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                            userBidInformation.BidAmount = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                            userBidInformation.PhoneNumber = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                            userBidInformation.Name = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

                           
                            informations.Add(userBidInformation);
                        } while (reader.Read());
                }
                        dbConnection.Close();                    
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception);
                }
            return informations;
        }
    }
}