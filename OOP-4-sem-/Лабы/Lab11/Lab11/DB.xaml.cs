using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace Lab11
{
    public partial class MainWindow : Window
    {
        private string connectionString;
        private DataTable product;
        private DataTable producer;
        private SqlDataAdapter adapter;
        private byte[] imageData = null;

        public MainWindow()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SelectAllProducts();
            SelectAllProducers();
        }

        #region Select
        public void SelectAllProducts()
        {            
            product = new DataTable();
            var connection = new SqlConnection(connectionString);
            var sqlExpression = "SELECT * FROM Products";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(product);
                ProductDB.ItemsSource = product.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SelectAllProducers()
        {
            producer = new DataTable();
            var connection = new SqlConnection(connectionString);
            var sqlExpression = "SELECT * FROM Producers";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(producer);
                ProducerDB.ItemsSource = producer.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            SelectAllProducts();
            SelectAllProducers();
        }

        #endregion

        #region Delete

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            var sql = string.Format($"Delete from Products where Id = '{IdProduct.Text}'");

            try
            {
                connection.Open();

                var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                MessageBox.Show($"Delete from Products where Id = '{IdProduct.Text}'");

                SelectAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void DeleteAllProducts_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            var sql = string.Format($"Delete from Products");

            try
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                SelectAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void DeleteProducer_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            var sql = string.Format($"Delete from Producers where Id = '{IdProducer.Text}'");

            connection.Open();

            using (var command = new SqlCommand(sql, connection))
            {
                try
                {
                    command.ExecuteNonQuery();

                    MessageBox.Show($"Delete from Products where Id = '{IdProducer.Text}'");

                    SelectAllProducers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void DeleteAllProducers_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            var sql = string.Format($"Delete from Producers");

            try
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                SelectAllProducers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region Insert
        private void image_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            var fInfo = new FileInfo(dlg.FileName);
            var numBytes = fInfo.Length;
            var fStream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);
        }

        private void InsertProduct_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();
                var sql = string.Format($"INSERT INTO Products (Name, IdProducer, Image) VALUES(@Name, @IdProducer, @Image)");

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (nameText.Text.Length != 0 && idProducerText.Text.Length !=0)
                    {
                        command.Parameters.AddWithValue("@Name", nameText.Text);
                        command.Parameters.AddWithValue("@idProducer", idProducerText.Text);
                        command.Parameters.AddWithValue("@Image", imageData);
                        command.ExecuteNonQuery();
                        SelectAllProducts();
                    }
                    else
                    {
                        MessageBox.Show("Check data!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void InsertProducer_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();
                var sql = string.Format($"INSERT INTO Producers (Country, Address) VALUES(@Country, @Address)");

                using (var command = new SqlCommand(sql, connection))
                {
                    if (countryText.Text.Length != 0 && addressText.Text.Length != 0)
                    {
                        command.Parameters.AddWithValue("@Country", countryText.Text);
                        command.Parameters.AddWithValue("@Address", addressText.Text);
                        command.ExecuteNonQuery();
                        SelectAllProducers();
                    }
                    else
                    {
                        MessageBox.Show("Check data!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region Sort
        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            product = new DataTable();
            var connection = new SqlConnection(connectionString);
            var sqlExpression = "SELECT * FROM Products ORDER BY Name";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(product);
                ProductDB.ItemsSource = product.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SortByIdProducer_Click(object sender, RoutedEventArgs e)
        {
            product = new DataTable();
            var connection = new SqlConnection(connectionString);
            var sqlExpression = "SELECT * FROM Products ORDER BY IdProducer";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(product);
                ProductDB.ItemsSource = product.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SortByCountry_Click(object sender, RoutedEventArgs e)
        {
            producer = new DataTable();
            var connection = new SqlConnection(connectionString);
            var sqlExpression = "SELECT * FROM Producers ORDER BY Country";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(producer);
                ProducerDB.ItemsSource = producer.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SortByIdAddress_Click(object sender, RoutedEventArgs e)
        {
            producer = new DataTable();
            var connection = new SqlConnection(connectionString);
            var sqlExpression = "SELECT * FROM Producers ORDER BY Address";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(producer);
                ProducerDB.ItemsSource = producer.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region Update
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                var sql = string.Format($"UPDATE Products SET Name=@Name, IdProducer=@idProducer WHERE Id=@Id;");

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (nameUpdate.Text.Length != 0 && idProducerUpdate.Text.Length != 0)
                    {
                        command.Parameters.AddWithValue("@Name", nameUpdate.Text);
                        command.Parameters.AddWithValue("@idProducer", idProducerUpdate.Text);
                        command.Parameters.AddWithValue("@Id", IdProductUpdate.Text);
                        command.ExecuteNonQuery();
                        SelectAllProducts();
                    }
                    else
                    {
                        MessageBox.Show("Check data!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void UpdateProducer_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                var sql = string.Format($"UPDATE Producers SET Country=@Name, Address=@Address WHERE Id=@Id;");

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (countryUpdate.Text.Length != 0 && addressUpdate.Text.Length != 0)
                    {
                        command.Parameters.AddWithValue("@Name", countryUpdate.Text);
                        command.Parameters.AddWithValue("@Address", addressUpdate.Text);
                        command.Parameters.AddWithValue("@Id", IdProducerUpdate.Text);
                        command.ExecuteNonQuery();
                        SelectAllProducers();
                    }
                    else
                    {
                        MessageBox.Show("Check data!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Search
        private void SearchName_Click(object sender, RoutedEventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            var sqlExpression = $"SELECT * FROM Products WHERE Name LIKE '%{SearchName.Text}%'";

            try
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(product);
                ProductDB.ItemsSource = product.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion
    }
}
