namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates User table
    /// </summary>
    [Migration(202009192331, "Creates User table")]
    public class AddUserTable : Migration
    {
        private const string TableName = "User";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Users")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Login").AsString(50).NotNullable()
                .WithColumn("PasswordHash").AsString(500).NotNullable()
                .WithColumn("EmployeeId").AsInt64().ForeignKey("Employee", "Id");
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
