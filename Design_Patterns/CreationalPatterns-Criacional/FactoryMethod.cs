using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalPatterns_Criacional
{
    public interface ISQLConnection
    {
        string ObterConexao();
    }


    public class Oracle : ISQLConnection
    {
        public string ObterConexao()
        {
            return "string de conexaoOracle";
        }
    }

    public class SQLServer : ISQLConnection
    {
        public string ObterConexao()
        {
            return "string de conexaoSQLServer";
        }
    }

    public class MySql : ISQLConnection
    {
        public string ObterConexao()
        {
            return "string de conexaoMySql";
        }
    }


    public abstract class SQLConnectionFactory
    {
        public abstract ISQLConnection ObterTipoBanco(ConexoesBanco conexoesBanco);
    }


    public class ConcreteSQLConnectionFactory : SQLConnectionFactory
    {
        public override ISQLConnection ObterTipoBanco(ConexoesBanco conexoesBanco)
        {
            switch (conexoesBanco)
            {
                case ConexoesBanco.Oracle:
                    return new Oracle();
                case ConexoesBanco.SQLServer:
                    return new SQLServer();
                case ConexoesBanco.MySql:
                    return new MySql();
                default:
                    throw new ApplicationException("Tipo de banco não encontrado");
            }
        }
    }

    //Classe cliente
    public class FactoryMethod
    {
        public static void CriarConexao()
        {
            var conexao = new ConcreteSQLConnectionFactory();

            var SQLServer = conexao.ObterTipoBanco(ConexoesBanco.SQLServer);
            string conexaoSQLServer =  SQLServer.ObterConexao();

            var MySql = conexao.ObterTipoBanco(ConexoesBanco.MySql);
            string conexaoMySql = MySql.ObterConexao();

            var Oracle = conexao.ObterTipoBanco(ConexoesBanco.Oracle);
            string coenxaoOracle = Oracle.ObterConexao();
        }

    }

    public enum ConexoesBanco
    {
        Oracle,
        SQLServer,
        MySql
    }

}
