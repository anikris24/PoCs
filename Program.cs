namespace Program;

using System;
using Microsoft.Data.SqlClient; // This is the namespace for the SQL client
using System.Threading.Tasks;
using System.Globalization;

public class Program
{
    private const string SqlServerName = "your-sql-server-name.database.windows.net";
    private const string SqlDatabaseName = "your-database-name";
    private const string SqlUsername = "your-sql-username";
    private const string SqlPassword = "your-sql-password";

    public static async Task Main()
    {
        Console.WriteLine("hello");

        // Build the connection string
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "sadblf";
        builder.UserID = "adminsa";
        builder.Password = "";
        builder.InitialCatalog = "sqldb";
        builder.Encrypt = true;             // Always encrypt for Azure SQL Database
        builder.TrustServerCertificate = false; // Important for production; only set true for dev/test with self-signed certs you explicitly trust
        builder.HostNameInCertificate = "*.database.windows.net"; // Added for more robust hostname verification
        builder.MultipleActiveResultSets = false; // Good practice, if you need MARS set to true
        builder.ConnectTimeout = 30; // Connection timeout in seconds

        string connectionString = builder.ConnectionString;
        Console.WriteLine($"connectionString {connectionString}");

        try
        {
            Console.WriteLine("Connecting to Azure SQL Database...");

            using (SqlConnection connection = new SqlConnection("Server=tcp:sadblf.database.windows.net,1433;Initial Catalog=sqldb;Persist Security Info=False;User ID=adminsa;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                await connection.OpenAsync();
                Console.WriteLine("Successfully connected to Azure SQL Database!");

                // // Define the product to insert
                // string productName = "Laptop X2000";
                // decimal productPrice = 1250.75m;
                // string productDescription = "Powerful business laptop with long battery life.";

                // // SQL INSERT statement with parameters to prevent SQL injection
                // string insertSql = @"
                //         INSERT INTO Products (Name, Price, Description)
                //         VALUES (@Name, @Price, @Description);
                //     ";

                // using (SqlCommand command = new SqlCommand(insertSql, connection))
                // {
                //     // Add parameters
                //     command.Parameters.AddWithValue("@Name", productName);
                //     command.Parameters.AddWithValue("@Price", productPrice);
                //     // Handle NULLable fields gracefully
                //     command.Parameters.AddWithValue("@Description", (object)productDescription ?? DBNull.Value);

                //     Console.WriteLine($"\nAttempting to insert product: {productName} (Price: {productPrice})");

                //     // Execute the command
                //     int rowsAffected = await command.ExecuteNonQueryAsync();

                //     Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");
                // }

                // // Optional: Verify the insert by selecting data
                // Console.WriteLine("\nVerifying data...");
                // string selectSql = "SELECT ProductId, Name, Price, Description FROM Products WHERE Name = @Name";
                // using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
                // {
                //     selectCommand.Parameters.AddWithValue("@Name", productName);
                //     using (SqlDataReader reader = await selectCommand.ExecuteReaderAsync())
                //     {
                //         if (reader.HasRows)
                //         {
                //             while (reader.Read())
                //             {
                //                 Console.WriteLine($"  Found: ID={reader.GetInt32(0)}, Name={reader.GetString(1)}, Price={reader.GetDecimal(2)}, Description={reader.IsDBNull(3) ? "NULL" : reader.GetString(3)}");
                //             }
                //         }
                //         else
                //         {
                //             Console.WriteLine("  No data found for the inserted product.");
                //         }
                //     }
                // }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            // For more detailed error, check ex.Number, ex.Errors, etc.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    



}
}