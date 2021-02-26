namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates Task table
    /// </summary>
    [Migration(202009192232, "Creates Task table")]
    public class AddTaskTable : Migration
    {
        private const string TableName = "Task";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Tasks")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(500).NotNullable()
                .WithColumn("DifficultyLevelId").AsInt64().NotNullable().ForeignKey("DifficultyLevel", "Id")
                .WithColumn("Description").AsString(2000).Nullable().WithColumnDescription("Description for employees")
                .WithColumn("CustomerDescription").AsString(1000).Nullable().WithColumnDescription("Description only for parents");
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
