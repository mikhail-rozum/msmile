namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates Test table
    /// </summary>
    [Migration(202009191119, "Create test table")]
    public class AddTestTable : Migration
    {
        private const string TableName = "Test";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Test table")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsString(100).NotNullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
