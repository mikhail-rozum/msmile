namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates Parent table
    /// </summary>
    [Migration(202009191510, "Creates Parent table")]
    public class AddParentTable : Migration
    {
        private const string TableName = "Parent";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Parents")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("MiddleName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("Comment").AsString(1000).Nullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
