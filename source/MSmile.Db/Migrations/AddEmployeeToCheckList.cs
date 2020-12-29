namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Add EmployeeId to CheckList table.
    /// </summary>
    [Migration(202012292349, "Add EmployeeId to CheckList table")]
    public class AddEmployeeToCheckList : Migration
    {
        private const string TableName = "CheckList";

        /// <inheritdoc />
        public override void Up()
        {
            this.Alter.Table(TableName)
                .AddColumn("EmployeeId").AsInt64().NotNullable().ForeignKey("Employee", "Id");
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
