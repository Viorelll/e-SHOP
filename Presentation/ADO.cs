using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace E_shopProject
{

    class ADO
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["OnlineStoreDB"].ConnectionString;
        
        static void Main2(string[] args)
        {
            SqlConnection c = new SqlConnection();
            SQLCommand();
            //CreateDataTabel();
            //ImportDataToMemory();
            //InsertItem(104, "Webcam Microsoft 6200", "Microsoft", "Periferice", 49, "Best item ever :)");
            //UpdateItem(2, "TEST");
            //DeleteItem(104);
         

            Console.ReadKey();
        }

        static void DeleteItem(int id)
        {
            var sqlCommandText = "DELETE FROM [Item] WHERE [Item_ID] = @ID";

            var getSqlCommandText = "SELECT * FROM [Item];";


            DataTable dataTable = new DataTable(); //create table
            SqlDataAdapter populateDataAdapter = new SqlDataAdapter(getSqlCommandText, connectionString); //create data adapter for import data
            populateDataAdapter.Fill(dataTable); //fill table with obtain data

            bool boolVerifyID = dataTable.AsEnumerable().Any(x => x.Field<long>("Item_ID") == id);

            if (boolVerifyID)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    SqlCommand deleteCommand = new SqlCommand(sqlCommandText, sqlConnection); //create update command

                    deleteCommand.Parameters.Add("@ID", SqlDbType.BigInt, 8, "Item_ID");
  
                    populateDataAdapter.DeleteCommand = deleteCommand;

                    var row = dataTable.AsEnumerable().First(x => x.Field<long>("Item_ID") == id);
                    row.Delete();

                    populateDataAdapter.Update(dataTable);
                }

                Console.WriteLine("Item was deleted!");
            }

            else Console.WriteLine("Sryy this item doesn't exist !");
        }

        static void UpdateItem(long id, string name)
        {
            var sqlCommandText = "UPDATE [Item] SET [Name] = @Name WHERE [Item_ID] = @ID";

            var getSqlCommandText = "SELECT * FROM [Item];";


            DataTable dataTable = new DataTable(); //create table
            SqlDataAdapter populateDataAdapter = new SqlDataAdapter(getSqlCommandText, connectionString); //create data adapter for import data
            populateDataAdapter.Fill(dataTable); //fill table with obtain data

            bool boolVerifyID = dataTable.AsEnumerable().Any(x => x.Field<long>("Item_ID") == id);


            if (boolVerifyID)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    SqlCommand updateCommand = new SqlCommand(sqlCommandText, sqlConnection); //create update command

                    updateCommand.Parameters.Add("@ID", SqlDbType.BigInt, 8, "Item_ID");
                    updateCommand.Parameters.Add("@Name", SqlDbType.VarChar, 255, "Name");


                    populateDataAdapter.UpdateCommand = updateCommand;

                    var row = dataTable.AsEnumerable().First(x => x.Field<long>("Item_ID") == id);
                    row["Name"] = name;

                    populateDataAdapter.Update(dataTable);
                }

                Console.WriteLine("Item is up to date!");
            }
            else Console.WriteLine("Sryy this item doesn't exist !");
        }

        static void InsertItem(long id, string name, string brand, string category, decimal price, string description)
        {

            var sqlCommandText = "INSERT INTO [Item]([Item_ID], [Name], [Brand], [Category], [Price], [Description]) " +
                             "VALUES(@ID, @Name, @Brand, @Category, @Price, @Description)";

            var getSqlCommandText = "SELECT * FROM [Item];";


            DataTable dataTable = new DataTable(); //create table
            SqlDataAdapter populateDataAdapter = new SqlDataAdapter(getSqlCommandText, connectionString); //create data adapter for import data
            populateDataAdapter.Fill(dataTable); //fill table with obtain data

            bool boolVerifyID = dataTable.AsEnumerable().Any(x => x.Field<long>("Item_ID") == id);
          
            if (!boolVerifyID)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    SqlCommand insertCommand = new SqlCommand(sqlCommandText, sqlConnection); //create insert command

                    insertCommand.Parameters.Add("@ID", SqlDbType.BigInt, 8, "Item_ID");
                    insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 255, "Name");
                    insertCommand.Parameters.Add("@Brand", SqlDbType.VarChar, 255, "Brand");
                    insertCommand.Parameters.Add("@Category", SqlDbType.VarChar, 255, "Category");
                    insertCommand.Parameters.Add("@Price", SqlDbType.Money, 8, "Price");
                    insertCommand.Parameters.Add("@Description", SqlDbType.VarChar, 255, "Description");

                    populateDataAdapter.InsertCommand = insertCommand;
                    var row = dataTable.NewRow();

                    row["Item_ID"] = id;
                    row["Name"] = name;
                    row["Brand"] = brand;
                    row["Category"] = category;
                    row["Price"] = price;
                    row["Description"] = description;

                    dataTable.Rows.Add(row);
                    populateDataAdapter.Update(dataTable);
                }

                Console.WriteLine("Item was added !");
            }
            else Console.WriteLine("Sryy this item exist !");
        }

        static void ImportDataToMemory()
        {
            var sqlCommandText = "SELECT * FROM [Item];";

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommandText, connectionString);
            dataAdapter.Fill(dataTable);

            //print tabel
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);

                }
                Console.WriteLine();
            }

      

        }

        static void CreateDataTabel()
        {
            DataTable Expensive_Items = new DataTable("Expensive_Items");


            //Create columns
            DataColumn Item_ID = new DataColumn("Item_ID", typeof(long));

            //Add columns to tabel
            Expensive_Items.Columns.Add(Item_ID);
            Expensive_Items.Columns.Add("Name", typeof(string));
            Expensive_Items.Columns.Add("Category", typeof(string));
            Expensive_Items.Columns.Add("Price", typeof(decimal));


            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();


                string sqlCommandText_DataReader = "SELECT TOP 5 [Item_ID], [Name], [Category], [Price] FROM [Item] ORDER BY[Price] DESC";


                using (var sqlCommand = new SqlCommand(sqlCommandText_DataReader, sqlConnection))
                {
                
                         SqlDataReader itemsReader = sqlCommand.ExecuteReader();

                        /*Populate Item Details*/
                        while (itemsReader.Read())
                        {
                            long ID = (long)itemsReader["Item_ID"];
                            string Name = (string)itemsReader["Name"];
                            string Category = (string)itemsReader["Category"];
                            decimal Price = (decimal)itemsReader["Price"];

                            //Declare data rows
                            DataRow row_item = Expensive_Items.NewRow();
                            row_item["Item_ID"] = ID;
                            row_item["Name"] = Name;
                            row_item["Category"] = Category;
                            row_item["Price"] = Price;

                            //Add data rows
                            Expensive_Items.Rows.Add(row_item);


                         } // end while 

                    } // end using sqlCommnad

            } // end sqlConnection

            foreach (DataRow dataRow in Expensive_Items.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                    
                }
                Console.WriteLine();
            }

        }

        static void SQLCommand()
        {
            int number_of_items = 0;


            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string sqlCommandText_NonQuery = "IF OBJECT_ID('Test', 'U') IS NOT NULL DROP TABLE[Test]; CREATE TABLE Test(userId int not null identity(1,1) primary key, name NVARCHAR(255))";
                string sqlCommandText_Scalar = "SELECT COUNT(*) FROM [Item]";
                string sqlCommandText_DataReader = "SELECT * FROM [Item] WHERE [Item].[Item_ID] = @ID";

                //nonQuery command
                using (var sqlCommand = new SqlCommand(sqlCommandText_NonQuery, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }

                //scalar command
                using (var sqlCommand = new SqlCommand(sqlCommandText_Scalar, sqlConnection))
                {
                    number_of_items = (int)sqlCommand.ExecuteScalar();
                }


                //dataReader command
                using (var sqlCommand = new SqlCommand(sqlCommandText_DataReader, sqlConnection))
                {

                    SqlDataReader itemsReader = null;
                    sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt);
                   


                    bool condition = true;

                    while (condition)
                    {
                        Console.Clear();
                        Console.WriteLine("Total items: " + number_of_items);
                        Console.Write("Input user id for search: ");
                        int searchID = Int32.Parse(Console.ReadLine());

                        if (searchID <= 0 || number_of_items < searchID)
                        {
                            Console.WriteLine("Wrong range !");
                            Console.ReadKey();
                            condition = true;
                        }
                        else
                        {
                            sqlCommand.Parameters["@ID"].Value = searchID;
                            itemsReader = sqlCommand.ExecuteReader();

                            /*Print Item Details*/
                            while (itemsReader.Read())
                            {
                                //long ID = (long) itemsReader["Item_ID"];
                                string Name = (string)itemsReader["Name"];
                                string Brand = (string)itemsReader["Brand"];
                                string Category = (string)itemsReader["Category"];
                                string Description = (string)itemsReader["Description"];

                                Console.WriteLine($"\nName: {Name}\nBrand: {Brand}\nCategory: {Category}\nDescription: {Description}");

                            }

                            condition = false;
                        }

                    }

                }

            }
        }
    }
}
