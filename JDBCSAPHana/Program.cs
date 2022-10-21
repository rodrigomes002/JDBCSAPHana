// See https://aka.ms/new-console-template for more information
using JDBC.NET.Data;
using System.Data.Common;

var builder = new JdbcConnectionStringBuilder
{
    DriverPath = "path/ngdbc-2.7.9.jar",
    DriverClass = "com.sap.db.jdbc.Driver",
    JdbcUrl = "jdbc:sap:host:porta/schema?user=sapAdmin&password=1234"
};

using var connection = new JdbcConnection(builder);
connection.Open();

var sql = "SELECT * FROM SCHEMA.TABELA WHERE COLUNA = 'VALOR'";

using var command = connection.CreateCommand(sql);

try
{
    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader["COLUNA"]);
    }    
}
catch (DbException ex)
{
    Console.WriteLine(ex.Message);
}

connection.Close();




