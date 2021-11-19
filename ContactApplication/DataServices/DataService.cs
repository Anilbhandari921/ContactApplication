using ContactUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ContactApi.DataServices
{
    public class DataService
    {
       
        public List<Contact> GetContactList()
        {

            DbConnection objConn = new DbConnection();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<Contact> _listContacts = new List<Contact>();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("uspGetContacts", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    Contact objContact = new Contact();
                    objContact.ContactId = Convert.ToInt32(_Reader["ContactId"]);
                    objContact.ContactName = _Reader["ContactName"].ToString();
                    objContact.ContactCity = _Reader["ContactCity"].ToString();
                    objContact.ContactPhone = _Reader["ContactPhone"].ToString();
                    objContact.ContactEmail = _Reader["ContactEmail"].ToString();
                    _listContacts.Add(objContact);
                }

                return _listContacts;
                //return allContacts;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Contact GetContactDetails(long? id)
        {

            DbConnection objConn = new DbConnection();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                Contact objContact = new Contact();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("uspGetContactDetails", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ContactId", id);
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    objContact.ContactId = Convert.ToInt32(_Reader["ContactId"]);
                    objContact.ContactName = _Reader["ContactName"].ToString();
                    objContact.ContactCity = _Reader["ContactCity"].ToString();
                    objContact.ContactPhone = _Reader["ContactPhone"].ToString();
                    objContact.ContactEmail = _Reader["ContactEmail"].ToString();
                }
                //objContact = allContacts.Where(e => e.ContactId == id).FirstOrDefault();

                return objContact;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 InsertContact(Contact objContact)
        {
            DbConnection objConn = new DbConnection();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("uspCreateContact", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ContactName", objContact.ContactName);
                objCommand.Parameters.AddWithValue("@ContactEmail", objContact.ContactEmail);
                objCommand.Parameters.AddWithValue("@ContactCity", objContact.ContactCity);
                objCommand.Parameters.AddWithValue("@ContactPhone", objContact.ContactPhone);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }

                //allContacts.Add(objContact);
                //return 1;
                
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 UpdateContact(Contact objContact)
        {
            DbConnection objConn = new DbConnection();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("uspUpdateContact", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ContactId", objContact.ContactId);
                objCommand.Parameters.AddWithValue("@ContactName", objContact.ContactName);
                objCommand.Parameters.AddWithValue("@ContactEmail", objContact.ContactEmail);
                objCommand.Parameters.AddWithValue("@ContactCity", objContact.ContactCity);
                objCommand.Parameters.AddWithValue("@ContactPhone", objContact.ContactPhone);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
                //allContacts.Where(e => e.ContactId == objContact.ContactId).FirstOrDefault().ContactName = objContact.ContactName;
                //allContacts.Where(e => e.ContactId == objContact.ContactId).FirstOrDefault().ContactEmail = objContact.ContactEmail;
                //allContacts.Where(e => e.ContactId == objContact.ContactId).FirstOrDefault().ContactCity = objContact.ContactCity;
                //allContacts.Where(e => e.ContactId == objContact.ContactId).FirstOrDefault().ContactPhone = objContact.ContactPhone;

                //return 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 DeleteContact(long? id)
        {
            DbConnection objConn = new DbConnection();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("uspDeleteContact", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@ContactId", id);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }

                //allContacts.Remove(allContacts.Where(e => e.ContactId == id).FirstOrDefault());
                //return 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }
    }
}
