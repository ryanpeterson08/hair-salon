using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Salon
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

    public Client(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylistId = StylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
        return(idEquality && nameEquality && stylistEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @StylistId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetStylistId();
      cmd.Parameters.Add(stylistIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, stylistId, clientId);
        allClients.Add(newClient);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allClients;
    }

    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);

      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = id.ToString();
      cmd.Parameters.Add(clientIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      int foundClientId = 0
      string foundName = null;
      int foundStylistId = 0;

      while(rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
        foundStylistId = rdr.GetInt32(2);
      }
      Client foundClient = new Client(foundName, foundStylistId, foundClientId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundClient;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
