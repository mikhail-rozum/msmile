namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates Employee tables
    /// </summary>
    [Migration(202009191502, "Creates Employee table")]
    public class AddEmployeeTable : Migration
    {
        private const string TableName = "Employee";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Employee table")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("MiddleName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("BirthDate").AsDate().Nullable()
                .WithColumn("IsFired").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("Comment").AsString(50).Nullable()
                .WithColumn("Photo").AsBinary(5000000).Nullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
