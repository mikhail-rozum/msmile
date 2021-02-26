namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates ParentContact table
    /// </summary>
    [Migration(202009191525, "Creates ParentContact table")]
    public class AddParentContactTable : Migration
    {
        private const string TableName = "ParentContact";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("ParentContacts")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("ParentId").AsInt64().NotNullable().ForeignKey("Parent", "Id")
                .WithColumn("Tel").AsString(50).NotNullable()
                .WithColumn("IsPrimary").AsBoolean().NotNullable().WithDefaultValue(false);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
