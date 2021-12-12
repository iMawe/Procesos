using System;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Oracle_Connection
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=TRANSPORTE; PASSWORD=1234";
        public Oracle_Connection()
        {
        }

        public void EstablecerConnection()
        {
            oc = new OracleConnection(oradb);
            oc.Open();

        }

        public OracleConnection GetConexion()
        {
            return oc;
        }
    }
}