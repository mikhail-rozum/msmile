namespace MSmile.Db.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    using FluentMigrator;

    /// <summary>
    /// Insert default user.
    /// </summary>
    [Migration(202002262312, "Insert default user")]
    public class InsertDefaultUser : Migration
    {
        private const string AdminLogin = "admin";
        private const string AdminPassword = "123456";
        private const string TableName = "User";

        /// <inheritdoc />
        public override void Up()
        {
            this.Insert.IntoTable("Employee").Row(
                new Dictionary<string, object>
                {
                    { "Id", 1 },
                    { "FirstName", "Admin" },
                    { "MiddleName", "Admin" },
                    { "LastName", "Admin" },
                    { "BirthDate", new DateTime(2000, 1, 1) },
                    { "IsFired", false },
                    { "Comment", "Embedded admin account" }
                });

            var passwordBuffer = Encoding.ASCII.GetBytes(AdminPassword);
            var hashBuffer = MD5.HashData(passwordBuffer);
            var hash = BitConverter.ToString(hashBuffer).Replace("-", string.Empty).ToLower();
            this.Insert.IntoTable(TableName).Row(
                new Dictionary<string, object>
                {
                    { "Login", AdminLogin },
                    { "PasswordHash", hash },
                    { "EmployeeId", 1 }
                });
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
